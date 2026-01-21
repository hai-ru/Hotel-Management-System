using Hotel_Management_System.Screens;
using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace Hotel_Management_System.Controllers
{
    public partial class RoomsScreen : Form
    {
        HttpConnection conn = new HttpConnection();
        private int roomId;

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        TipeKamar[] tipeKamars = new TipeKamar[] { };
        TipeKebersihan[] tipeKebersihans = new TipeKebersihan[] { };
        
        private bool isLoadingTipeKamar = false;
        private bool isLoadingTipeKebersihan = false;
        private bool isLoadingTable = false;
        private CacheManager cache = CacheManager.Instance;



        public RoomsScreen()
        {
            InitializeComponent();
            //roomIdField.ReadOnly = false;
            //costField.ReadOnly = true;
            loadingText.Visible = false;
            
            // Optimasi: Jangan load semua data di constructor
            // Biarkan form muncul dulu, baru load data
        }

        private void populateTable()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT RoomId, RoomNumber, RoomTypeId, Available FROM Rooms.Room WHERE HotelId = " + Statics.hotelIdTKN;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            roomsTable.DataSource = ds.Tables[0];
            con.Close();
        }

        public void populate()
        {
            populateTable();
            populateTypeComboBox();
        }

        // private async void refreshTable(int brand_id = 0,string kebersihan = "")
        // {
        //     loadingText.Visible = true;
        //     HttpData result = await conn.GetRoomList(false,brand_id,kebersihan);
        //     if (!result.status)
        //     {
        //         loadingText.Visible=false;
        //         MessageBox.Show(result.message);
        //         return;
        //     }
        //     DataTable MyTable = JsonConvert.DeserializeObject<DataTable>(result.data.ToString());
        //     roomsTable.DataSource = MyTable;
        //     roomsTable.CellFormatting += roomsTable_CellFormatting;
        //     loadingText.Visible = false;
        // }

        private async void refreshTable(int brand_id = 0, string kebersihan = "")
        {
            // Prevent multiple simultaneous requests
            if (isLoadingTable)
            {
                return;
            }
            
            isLoadingTable = true;
            loadingText.Visible = true;
            loadingText.Text = "Loading rooms...";
            roomsTable.Enabled = false; // Disable interaction saat loading
            
            try
            {
                // Cek cache dulu untuk kombinasi filter ini
                string cacheKey = $"{CacheKeys.ROOM_LIST_PREFIX}{brand_id}_{kebersihan}";
                DataTable cachedData = cache.Get<DataTable>(cacheKey);
                
                if (cachedData != null)
                {
                    // Gunakan data dari cache
                    ProcessRoomData(cachedData);
                    return;
                }
                
                HttpData result = await conn.GetRoomList(false, brand_id, kebersihan);
                if (!result.status)
                {
                    MessageBox.Show(result.message);
                    return;
                }

                DataTable myTable = JsonConvert.DeserializeObject<DataTable>(result.data.ToString());
                
                // Simpan ke cache (expire 2 menit untuk room list karena sering berubah)
                cache.Set(cacheKey, myTable, TimeSpan.FromMinutes(2));
                
                ProcessRoomData(myTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingTable = false;
                loadingText.Visible = false;
                roomsTable.Enabled = true;
            }
        }
        
        private void ProcessRoomData(DataTable myTable)
        {

            // Check if any row has a "KEBERSIHAN" value of "VCI" or "VD"
            bool canSort = myTable.AsEnumerable().Any(row =>
            {
                string value = row.Field<string>("KEBERSIHAN");
                return value == "VCI" || value == "VD";
            });

            if (canSort)
            {
                // Sort rows: "VCI" first, "VD" second, then all others.
                var sortedRows = myTable.AsEnumerable()
                    .OrderBy(row =>
                    {
                        string value = row.Field<string>("KEBERSIHAN");
                        if (value == "VCI")
                            return 1;
                        else if (value == "VD")
                            return 2;
                        else
                            return 3;
                    })
                    .ThenBy(row => row.Field<string>("ROOM NAME")); // Optional secondary sorting

                DataTable sortedTable = sortedRows.CopyToDataTable();
                roomsTable.DataSource = sortedTable;
            }
            else
            {
                roomsTable.DataSource = myTable;
            }

            // Populate label3.Text with available room counts based on 'TIPE KAMAR'
            // counting only rooms with KEBERSIHAN "VCI" or "VD".
            var roomCounts = myTable.AsEnumerable()
                .Where(row =>
                {
                    string cleaning = row.Field<string>("KEBERSIHAN");
                    return cleaning == "VCI" || cleaning == "VD";
                })
                .GroupBy(row => row.Field<string>("TIPE KAMAR"))
                .Select(g => new { TipeKamar = g.Key, Count = g.Count() })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var rc in roomCounts)
            {
                // Each line will appear as "Room Type: Count"
                sb.AppendLine($"{rc.TipeKamar}: {rc.Count}");
            }
            label3.Text = sb.ToString();

            // Remove old event handler untuk prevent duplicate
            roomsTable.CellFormatting -= roomsTable_CellFormatting;
            roomsTable.CellFormatting += roomsTable_CellFormatting;
        }


        private void roomsTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (roomsTable.Columns[e.ColumnIndex].Name == "TODAY AVAILABLE" && e.Value != null)
            {

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.Value.ToString() == "0")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                if (e.Value.ToString() == "1")
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }
            }

            if (roomsTable.Columns[e.ColumnIndex].Name == "NOT FOR SELL" && e.Value != null)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.Value.ToString() == "1")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                if (e.Value.ToString() == "0")
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }
            }

            if (roomsTable.Columns[e.ColumnIndex].Name == "KEBERSIHAN" && e.Value != null)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.Value.ToString() == "VD")
                {
                    e.CellStyle.BackColor = Color.DarkRed;
                    e.CellStyle.ForeColor = Color.White;
                }
                if (e.Value.ToString() == "VC")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                if (e.Value.ToString() == "OD")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                if (e.Value.ToString() == "OC")
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }
            }
        }

        private async void Rooms_Load(object sender, EventArgs e)
        {
            // Lazy loading: Load essentials dulu, sisanya di background
            // Ini membuat form muncul lebih cepat
            
            loadingText.Visible = true;
            loadingText.Text = "Initializing...";
            
            try
            {
                // Load combo boxes dulu (ringan), table nanti
                await Task.WhenAll(
                    Task.Run(() => this.Invoke(new Action(() => getTipeRoom()))),
                    Task.Run(() => this.Invoke(new Action(() => getTipeKebersihan())))
                );
                
                // Baru load table data (berat)
                await Task.Delay(100); // Small delay biar UI responsive
                refreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingText.Visible = false;
            }
        }

        private async void getTipeRoom()
        {
            if (isLoadingTipeKamar) return;
            
            isLoadingTipeKamar = true;
            tipeKamarCb.Enabled = false;
            
            try
            {
                // Cek cache dulu
                tipeKamars = cache.Get<TipeKamar[]>(CacheKeys.TIPE_KAMAR);
                
                if (tipeKamars == null)
                {
                    // Cache miss, fetch from API
                    HttpData result = await conn.GetTipeKamarList();
                    if (!result.status)
                    {
                        MessageBox.Show(result.message);
                        return;
                    }

                    tipeKamars = JsonConvert.DeserializeObject<TipeKamar[]>(result.data.ToString());
                    
                    // Cache selama 30 menit (jarang berubah)
                    cache.Set(CacheKeys.TIPE_KAMAR, tipeKamars, TimeSpan.FromMinutes(30));
                }
                
                tipeKamarCb.Items.Clear();
                tipeKamarCb.DisplayMember = "name";

                foreach (TipeKamar tipe in tipeKamars)
                {
                    tipeKamarCb.Items.Add(tipe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingTipeKamar = false;
                tipeKamarCb.Enabled = true;
            }
        }

        private async void getTipeKebersihan()
        {
            if (isLoadingTipeKebersihan) return;
            
            isLoadingTipeKebersihan = true;
            kebersihanFilter.Enabled = false;
            
            try
            {
                // Cek cache dulu
                tipeKebersihans = cache.Get<TipeKebersihan[]>(CacheKeys.TIPE_KEBERSIHAN);
                
                if (tipeKebersihans == null)
                {
                    // Cache miss, fetch from API
                    HttpData result = await conn.GetTipeKebersihan();
                    if (!result.status)
                    {
                        MessageBox.Show(result.message);
                        return;
                    }

                    tipeKebersihans = JsonConvert.DeserializeObject<TipeKebersihan[]>(result.data.ToString());
                    
                    // Cache selama 30 menit (jarang berubah)
                    cache.Set(CacheKeys.TIPE_KEBERSIHAN, tipeKebersihans, TimeSpan.FromMinutes(30));
                }
                
                kebersihanFilter.Items.Clear();
                kebersihanFilter.DisplayMember = "name";

                foreach (TipeKebersihan tipe in tipeKebersihans)
                {
                    kebersihanFilter.Items.Add(tipe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading kebersihan types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingTipeKebersihan = false;
                kebersihanFilter.Enabled = true;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            //addButton.Enabled = false;
            //if (roomIdField.Text == "")
            //{
            //    MessageBox.Show("Please enter id to search record.", "Missing Info", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    bool temp = false;
            //    SqlConnection con = dc.getConnection();
            //    con.Open();
            //    query = "SELECT * FROM Rooms.Room WHERE RoomId = " + int.Parse(roomIdField.Text);
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        roomNoField.Text = dr.GetValue(1).ToString();
            //        typeCmbox.Text = getNameFromId(dr.GetInt32(3));
            //        availableField.Text = dr.GetString(4).ToString();
            //        findCost();
            //        temp = true;
            //    }
            //    if (temp == false)
            //        MessageBox.Show("No record found.");
            //    con.Close();
            //}
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //addButton.Enabled = true;
            clearFields();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.loadForm(new HotelIntroScreen());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            RoomType rt = new RoomType();
            rt.ShowDialog(this);
        }

        private void clearFields()
        {
            //roomIdField.Text = "";
            //roomNoField.Text = "";
            //availableField.SelectedIndex = -1;
            //typeCmbox.SelectedIndex = -1;
            //costField.Text = "";
        }

        private void populateTypeComboBox()
        {
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //query = "SELECT Name from Rooms.RoomType WHERE HotelId = " + Statics.hotelIdTKN;
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    typeCmbox.Items.Add(dr["Name"]);
            //}
            //con.Close();
        }

        private int getIdFromTypeName()
        {
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //query = "SELECT RoomTypeId from Rooms.RoomType WHERE Name = '" + typeCmbox.Text + "' AND HotelId = " + Statics.hotelIdTKN;
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    roomId = dr.GetInt32(0);
            //}
            //return roomId;
            return 0;
        }

        String name;

        private String getNameFromId(int id)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT Name from Rooms.RoomType WHERE RoomTypeId = " + id + " AND HotelId = " + Statics.hotelIdTKN;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr.GetString(0);
            }
            return name;
        }

        private bool regChecker()
        {
            //if (!Regex.Match(roomNoField.Text, @"^[a-zA-Z0-9]*$").Success)
            //{
            //    MessageBox.Show("Room number must only contain numbers.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    roomNoField.Focus();
            //    return false;
            //}
            //if (!Regex.Match(costField.Text, @"^[0-9]+$").Success)
            //{
            //    MessageBox.Show("Contact number must only contain numbers.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    costField.Focus();
            //    return false;
            //}
            //return true;
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //int id = getIdFromTypeName();
            //if (roomNoField.Text != "" && typeCmbox.Text != "" && costField.Text != "" && availableField.Text != "")
            //{
            //    int capacity = findCapacity();
            //    int count = getRoomCount();
            //    if (count < capacity)
            //    {
            //        bool regCheck = regChecker();
            //        if (regCheck == false)
            //        {
            //            return;
            //        }
            //        query = "INSERT INTO Rooms.Room (RoomNumber, HotelId, RoomTypeId, Available) VALUES ('" + roomNoField.Text + "', " + Statics.hotelIdTKN + ", " + id + ", '" + availableField.Text + "')";
            //        dc.setData(query, "Room inserted successfully!");
            //        clearFields();
            //        populateTable();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hotel room capacity is full to add more rooms.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void typeCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            findCost();
        }

        private int getRoomCount()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT COUNT(RoomId) from Rooms.Room WHERE HotelId = " + Statics.hotelIdTKN;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = dr.GetInt32(0);
            }
            return count;
        }

        private int findCapacity()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT TotalRooms from Hotels.Hotel WHERE HotelId = " + Statics.hotelIdTKN;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int cap = 0;
            while (dr.Read())
            {
                cap = dr.GetInt32(0);
            }
            return cap;
        }

        private void findCost()
        {
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //int cost = 0; ;
            //query = "SELECT Cost from Rooms.RoomType WHERE Name = '" + typeCmbox.Text + "' AND HotelId = " + Statics.hotelIdTKN;
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    cost = dr.GetInt32(0);
            //}
            //costField.Text = cost.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //addButton.Enabled = true;
            //if (roomIdField.Text == "")
            //{
            //    MessageBox.Show("Please enter id to update record.", "Missing Info", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    bool regCheck = regChecker();
            //    if (regCheck == false)
            //    {
            //        return;
            //    }
            //    getIdFromTypeName();
            //    query = "UPDATE Rooms.Room SET RoomNumber = '" + roomNoField.Text + "', RoomTypeId = " + roomId + ", Available = '" + availableField.Text + "' WHERE RoomId = " + int.Parse(roomIdField.Text);
            //    dc.setData(query, "Record updated successfully.");
            //    clearFields();
            //    populateTable();
            //}
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //addButton.Enabled = true;
            //if (roomIdField.Text == "")
            //{
            //    MessageBox.Show("Please enter id to delete.", "Missing Info", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    bool b = checkIfFree(int.Parse(roomIdField.Text));
            //    if (b == true)
            //    {
            //        query = "DELETE FROM Rooms.Room WHERE RoomId = " + int.Parse(roomIdField.Text);
            //        dc.setData(query, "Record deleted successfully.");
            //        clearFields();
            //        populateTable();
            //    }
            //    else
            //    {
            //        MessageBox.Show("You cannot delete a room if its in use.", "Warning", MessageBoxButtons.OK);
            //    }
            //}
        }

        private bool checkIfFree(int id)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT Available FROM Rooms.Room WHERE RoomId = " + id + " AND HotelId = " + Statics.hotelIdTKN;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            String s = "";
            while (dr.Read())
            {
                s = dr.GetString(0).Trim();
            }
            if (s.Equals("Yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RoomsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //addButton.Enabled = false;
            //roomIdField.Text = roomsTable.SelectedRows[0].Cells[0].Value.ToString();
            //roomNoField.Text = roomsTable.SelectedRows[0].Cells[1].Value.ToString();
            //availableField.Text = roomsTable.SelectedRows[0].Cells[3].Value.ToString();
            //typeCmbox.SelectedItem = getNameFromId(int.Parse(roomsTable.SelectedRows[0].Cells[2].Value.ToString()));
            findCost();
        }

        private void typeCmbox_Click(object sender, EventArgs e)
        {
            //typeCmbox.Items.Clear();
            populateTypeComboBox();
        }

        private void loadingText_Click(object sender, EventArgs e)
        {

        }

        public class TipeKamar
        {
            public int id;
            public string name;

            public override string ToString()
            {
                return name;
            }
        }

        public class TipeKebersihan
        {
            public string id;
            public string name;

            public override string ToString()
            {
                return name;
            }
        }

        private void filterTable ()
        {
            var tipekamar = tipeKamarCb.SelectedItem as TipeKamar;
            int id = 0;
            if (tipekamar != null) id = tipekamar.id;

            var kebersihan = kebersihanFilter.SelectedItem as TipeKebersihan;
            string bersih_id = "";
            if (kebersihan != null) bersih_id = kebersihan.id;

            refreshTable(id, bersih_id);
        }

        private void tipeKamarCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTable();
        }

        private void kebersihanFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTable();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            var tipekamar = tipeKamarCb.SelectedItem as TipeKamar;
            int id = 0;
            if (tipekamar != null) id = tipekamar.id;

            var kebersihan = kebersihanFilter.SelectedItem as TipeKebersihan;
            string bersih_id = "";
            if (kebersihan != null) bersih_id = kebersihan.id;

            string link = "https://development.norapos.com/api/hotel/room/print?business_id=11tipe_kamar=" + id + "&kebersihan=" + bersih_id;
            Form2 form2 = new Form2(link);
            form2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
