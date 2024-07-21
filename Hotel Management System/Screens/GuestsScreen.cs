using Hotel_Management_System.Screens;
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
using Newtonsoft.Json;

namespace Hotel_Management_System.Controllers
{
    public partial class GuestsScreen : Form
    {

        HttpConnection conn = new HttpConnection();

        DatabaseConnection dc = new DatabaseConnection();
        String query;

        private int id;
        private String fname;
        private String lname;
        private String contact;
        private String email;
        private String cnic;
        private String passNum;
        private String city;
        private String zip;
        private String street;
        private String address;

        public GuestsScreen()
        {
            InitializeComponent();
            guestIdField.ReadOnly = false;
            //checkIfEmployee();
        }

        private void checkIfEmployee()
        {
            if (Statics.employeeIdTKN.Equals(0))
            {
                //addButton.Enabled = false;
                //updateButton.Enabled = false;
                //deleteButton.Enabled = false;
            }
        }


        private void populateTable()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            String query = "SELECT GuestId AS ID, GuestFirstName AS FName, GuestLastName AS LName, GuestEmailAddress AS Email, GuestContactNumber AS Contact, AddressLine AS Address, City, Zip FROM Hotels.Guests WHERE HotelId = " + Statics.hotelIdTKN;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guestTable.DataSource = ds.Tables[0];
            con.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.loadForm(new HotelIntroScreen());
        }

        private void clearFields()
        {
            guestIdField.Text = "";
            namaField.Text = "";
            numberField.Text = "";
            alamatField.Text = "";
            cityField.Text = "";
            provinsiField.Text = "";
            nikField.Text = "";
        }

        private async void refreshTable(string search = "")
        {
            HttpData result = await conn.GetCustomerList(search);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            DataTable MyTable = JsonConvert.DeserializeObject<DataTable>(result.data.ToString());
            guestTable.DataSource = MyTable;
        }

        private async void GuestsScreen_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            //if (guestIdField.Text == "") return;
            //int id = int.Parse(guestIdField.Text);
            refreshTable(serachBoxField.Text);
        }

        private bool regChecker()
        {
            if (!Regex.Match(numberField.Text, @"^[0-9]+$").Success)
            {
                MessageBox.Show("Contact number must only contain numbers.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numberField.Focus();
                return false;
            }
            if (!Regex.Match(namaField.Text, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                MessageBox.Show("First name can only contain alphabets and spaces if required.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                namaField.Focus();
                return false;
            }
            return true;
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            bool regCheck = regChecker();
            if (regCheck == false)
            {
                return;
            }

            //add logic here
            HttpData result = await conn.StoreCustomer(
                "insert",
                namaField.Text,
                numberField.Text,
                nikField.Text,
                alamatField.Text,
                cityField.Text,
                provinsiField.Text
            );

            MessageBox.Show(result.message);
            refreshTable();
        }

        private void retrieveData(int id)
        {
            if (guestIdField.Text == "")
            {
                MessageBox.Show("Please enter id to search record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                //search logic here
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (guestIdField.Text == "")
            {
                MessageBox.Show("Please enter id to delete.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                HttpData result = await conn.StoreCustomer(
                      "delete",
                      namaField.Text,
                      numberField.Text,
                      alamatField.Text,
                      cityField.Text,
                      provinsiField.Text,
                      guestIdField.Text
                 );

                MessageBox.Show(result.message);
                refreshTable();
                clearFields();
            }
        }

        private void deleteBookingId()
        {
            query = "DELETE FROM Bookings.Booking WHERE GuestId = " + guestIdField.Text;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (guestIdField.Text == "")
            {
                MessageBox.Show("Please enter id to update record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                bool regCheck = regChecker();
                if (regCheck == false)
                {
                    return;
                }
                HttpData result = await conn.StoreCustomer(
                   "update",
                   namaField.Text,
                   numberField.Text,
                   nikField.Text,
                   alamatField.Text,
                   cityField.Text,
                   provinsiField.Text,
                   guestIdField.Text
               );

                    MessageBox.Show(result.message);
                    refreshTable();
            }
        }

        private void guestTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Selected");
            //guestIdField.Text = guestTable.SelectedRows[0].Cells[0].Value.ToString();
            //retrieveData(int.Parse(guestIdField.Text));

            var row = guestTable.SelectedRows[0];
            string id = row.Cells[0].Value.ToString();
            if(id == "38")
            {
                MessageBox.Show("Data ini tidak bisa di ubah");
                return;
            }
            guestIdField.Text = id;
            string name = row.Cells[1].Value.ToString();
            //name = Regex.Replace(name, @"^[a-zA-Z]+$",String.Empty);
            //string s2 = Regex.Replace(name, @"[^A-Z]+", String.Empty);
            namaField.Text = name;
            nikField.Text = row.Cells[6].Value.ToString();
            numberField.Text = row.Cells[2].Value.ToString();
            alamatField.Text = row.Cells[3].Value.ToString();
            cityField.Text = row.Cells[4].Value.ToString();
            provinsiField.Text = row.Cells[5].Value.ToString();
            //MessageBox.Show(row);
        }

        private void numberField_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void searchBoxField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                refreshTable(serachBoxField.Text);
            }
        }
    }
}
