using Hotel_Management_System.Screens;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hotel_Management_System.Controllers
{
    public partial class BookingsScreen : Form
    {

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        HttpConnection conn = new HttpConnection();
        OnityConnection onity = new OnityConnection();

        Guest[] guests = new Guest[] { };
        Room[] rooms = new Room[] { };

        private int durasi_menginap = 1;


        private int roomId;

        public BookingsScreen()
        {
            InitializeComponent();
            //bookingIdField.ReadOnly = false;
            checkIfEmployee();
            //addButton.Enabled = false;
        }

        private void checkIfEmployee()
        {
            if (Statics.employeeIdTKN.Equals(0))
            {

                Console.WriteLine(Statics.employeeIdTKN.Equals(""));
                //addButton.Enabled = false;
                //updateButton.Enabled = false;
                //deleteButton.Enabled = false;
            }
        }

        private void populateGuestComboBox()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT GuestId from Hotels.Guests WHERE HotelId = " + Statics.hotelIdTKN + " AND Status = 'Not Reserved'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                guestIdCMBox.Items.Add(dr["GuestId"]);
            }
            con.Close();
        }
        private async void populateGuestComboBoxAsync()
        {
            HttpData result = await conn.GetCustomerList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to Guest array
            guests = JsonConvert.DeserializeObject<Guest[]>(result.data.ToString());
            guestIdCMBox.Items.Clear();

            // Bind rooms to roomIdCMBox
            guestIdCMBox.DisplayMember = "text"; // Set the DisplayMember to "text" property

            foreach (Guest guest in guests)
            {
                guestIdCMBox.Items.Add(guest); // Add guest to combo box
            }
        }

        private void populateRoomId()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT RoomId from Rooms.Room WHERE RoomTypeId = " + roomId + " AND Available = 'Yes' AND HotelId = " + Statics.hotelIdTKN;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                roomIdCMBox.Items.Add(dr["RoomId"]);
            }
            con.Close();
        }

        private async void populateRoomAsync()
        {
            HttpData result = await conn.GetRoomList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to Room array
            rooms = JsonConvert.DeserializeObject<Room[]>(result.data.ToString());

            // Clear existing items in roomIdCMBox
            roomIdCMBox.Items.Clear();


            // Bind rooms to roomIdCMBox
            roomIdCMBox.DisplayMember = "name"; // Set the DisplayMember to "name" property

            foreach (Room room in rooms)
            {
                // Add each Room object to roomIdCMBox
                roomIdCMBox.Items.Add(room);
            }
        }

        //private void populateDiscountId()
        //{
        //    SqlConnection con = dc.getConnection();
        //    con.Open();
        //    query = "SELECT DiscountId from Bookings.Discount WHERE EmployeeId = " + Statics.employeeIdTKN;
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        promoIdCMBox.Items.Add(dr["DiscountId"]);
        //    }
        //    con.Close();
        //}
        private void populateTable()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT BookingId AS ID, BookingDate AS BookingDate, CheckInDate, CheckOutDate, GuestId, DiscountId, EmployeeId, Status FROM Bookings.Booking WHERE HotelId = " + Statics.hotelIdTKN;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bookingTable.DataSource = ds.Tables[0];
            con.Close();
        }

        private void BookingsScreen_Load(object sender, EventArgs e)
        {
            populateGuestComboBoxAsync();
            populateRoomAsync();
            refreshTable();
        }

        private async void refreshTable(string date = null)
        {
            HttpData result = await conn.GetCheckinList(date);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
            bookingTable.DataSource = MyTable;
        }

        private void FilterTableCheckinDate_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = FilterTableCheckinDate.Value.ToString("yyyy-MM-dd");
            refreshTable(selectedDate);
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            fetchBookingRecord(0);
        }


        private void clearFields()
        {
            //bookingIdField.Text = "";
            guestIdCMBox.SelectedIndex = -1;
            checkinPicker.Text = "";
            checkoutPicker.Text = "";
            roomIdCMBox.SelectedIndex = -1;
            amountField.Text = "";
        }

        //private void addButton_Click(object sender, EventArgs e)
        //{
        //    if (guestIdCMBox.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
        //        roomIdCMBox.SelectedIndex != -1 )
        //    {
        //        //query = "INSERT INTO Bookings.Booking (BookingDate, StayDuration, CheckInDate, CheckOutDate, BookingAmount, HotelId, EmployeeId, GuestId, Status) VALUES (FORMAT(GETDATE(), 'yyyy-MM-dd'), DATEDIFF(day, '" + checkinPicker.Text + "', '" + checkoutPicker.Text + "'),'" + checkinPicker.Text + "', '" + checkoutPicker.Text + "', " + bookingAmount + ", " + Statics.hotelIdTKN + ", " + Statics.employeeIdTKN + ", " + guestIdCMBox.Text + ", 'Checkin'" + ")";
        //        //dc.setData(query, "Booking inserted successfully!");
        //        //int j = getRecentBookingId();
        //        //query = "UPDATE Hotels.Guests SET Status = 'Reserved' WHERE GuestId = " + guestIdCMBox.Text;
        //        //dc.setData(query, "");
        //        //query = "UPDATE Rooms.Room SET Available = 'No' WHERE RoomId = " + int.Parse(roomIdCMBox.Text);
        //        //dc.setData(query, "");
        //        //insertInRoomBooked(j, int.Parse(roomIdCMBox.Text));
        //        //clearFields();
        //        //guestIdCMBox.Items.Clear();
        //        //populateGuestComboBox();
        //        //populateTable();
        //    }
        //    else
        //    {
        //        MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // This method will handle the DocumentCompleted event of the WebBrowser control
            WebBrowser webBrowser = sender as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.Print(); // Print the document when it is fully loaded
            }
        }


        private async void addButton_Click(object sender, EventArgs e)
        {
            if (guestIdCMBox.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
                roomIdCMBox.SelectedIndex != -1)
            {
                // Extract values from form fields
                var selectedGuest = guestIdCMBox.SelectedItem as Guest; 
                var selectedRoom = roomIdCMBox.SelectedItem as Room;

                string contact_id = selectedGuest?.id.ToString();
                string lamainap = (DateTime.Parse(checkoutPicker.Text) - DateTime.Parse(checkinPicker.Text)).Days.ToString();
                string room_product_id = selectedRoom?.product_id.ToString();
                string harga_total = amountField.Text; // Assuming amountField contains the total price
                string payment_amount = depositField.Text;

                // Call StoreCheckin method
                HttpData result = await conn.StoreCheckin(contact_id, lamainap, room_product_id, harga_total, payment_amount);

                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Booking inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    guestIdCMBox.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();

                    // Create a new WebBrowser instance
                    WebBrowser myWebBrowser = new WebBrowser();
                    myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;

                    // Get the HTML content from the response
                    string htmlContent = result.data.receipt.html_content;

                    // Set the HTML content directly to the WebBrowser
                    myWebBrowser.DocumentText = htmlContent;

                    // Print the content
                    myWebBrowser.Print();
                }
                else
                {
                    MessageBox.Show(result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private int getRecentBookingId()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT MAX(BookingId) FROM Bookings.Booking";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int recentId = 0;
            while (dr.Read())
            {
                recentId = dr.GetInt32(0);
            }
            return recentId;
        }
        private int getAmount()
        {
            int i = 0;
            int diff = getDateDifference() + 1;
            int cost = getCost();
            float rate = getDiscountRate();
            if (rate != 0)
            {
                rate = (float)getDiscountRate() / 100;
                i = (int)(((diff * cost)) * rate);
            }
            else
            {
                i = (int)((diff * cost));
            }
            return i;
        }


        private int getDiscountRate()
        {
            int rate = 0;
            //if (promoIdCMBox.SelectedIndex != -1 && promoIdCMBox.Text != "")
            //{
            //    SqlConnection con = dc.getConnection();
            //    con.Open();
            //    query = "SELECT DiscountRate AS DR FROM Bookings.Discount WHERE DiscountId = " + promoIdCMBox.Text;
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        rate = dr.GetInt32(0);
            //    }
            //    rate = 100 - rate;
            //}
            //else
            //{
            //    rate = 0;
            //}
            return rate;
        }

        private int getCost()
        {
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //query = "SELECT COST FROM Rooms.RoomType WHERE RoomTypeId =  " + getIdFromTypeName();
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            int cost = 0;
            //while (dr.Read())
            //{
            //cost  = dr.GetInt32(0);
            //}
            return cost;
        }

        private int getDateDifference()
        {
            DateTime checkIn = checkinPicker.Value;
            DateTime checkOut = checkoutPicker.Value;
            TimeSpan ts = checkOut - checkIn;
            return ts.Days;
        }

        private void insertInRoomBooked(int a, int b)
        {
            SqlConnection connection = dc.getConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            String q = "INSERT INTO Rooms.RoomBooked VALUES (" + a + ", " + b + ")";
            cmd.CommandText = q;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            amountField.Text = getAmount().ToString();
            addButton.Enabled = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //if (bookingIdField.Text == "")
            //{
            //    MessageBox.Show("Please enter id to update record.", "Missing Info", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    query = "UPDATE Bookings.Booking SET CheckInDate = '" + checkinPicker.Text + "', CheckOutDate = '" + checkoutPicker.Text + "' WHERE BookingId = " + int.Parse(bookingIdField.Text);
            //    dc.setData(query, "Record updated successfully.");
            //    clearFields();
            //    populateTable();
            //}
        }

        private void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //fetchBookingRecord(1);
            durasi_menginap = int.Parse( bookingTable.SelectedRows[0].Cells[6].Value.ToString() );
            string pelanggan = bookingTable.SelectedRows[0].Cells[8].Value.ToString();
            int dataIndex = Array.FindIndex(guests, c => c.text.ToString().Contains(pelanggan));
            guestIdCMBox.SelectedIndex = dataIndex;
            string no_kamar = bookingTable.SelectedRows[0].Cells[7].Value.ToString();
            int indexKamar = Array.FindIndex(rooms, c => c.name.ToString() == no_kamar);
            roomIdCMBox.SelectedIndex = indexKamar;
        }

        private void fetchBookingRecord(int i)
        {
            String bId = "";
            if (i == 1)
            {
                bId = bookingTable.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                //bId = bookingIdField.Text;
            }

            Console.WriteLine(bId);

            if (bId == "")
            {
                MessageBox.Show("Please enter id to search record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                bool temp = false;
                SqlConnection con = dc.getConnection();
                con.Open();
                query = "SELECT * FROM Bookings.Booking WHERE BookingId = " + bId;
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //checkinPicker.Text = DateTime.Parse(dr.GetString(3)).ToString();
                    //checkoutPicker.Text = DateTime.Parse(dr.GetString(4)).ToString();
                    //bookingIdField.Text = bId;
                    guestIdCMBox.Text = dr.GetSqlInt32(8).ToString();
                    //getRoomId();
                    //int id = getRoomId();
                    //roomTypeCMBox.Text = getTypeNameFromId(id);
                    //promoIdCMBox.Text = dr.GetSqlInt32(9).ToString();
                    amountField.Text = dr.GetSqlInt32(5).ToString();
                    temp = true;
                }
                if (temp == false && i == 0)
                    MessageBox.Show("No record found.");
                con.Close();
            }
        }

        private String getTypeNameFromId(int id)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT Name from Rooms.RoomType WHERE RoomTypeId = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            String roomType = "";
            while (dr.Read())
            {
                roomType = dr.GetString(0);
            }
            return roomType;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //if (bookingIdField.Text == "")
            //{
            //    MessageBox.Show("Please enter id to delete.", "Missing Info", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    int bId = int.Parse(bookingIdField.Text);
            //    int gId = getGuestIdS(bId);
            //    bool check = checkBookingStatus(bId);
            //    if (check == true)
            //    {
            //        query = "UPDATE Hotels.Guests SET Status = 'Not Reserved' WHERE GuestId = " + gId;
            //        dc.setData(query, "");
            //        int a = getRoomId();
            //        query = "UPDATE Rooms.Room SET Available = 'Yes' WHERE RoomId = " + a;
            //        dc.setData(query, "");
            //        delServiceUsed();
            //        query = "DELETE FROM Bookings.Booking WHERE BookingId = " + bId;
            //        dc.setData(query, "Record deleted successfully.");
            //        clearFields();
            //        populateTable();
            //    }
            //    else
            //    {
            //        MessageBox.Show("You cannot delete a booking if guest has already checkout.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //}
        }

        private bool checkBookingStatus(int bid)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT Status from Bookings.Booking WHERE BookingId = " + bid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            String st = "";
            while (dr.Read())
            {
                st = dr.GetString(0);
            }
            if (st == "Checkout")
            {
                return false;
            }
            return true;
        }

        private int getGuestIdS(int bid)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT GuestId from Bookings.Booking WHERE BookingId = " + bid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            guestIdCMBox.Text = id.ToString();
            return id;
        }

        private void delServiceUsed()
        {
            //query = "DELETE FROM HotelService.ServicesUsed WHERE BookingId = " + bookingIdField.Text;
            //dc.setData(query, "");
        }

        //private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (filterCMBox.Text == "All")
        //    {
        //        populateTable();
        //    }
        //    else if (filterCMBox.Text == "Checkin")
        //    {
        //        populateWithCheckIn();
        //    }
        //    else if (filterCMBox.Text == "Checkout")
        //    {
        //        populateWithCheckOut();
        //    }
        //}

        private void populateWithCheckIn()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT BookingId AS ID, BookingDate AS BookingDate, CheckInDate, CheckOutDate, GuestId, DiscountId, EmployeeId, Status FROM Bookings.Booking WHERE Status = 'Checkin' AND HotelId = " + Statics.hotelIdTKN;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bookingTable.DataSource = ds.Tables[0];
            con.Close();
        }

        private void populateWithCheckOut()
        {

            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT BookingId AS ID, BookingDate AS BookingDate, CheckInDate, CheckOutDate, GuestId, DiscountId, EmployeeId, Status FROM Bookings.Booking WHERE Status = 'Checkout' AND HotelId = " + Statics.hotelIdTKN;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bookingTable.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void amountField_TextChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Save the current cursor position and text length
            int cursorPosition = textBox.SelectionStart;
            int originalTextLength = textBox.Text.Length;

            // Remove any non-numeric characters
            string numericText = string.Concat(textBox.Text.Where(char.IsDigit));

            if (decimal.TryParse(numericText, out decimal value))
            {
                // Format the value as currency
                string formattedText = string.Format("{0:N0}", value);

                // Update the text only if it's different to avoid resetting the cursor position unnecessarily
                if (textBox.Text != formattedText)
                {
                    textBox.Text = formattedText;

                    // Calculate the new cursor position
                    int newTextLength = textBox.Text.Length;
                    int cursorDelta = newTextLength - originalTextLength;
                    int newCursorPosition = cursorPosition + cursorDelta;

                    // Set the cursor position within the valid range
                    textBox.SelectionStart = Math.Max(0, Math.Min(newCursorPosition, newTextLength));
                }
            }
        }


        private void depositField_TextChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Save the current cursor position and text length
            int cursorPosition = textBox.SelectionStart;
            int originalTextLength = textBox.Text.Length;

            // Remove any non-numeric characters
            string numericText = string.Concat(textBox.Text.Where(char.IsDigit));

            if (decimal.TryParse(numericText, out decimal value))
            {
                // Format the value as currency
                string formattedText = string.Format("{0:N0}", value);

                // Update the text only if it's different to avoid resetting the cursor position unnecessarily
                if (textBox.Text != formattedText)
                {
                    textBox.Text = formattedText;

                    // Calculate the new cursor position
                    int newTextLength = textBox.Text.Length;
                    int cursorDelta = newTextLength - originalTextLength;
                    int newCursorPosition = cursorPosition + cursorDelta;

                    // Set the cursor position within the valid range
                    textBox.SelectionStart = Math.Max(0, Math.Min(newCursorPosition, newTextLength));
                }
            }
        }


        private void roomIdCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roomIdCMBox.SelectedItem is Room selectedRoom)
            {
                // Assuming unit_price is a numeric type like decimal, parse it accordingly
                if (decimal.TryParse(selectedRoom.unit_price, out decimal price))
                {
                    amountField.Text = price.ToString(); // Set amountField to room's unit price
                    amountField.ReadOnly = false;

                    // Call CalculateAmount to update total amount based on selected room and dates
                    CalculateAmount();
                }
                else
                {
                    amountField.Text = "0"; // Handle default case if parsing fails
                    amountField.ReadOnly = false;
                }
            }
            else
            {
                amountField.Text = "0";
                amountField.ReadOnly = false;
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkinPicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void checkoutPicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            Room selectedRoom = (Room)roomIdCMBox.SelectedItem;
            if (selectedRoom == null)
            {
                return; // Handle case where no room is selected
            }

            DateTime checkinDate = checkinPicker.Value.Date;
            DateTime checkoutDate = checkoutPicker.Value.Date;

            // Calculate days difference
            int daysDifference = (int)(checkoutDate - checkinDate).TotalDays + 1; // Count the check-in day as well

            // If checkin and checkout are the same day, daysDifference should be 1
            if (daysDifference < 1)
            {
                daysDifference = 1; // Minimum of 1 day
            }

            // Clean unit_price and parse to decimal
            string unitPriceString = selectedRoom.unit_price.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(unitPriceString, out decimal price))
            {
                return; // Handle parsing failure
            }

            decimal totalAmount = price * daysDifference;

            // Update amountField with formatted currency
            amountField.Text = totalAmount.ToString("N0"); // Ensure consistent formatting

            // Optionally, trigger any necessary validation or event handling
        }

        public class Guest
        {
            public string id;
            public string text;

            public override string ToString()
            {
                return text; // Display the guest name in combobox
            }
        }

        public class Room
        {
            public string product_id;
            public string name;
            public string type;
            public string selling_price;
            public string unit_price;
            public string sub_sku;


            public override string ToString()
            {
                return name; // Display the room name in combobox
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var selectedRoom = roomIdCMBox.SelectedItem as Room;
            Boolean res = onity.createCard(selectedRoom.sub_sku, durasi_menginap);
            if (res)
            {
                MessageBox.Show("Berhasil");
                return;
            }
            MessageBox.Show("Periksa Koneksi Onity encoder IP dan Port.");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Masukan kartu Anda...");
            string result = onity.readCard();
            MessageBox.Show("Hasil Reader : "+result);
        }
    }
}
