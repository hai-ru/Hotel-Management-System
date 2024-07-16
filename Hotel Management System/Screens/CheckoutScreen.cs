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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Controllers
{
    public partial class CheckoutScreen : Form
    {

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        DateTime filterDate = DateTime.Today;

        HttpConnection conn = new HttpConnection();

        public CheckoutScreen()
        {
            InitializeComponent();
            //paymentIdField.ReadOnly = false;
            checkIfEmployee();
        }

        private void checkIfEmployee()
        {
            if (Statics.employeeIdTKN.Equals(0))
            {
                payButton.Enabled = false;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            fetchData(0);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.loadForm(new HotelIntroScreen());
        }

        private void populateTable()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT PaymentId AS ID, PaymentStatus AS Status, PaymentType AS TYPE, PaymentAmount AS Amount, BookingId FROM Bookings.Payments WHERE BookingId IN (SELECT BookingId FROM Bookings.Booking WHERE HotelId = " + Statics.hotelIdTKN + ")";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            checkoutTable.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clearFields()
        {
            paymentIdField.Text = "";
            namaField.Text = "";
            depositField.Text = "";
            totalTagihanField.Text = "";
            sisaField.Text = "";
        }

        private void populateBookingIdCmbox()
        {
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //query = "SELECT BookingId FROM Bookings.Booking WHERE Status = 'Checkin' AND HotelId = " + Statics.hotelIdTKN;
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    bookingIdCMBox.Items.Add(dr["BookingId"]);
            //}
            //con.Close();
        }


        private void CheckoutScreen_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            filterDate = today;
            FilterTableCheckoutDate.Value = today;
            refreshTable();
        }

        private async void refreshTable()
        {
            string date = filterDate.ToString("yyyy-MM-dd");
            HttpData result = await conn.GetCheckinList(date);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            DataTable MyTable = JsonConvert.DeserializeObject<DataTable>(result.data.ToString());
            checkoutTable.DataSource = MyTable;


        }

        private void bookingIdCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = int.Parse(bookingIdCMBox.Text);
            //SqlConnection con = dc.getConnection();
            //con.Open();
            //query = "SELECT BookingAmount From Bookings.Booking WHERE BookingId = " + id;
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    //amountField.Text = dr.GetSqlInt32(0).ToString();
            //}
        }

        private async void payButton_Click(object sender, EventArgs e)
        {
            HttpData result = await conn.StoreCheckout(
                paymentIdField.Text,
                sisaField.Text,
                catatanField.Text,
                depositReturnField.Text
            );
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }

            MessageBox.Show(result.message);
            refreshTable();
        }


        private void changeBookingStatus(int bid)
        {
            query = "UPDATE Bookings.Booking SET Status = 'Checkout' WHERE BookingId = " + bid;
            dc.setData(query, "");
        }

        private void delServiceUsed(int id)
        {
            query = "DELETE FROM HotelService.ServicesUsed WHERE BookingId = " + id;
            dc.setData(query, "");
        }

        private int getRoomId(int bid)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT RoomId from Rooms.RoomBooked WHERE BookingId = " + bid;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            return id;
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
            return id;
        }

        private void checkoutTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //populateTable();
            //fetchData(1);
            paymentIdField.Text = checkoutTable.SelectedRows[0].Cells[0].Value.ToString();
            namaField.Text = checkoutTable.SelectedRows[0].Cells[8].Value.ToString();
            depositField.Text = checkoutTable.SelectedRows[0].Cells[3].Value.ToString();
            totalTagihanField.Text = checkoutTable.SelectedRows[0].Cells[2].Value.ToString();
            sisaField.Text = checkoutTable.SelectedRows[0].Cells[4].Value.ToString();
            payButton.Enabled = true;
        }

        private void fetchData(int i)
        {
            String pId;
            if (i == 1)
            {
                pId = checkoutTable.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                pId = paymentIdField.Text;
            }

            Console.WriteLine(pId);

            if (pId == "")
            {
                MessageBox.Show("Please enter id to search record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                bool temp = false;
                SqlConnection con = dc.getConnection();
                con.Open();
                query = "SELECT * FROM Bookings.Payments WHERE PaymentId = " + pId;
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    paymentIdField.Text = dr.GetInt32(0).ToString();
                    //statusField.Text = dr.GetString(1);
                    //paymentTypeCmbox.Text = dr.GetString(2);
                    //amountField.Text = dr.GetInt32(3).ToString();
                    //bookingIdCMBox.Text = dr.GetInt32(4).ToString();
                    temp = true;
                }
                if (temp == false && i == 0)
                    MessageBox.Show("No record found.");
                con.Close();
            }
        }

        private void FilterTableCheckoutDate_ValueChanged(object sender, EventArgs e)
        {
            filterDate = FilterTableCheckoutDate.Value;
            refreshTable();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void depositField_TextChanged(object sender, EventArgs e)
        {

        }

        private void depositReturnField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
