using Hotel_Management_System.Screens;
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
using System.Windows.Forms;

namespace Hotel_Management_System.Controllers
{
    public partial class BookingsScreen : Form
    {

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        HttpConnection conn = new HttpConnection();

        private int roomId;

        public BookingsScreen()
        {
            InitializeComponent();
            bookingIdField.ReadOnly = false;
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
            Guest[] guests = JsonConvert.DeserializeObject<Guest[]>(result.data.ToString());
            guestIdCMBox.Items.Clear();

            foreach (Guest guest in guests)
            {
                guestIdCMBox.Items.Add(guest.text); // Add guest ID to combo box
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
            Room[] rooms = JsonConvert.DeserializeObject<Room[]>(result.data.ToString());

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
            //populateTable();
            //populateCheckBox();
            //populateGuestComboBox();
            //popuklateRoomType();
            //populateDiscountId();

            populateGuestComboBoxAsync();
            populateRoomAsync();
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
            bookingIdField.Text = "";
            guestIdCMBox.SelectedIndex = -1;
            checkinPicker.Text = "";
            checkoutPicker.Text = "";
            roomIdCMBox.SelectedIndex = -1;
            amountField.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //if (guestIdCMBox.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
            //    roomIdCMBox.SelectedIndex != -1 )
            //{
            //    query = "INSERT INTO Bookings.Booking (BookingDate, StayDuration, CheckInDate, CheckOutDate, BookingAmount, HotelId, EmployeeId, GuestId, Status) VALUES (FORMAT(GETDATE(), 'yyyy-MM-dd'), DATEDIFF(day, '" + checkinPicker.Text + "', '" + checkoutPicker.Text + "'),'" + checkinPicker.Text + "', '" + checkoutPicker.Text + "', " + bookingAmount + ", " + Statics.hotelIdTKN + ", " + Statics.employeeIdTKN + ", " + guestIdCMBox.Text + ", 'Checkin'" + ")";
            //    dc.setData(query, "Booking inserted successfully!");
            //    int j = getRecentBookingId();
            //    query = "UPDATE Hotels.Guests SET Status = 'Reserved' WHERE GuestId = " + guestIdCMBox.Text;
            //    dc.setData(query, "");
            //    query = "UPDATE Rooms.Room SET Available = 'No' WHERE RoomId = " + int.Parse(roomIdCMBox.Text);
            //    dc.setData(query, "");
            //    insertInRoomBooked(j, int.Parse(roomIdCMBox.Text));
            //    clearFields();
            //    guestIdCMBox.Items.Clear();
            //    populateGuestComboBox();
            //    populateTable();
            //}
            //else
            //{
            //    MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
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
            if (bookingIdField.Text == "")
            {
                MessageBox.Show("Please enter id to update record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                query = "UPDATE Bookings.Booking SET CheckInDate = '" + checkinPicker.Text + "', CheckOutDate = '" + checkoutPicker.Text + "' WHERE BookingId = " + int.Parse(bookingIdField.Text);
                dc.setData(query, "Record updated successfully.");
                clearFields();
                populateTable();
            }
        }

        private void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fetchBookingRecord(1);
        }

        private void fetchBookingRecord(int i)
        {
            String bId;
            if (i == 1)
            {
                bId = bookingTable.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                bId = bookingIdField.Text;
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
                    bookingIdField.Text = bId;
                    guestIdCMBox.Text = dr.GetSqlInt32(8).ToString();
                    getRoomId();
                    int id = getRoomId();
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

        private int getRoomId()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT RoomId from Rooms.RoomBooked WHERE BookingId = " + bookingIdField.Text;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            roomIdCMBox.Text = id.ToString();
            return id;
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
            if (bookingIdField.Text == "")
            {
                MessageBox.Show("Please enter id to delete.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                int bId = int.Parse(bookingIdField.Text);
                int gId = getGuestIdS(bId);
                bool check = checkBookingStatus(bId);
                if (check == true)
                {
                    query = "UPDATE Hotels.Guests SET Status = 'Not Reserved' WHERE GuestId = " + gId;
                    dc.setData(query, "");
                    int a = getRoomId();
                    query = "UPDATE Rooms.Room SET Available = 'Yes' WHERE RoomId = " + a;
                    dc.setData(query, "");
                    delServiceUsed();
                    query = "DELETE FROM Bookings.Booking WHERE BookingId = " + bId;
                    dc.setData(query, "Record deleted successfully.");
                    clearFields();
                    populateTable();
                }
                else
                {
                    MessageBox.Show("You cannot delete a booking if guest has already checkout.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
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
            query = "DELETE FROM HotelService.ServicesUsed WHERE BookingId = " + bookingIdField.Text;
            dc.setData(query, "");
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterCMBox.Text == "All")
            {
                populateTable();
            }
            else if (filterCMBox.Text == "Checkin")
            {
                populateWithCheckIn();
            }
            else if (filterCMBox.Text == "Checkout")
            {
                populateWithCheckOut();
            }
        }

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

        }

        private void roomIdCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roomIdCMBox.SelectedItem is Room selectedRoom)
            {
                // Assuming unit_price is a numeric type like float or decimal, parse it accordingly
                if (decimal.TryParse(selectedRoom.unit_price, out decimal price))
                {
                    amountField.Text = price.ToString(); // Set amountField to room's unit price
                }
                else
                {
                    amountField.Text = "0"; // Handle default case if parsing fails
                }
            }
        }

        public class Guest
        {
            public string id;
            public string text;
        }

        public class Room
        {
            public string product_id;
            public string name;
            public string type;
            public string selling_price;
            public string unit_price;
        }
    }
}
