using Hotel_Management_System.Screens;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Hotel_Management_System.Controllers.BookingsScreen;

namespace Hotel_Management_System.Controllers
{
    public partial class BookingsScreen : Form
    {

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        HttpConnection conn = new HttpConnection();
        OnityConnection onity = new OnityConnection();

        Guest[] guests = new Guest[] { };
        Reservation[] reservasi = new Reservation[] { };
        Room[] rooms = new Room[] { };
        Ota[] otas = new Ota[] { };
        PaymentMethod[] paymentMethods = new PaymentMethod[] { };

        private int durasi_menginap = 1;


        private int roomId;

        public BookingsScreen()
        {
            InitializeComponent();
            //bookingIdField.ReadOnly = false;
            checkIfEmployee();
            //addButton.Enabled = false;
            loadingText.Visible = false;
            kosongText.Visible = false;
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

        private async void populateReservasiComboBoxAsync()
        {
            HttpData result = await conn.GetReservationList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to Guest array
            reservasi = JsonConvert.DeserializeObject<Reservation[]>(result.data.ToString());
            reservasiCb.Items.Clear();

            // Bind rooms to roomIdCMBox
            reservasiCb.DisplayMember = "text"; // Set the DisplayMember to "text" property

            foreach (Reservation data in reservasi)
            {
                reservasiCb.Items.Add(data); // Add guest to combo box
            }
        }

        private async void populateOTAComboBoxAsync()
        {
            HttpData result = await conn.GetOTAList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to OTA array
            otas = JsonConvert.DeserializeObject<Ota[]>(result.data.ToString());
            otaComboBox.Items.Clear();

            // Bind rooms to roomIdCMBox
            otaComboBox.DisplayMember = "label"; // Set the DisplayMember to "text" property

            foreach (Ota ota in otas)
            {
                otaComboBox.Items.Add(ota); // Add ota to combo box
            }
        }

        private async void populatePaymentMethodComboBoxAsync()
        {
            HttpData result = await conn.GetPaymentList();
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to Payment array
            paymentMethods = JsonConvert.DeserializeObject<PaymentMethod[]>(result.data.ToString());
            paymentComboBox.Items.Clear();

            // Bind rooms to roomIdCMBox
            paymentComboBox.DisplayMember = "label"; // Set the DisplayMember to "label" property

            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                paymentComboBox.Items.Add(paymentMethod); // Add payment to combo box
            }
        }

        private async void populateRoomAsync()
        {
            HttpData result = await conn.GetRoomList(true,-1,"VC");
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            // Deserialize JSON string directly to Room array
            rooms = JsonConvert.DeserializeObject<Room[]>(result.data.ToString());

            // Clear existing items in roomIdCMBox
            NoKamarcomboBox.Items.Clear();


            // Bind rooms to roomIdCMBox
            NoKamarcomboBox.DisplayMember = "ROOM NAME";

            //rooms = rooms.

            foreach (Room room in rooms)
            {
                // Add each Room object to roomIdCMBox
                NoKamarcomboBox.Items.Add(room);
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
            //FilterTableCheckinDate.Value = DateTime.Today;

            checkinPicker.Value = DateTime.Today;

            checkoutPicker.Value = DateTime.Today.AddDays(1);


            populateGuestComboBoxAsync();
            populateRoomAsync();
            refreshTable(null);
            populateOTAComboBoxAsync();
            populatePaymentMethodComboBoxAsync();
            populateReservasiComboBoxAsync();
        }

        private async void refreshTable(string date = null)
        {
            loadingText.Visible = true;
            HttpData result = await conn.GetCheckinList(date);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
            bookingTable.DataSource = MyTable;
            loadingText.Visible = false;
        }

        private void FilterTableCheckinDate_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = FilterTableCheckinDate.Value.ToString("yyyy-MM-dd");
            refreshTable(selectedDate);
        }


        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (
                guestIdCMBox.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
                NoKamarcomboBox.SelectedIndex != -1
                )
            {
                // Extract values from form fields
                string checkinId = bookingIdField.Text;

                var selectedRoom = NoKamarcomboBox.SelectedItem as Room;


                string room_product_id = selectedRoom?.ProductId.ToString();
                // Trim non-numeric characters from amountField.Text and depositField.Text
                string harga_total = string.Concat(amountField.Text.Where(char.IsDigit));

                string deposit = string.Concat(depositTextBox1.Text.Where(char.IsDigit));

                string notes = noteTextBox.Text;

                if (paymentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Silahkan pilih metode pembayaran yang di lakukan");
                    return;
                }

                // Call StoreCheckin method
                HttpData result = await conn.UpdateCheckin(checkinId, harga_total, room_product_id, notes, deposit);

                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    guestIdCMBox.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();

                    // Create a new WebBrowser instance
                    //WebBrowser myWebBrowser = new WebBrowser();
                    //myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;

                    //// Get the HTML content from the response
                    //string htmlContent = result.data.receipt.html_content;

                    //// Set the HTML content directly to the WebBrowser
                    //myWebBrowser.DocumentText = htmlContent;

                    //// Print the content
                    //myWebBrowser.Print();
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
            NoKamarcomboBox.SelectedIndex = -1;
            amountField.Text = "";
            depositField.Text = "";
            depositTextBox1.Text = "";
            noteTextBox.Text = "";
            otaComboBox.SelectedIndex = -1;
            paymentComboBox.SelectedIndex = -1;
            reservasiCb.SelectedIndex = -1;
            addButton.Enabled = true;
            NoKamarcomboBox.Visible = true;
            kamarTextbox.Visible = false;
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

        private void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = bookingTable.SelectedRows[0];
                bookingIdField.Text = row.Cells[0].Value.ToString();
                depositTextBox1.Text = row.Cells[1].Value.ToString();
                amountField.Text = row.Cells[2].Value.ToString();
                depositField.Text = row.Cells[3].Value.ToString();
                noteTextBox.Text = row.Cells[12].Value.ToString();

                string guestName = row.Cells[10].Value.ToString();
                string roomName = row.Cells[9].Value.ToString();
                string methodName = row.Cells[5].Value.ToString();
                string otaName = row.Cells[6].Value.ToString();

                string checkinDateVal = row.Cells[7].Value.ToString(); // the format is dd/MM/yyyy
                string checkoutDateVal = row.Cells[11].Value.ToString(); // the format is dd/MM/yyyy

                // Convert the date format from dd/MM/yyyy to DateTime
                DateTime checkinDate = DateTime.ParseExact(checkinDateVal, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime checkoutDate = DateTime.ParseExact(checkoutDateVal, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                // Set the date pickers
                checkinPicker.Value = checkinDate;
                checkoutPicker.Value = checkoutDate;

                // Find and select the guest
                var selectedGuest = guests.FirstOrDefault(guest => guest.Name == guestName);
                if (selectedGuest != null)
                {
                    guestIdCMBox.SelectedItem = selectedGuest; // Assuming guestIdCMBox is data-bound to guest IDs
                }
                else
                {
                    // Handle the case where the guest is not found (optional)
                    MessageBox.Show("Guest not found");
                }

                // Find and select the room
                var selectedRoom = rooms.FirstOrDefault(room => room.Name == roomName);
                if (selectedRoom != null)
                {
                    NoKamarcomboBox.SelectedItem = selectedRoom;
                }
                else
                {
                    //MessageBox.Show("Room not found");
                    kamarTextbox.Visible = true;
                    kamarTextbox.Text = roomName;
                    NoKamarcomboBox.Visible = false;
                }

                // Find and select the payment method
                var selectedMethod = paymentMethods.FirstOrDefault(payment => payment.label == methodName);
                if (selectedMethod != null)
                {
                    paymentComboBox.SelectedItem = selectedMethod;
                }
                else
                {
                    MessageBox.Show("Method not found");
                }

                // Find and select the OTA
                var selectedOta = otas.FirstOrDefault(ota => ota.label == otaName);
                if (selectedOta != null)
                {
                    otaComboBox.SelectedItem = selectedOta;
                }
                else
                {
                    //MessageBox.Show("OTA not found");
                }

                addButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Date format is incorrect. Please check the date format in the data source.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the data.");
                Console.WriteLine(ex.Message);
            }
        }


        private async void addButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            loadingText.Visible = true;
            if (guestIdCMBox.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
                NoKamarcomboBox.SelectedIndex != -1)
                {


                var durasi = (DateTime.Parse(checkoutPicker.Text) - DateTime.Parse(checkinPicker.Text)).Days;
                //if (durasi <= 0)
                //{
                //    MessageBox.Show("Tanggal checkout tidak boleh kurang dari hari ini");
                //    return;
                //}

                // Extract values from form fields
                var selectedGuest = guestIdCMBox.SelectedItem as Guest; 
                var selectedRoom = NoKamarcomboBox.SelectedItem as Room;

                string contact_id = selectedGuest?.Id.ToString();

                string lamainap = durasi.ToString();

                string room_product_id = selectedRoom?.ProductId.ToString();
                // Trim non-numeric characters from amountField.Text and depositField.Text
                string harga_total = string.Concat(amountField.Text.Where(char.IsDigit));
                string payment_amount = string.Concat(depositField.Text.Where(char.IsDigit));
                string deposit = string.Concat(depositTextBox1.Text.Where(char.IsDigit));

                if (paymentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Silahkan pilih metode pembayaran yang di lakukan");
                    return;
                }

                string payment_method = paymentComboBox.SelectedItem.ToString();
                string ota = otaComboBox.SelectedItem == null ? "" : otaComboBox.SelectedItem.ToString();

                string notes = noteTextBox.Text;

                var selectedReservasi = reservasiCb.SelectedItem as Reservation;

                string reservation_id = selectedReservasi?.Id.ToString() ?? "";


                // Call StoreCheckin method
                HttpData result = await conn.StoreCheckin(contact_id, lamainap, room_product_id, harga_total, payment_amount, payment_method, ota, deposit, notes, reservation_id);

                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Booking inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    guestIdCMBox.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();
                    addButton.Enabled = true;
                    populateReservasiComboBoxAsync();
                    populateRoomAsync();

                    //// Create a new WebBrowser instance
                    //WebBrowser myWebBrowser = new WebBrowser();
                    //myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;

                    //// Get the HTML content from the response
                    //string htmlContent = result.data.receipt.html_content;

                    //// Set the HTML content directly to the WebBrowser
                    //myWebBrowser.DocumentText = htmlContent;

                    //// Print the content
                    //myWebBrowser.Print();
                }
                else
                {
                    MessageBox.Show(result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadingText.Visible = false;
                    addButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loadingText.Visible = false;
                addButton.Enabled = true;
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
            if (NoKamarcomboBox.SelectedItem is Room selectedRoom)
            {
                // Assuming unit_price is a numeric type like decimal, parse it accordingly
                if (decimal.TryParse(selectedRoom.SellingPrice, out decimal price))
                {
                    if(reservasiCb.SelectedItem == null)
                    {
                        amountField.Text = price.ToString(); // Set amountField to room's unit price
                        amountField.ReadOnly = false;
                        // Call CalculateAmount to update total amount based on selected room and dates
                        CalculateAmount();
                    }
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
            if (reservasiCb.SelectedItem == null)
            CalculateAmount();
        }

        private void checkoutPicker_ValueChanged(object sender, EventArgs e)
        {
            if (reservasiCb.SelectedItem == null)
                CalculateAmount();
        }

        private void CalculateAmount()
        {
            Room selectedRoom = (Room)NoKamarcomboBox.SelectedItem;
            if (selectedRoom == null)
            {
                return; // Handle case where no room is selected
            }

            DateTime checkinDate = checkinPicker.Value.Date;
            DateTime checkoutDate = checkoutPicker.Value.Date;

            // Calculate days difference
            int daysDifference = (int)(checkoutDate - checkinDate).TotalDays; // Count the check-in day as well

            // If checkin and checkout are the same day, daysDifference should be 1
            if (daysDifference < 1)
            {
                daysDifference = 1; // Minimum of 1 day
            }

            // Clean unit_price and parse to decimal
            string unitPriceString = selectedRoom.SellingPrice.Replace(",", "").Replace(".", "").Trim();
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
            [JsonProperty("ID")]
            public int Id { get; set; }

            [JsonProperty("NAME")]
            public string Name { get; set; }

            [JsonProperty("NO HP")]
            public string Hp { get; set; }

            public override string ToString()
            {
                return Name+" - "+Hp; // Display the guest name in combobox
            }
        }

        public class Reservation
        {
            [JsonProperty("ID")]
            public int Id { get; set; }

            [JsonProperty("NAMA")]
            public string Name { get; set; }

            [JsonProperty("CHECK IN")]
            public string Checkin { get; set; }

            [JsonProperty("CHECK OUT")]
            public string Checkout { get; set; }


            [JsonProperty("LAMA MENGINAP")]
            public int Durasi { get; set; }

            [JsonProperty("CID")]
            public int Contact_id { get; set; }

            [JsonProperty("OTA")]
            public string Ota { get; set; }

            [JsonProperty("HARGA")]
            public int Harga { get; set; }

            [JsonProperty("TIPE KAMAR")]
            public string tipe { get; set; }


            [JsonProperty("PEMBAYARAN")]
            public string metode_pembayaran { get; set; }

            [JsonProperty("DEPOSIT")]
            public int deposit { get; set; }

            public override string ToString()
            {
                string id = "(" + Id.ToString() + ")";
                return Name+" "+id; // Display the guest name in combobox
            }
        }

        public class Room
        {
            [JsonProperty("id")]
            public int ProductId { get; set; }

            [JsonProperty("ROOM NAME")]
            public string Name { get; set; }

            [JsonProperty("TIPE KAMAR")]
            public string Type { get; set; }

            [JsonProperty("selling_price")]
            public string SellingPrice { get; set; }

            [JsonProperty("PRICE")]
            public string UnitPrice { get; set; }

            [JsonProperty("TODAY AVAILABLE")]
            public string available { get; set; }

            [JsonProperty("SKU")]
            public string sku { get; set; }

            // Optional: You can keep the ToString method for displaying the room name
            public override string ToString()
            {
                string status = available == "1" ? "V" : "O";

                return Name+" - "+Type+" ("+status+")"; // Display the room name in combobox
            }
        }

        public class PaymentMethod
        {
            public string label;
            public string value;

            public override string ToString()
            {
                return label;
            }
        }

        public class Ota
        {
            public string label;
            public string value;

            public override string ToString()
            {
                return label;
            }
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

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            if (NoKamarcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Silahkan pilih data pada tabel terlebih dahulu");
                return;
            }

            var selectedRoom = NoKamarcomboBox.SelectedItem as Room;
            var selectedGuest = guestIdCMBox.SelectedItem as Guest;

            if (selectedRoom == null || selectedGuest == null)
            {
                MessageBox.Show("Silahkan pilih data yang valid pada tabel.");
                return;
            }

            string contact_id = selectedGuest.Id.ToString();
            string contact_name = selectedGuest.Name.ToString();
            string checkin = checkinPicker.Text;
            string checkout = checkoutPicker.Text;
            string room_product_id = selectedRoom.ProductId.ToString();

            //var createCardTask = Task.Run(() => onity.createCard(selectedRoom.sku, durasi_menginap));
            var createCardTask = Task.Run(() => onity.createCard(selectedRoom.sku, DateTime.Parse(checkoutPicker.Text)));
            var logCreateCardTask = conn.LogCreateCard(contact_name, checkin, checkout, room_product_id, contact_id);

            var createCardResult = await createCardTask;

            if (createCardResult)
            {
                MessageBox.Show("Berhasil");

                var logResult = await logCreateCardTask;

                if (logResult.status)
                {
                    MessageBox.Show("Card written successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    guestIdCMBox.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();
                    addButton.Enabled = true;
                    populateReservasiComboBoxAsync();
                    populateRoomAsync();
                }
                else
                {
                    MessageBox.Show(logResult.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadingText.Visible = false;
                    addButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Periksa Koneksi Onity encoder IP dan Port.");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Masukan kartu Anda...");
            string result = onity.readCard();
            MessageBox.Show("Hasil Reader : "+result);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void otaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void depositTextBox1_TextChanged(object sender, EventArgs e)
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

        private void reservasiCb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (reservasiCb.SelectedItem is Reservation selectedReservasi)
            {
                // Assuming unit_price is a numeric type like decimal, parse it accordingly
                if (selectedReservasi != null)
                {
                    amountField.Text = selectedReservasi.Harga.ToString(); // Set amountField to room's unit price
                    amountField.ReadOnly = false;

                    // Find and select the guest
                    var selectedGuest = guests.FirstOrDefault(guest => selectedReservasi.Contact_id == guest.Id);
                    if (selectedGuest != null)
                    {
                        guestIdCMBox.SelectedItem = selectedGuest; // Assuming guestIdCMBox is data-bound to guest IDs
                    }
                    else
                    {
                        // Handle the case where the guest is not found (optional)
                        MessageBox.Show("Guest not found");
                    }

                    checkinPicker.Value = DateTime.Parse(selectedReservasi.Checkin);
                    checkoutPicker.Value = DateTime.Parse(selectedReservasi.Checkout);

                    // Find and select the guest
                    var otaSelected = otas.FirstOrDefault(ota => selectedReservasi.Ota == ota.label);
                    if (otaSelected != null)
                    {
                        otaComboBox.SelectedItem = otaSelected; // Assuming guestIdCMBox is data-bound to guest IDs
                    }
                    else
                    {
                        // Handle the case where the guest is not found (optional)
                        //MessageBox.Show("OTA not found");
                    }

                    amountField.Text = selectedReservasi.Harga.ToString();

                    depositTextBox1.Text = selectedReservasi.deposit.ToString();

                    // Find and select the guest
                    var paymentSelected = paymentMethods.FirstOrDefault(data => selectedReservasi.metode_pembayaran == data.label);
                    if (paymentSelected != null)
                    {
                        paymentComboBox.SelectedItem = paymentSelected; // Assuming guestIdCMBox is data-bound to guest IDs
                    }

                    if (selectedReservasi.tipe != null && selectedReservasi.tipe != "")
                    {
                        noteTextBox.Text = selectedReservasi.tipe;
                    }

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            refreshTable(null);
        }

        private void printCard_Click(object sender, EventArgs e)
        {
            string id = bookingIdField.Text;
            string link = "https://development.norapos.com/api/hotel/print?checkin=1&id=" + id;
            Form2 form2 = new Form2(link);
            form2.Show();
        }
    }
}
