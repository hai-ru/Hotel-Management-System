using Hotel_Management_System.Screens;
using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;

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



        public RoomsScreen()
        {
            InitializeComponent();
            //roomIdField.ReadOnly = false;
            //costField.ReadOnly = true;
            loadingText.Visible = false;
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
            loadingText.Visible = true;
            HttpData result = await conn.GetRoomList(false, brand_id, kebersihan);
            if (!result.status)
            {
                loadingText.Visible = false;
                MessageBox.Show(result.message);
                return;
            }
            DataTable MyTable = JsonConvert.DeserializeObject<DataTable>(result.data.ToString());

            // Use LINQ to sort rows based on custom order for KEBERSIHAN:
            // VCI -> first, VD -> second, and the rest after.
            var sortedRows = MyTable.AsEnumerable()
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

            // Create a new DataTable with the sorted rows.
            DataTable sortedTable = sortedRows.CopyToDataTable();

            roomsTable.DataSource = sortedTable;
            roomsTable.CellFormatting += roomsTable_CellFormatting;
            loadingText.Visible = false;
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

        private void Rooms_Load(object sender, EventArgs e)
        {
            refreshTable();
            getTipeRoom();
            getTipeKebersihan();
        }

        private async void getTipeRoom()
        {
            HttpData result = await conn.GetTipeKamarList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to OTA array
            tipeKamars = JsonConvert.DeserializeObject<TipeKamar[]>(result.data.ToString());
            tipeKamarCb.Items.Clear();

            // Bind rooms to roomIdCMBox
            tipeKamarCb.DisplayMember = "name"; // Set the DisplayMember to "text" property

            foreach (TipeKamar tipe in tipeKamars)
            {
                tipeKamarCb.Items.Add(tipe); // Add ota to combo box
            }
        }

        private async void getTipeKebersihan()
        {
            HttpData result = await conn.GetTipeKebersihan();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to OTA array
            tipeKebersihans = JsonConvert.DeserializeObject<TipeKebersihan[]>(result.data.ToString());
            kebersihanFilter.Items.Clear();

            // Bind rooms to roomIdCMBox
            kebersihanFilter.DisplayMember = "name"; // Set the DisplayMember to "text" property

            foreach (TipeKebersihan tipe in tipeKebersihans)
            {
                kebersihanFilter.Items.Add(tipe); // Add ota to combo box
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
    }
}
