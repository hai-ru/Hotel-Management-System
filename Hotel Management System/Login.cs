using Hotel_Management_System.Controllers;
using Hotel_Management_System.Screens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    public partial class Login : Form
    {

        HttpConnection conn = new HttpConnection();

        DatabaseConnection dc = new DatabaseConnection();
        String query;
        public int hotelIdToken;
        public int employeeIdToken;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private String checkNewUser()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT NewUser FROM Authentication.Login WHERE username = '" + usernameTextField.Text + "' AND password = '" + passwordTextField.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            String str = "";
            while (dr.Read())
            {
                str = dr.GetString(0);
            }
            con.Close();
            return str;
        }
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = usernameTextField.Text;
            string password = passwordTextField.Text;

            errorLabel.Visible = true;
            errorLabel.Text = "Loading...";

            HttpData data = await conn.GetAccessToken(username,password);


            if (data.status)
            {
                errorLabel.Visible = false;

                string token = data.message;

                // Store the token securely
                Properties.Settings.Default.Token = token;
                Properties.Settings.Default.Save();

                this.Hide();
                Dashboard db = new Dashboard();
                db.Show();
            } else
            {
                errorLabel.Text = data.message;
                errorLabel.Visible = true;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SuperAdminLogin superAdmin = new SuperAdminLogin();
            superAdmin.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (usernameTextField.Text == "")
            {
                MessageBox.Show("Please enter username.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                query = "SELECT LoginId FROM Authentication.Login WHERE Username = @username";
                SqlConnection connection = dc.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", usernameTextField.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Statics.setTempUname(usernameTextField.Text);
                    this.Hide();
                    ResetPassword rp = new ResetPassword();
                    rp.Show();
                }
                else
                {
                    MessageBox.Show("Username not found.", "Incorrect Info", MessageBoxButtons.OK);
                }
            }
        }

        private void changeVisibile(object sender, EventArgs e)
        {
            //Image myimage1 = new Bitmap(@"C:\Users\Ali Asar\source\repos\Hotel Management System\Hotel Management System\Icons\eyevisoff.png");
            //Image myimage2 = new Bitmap(@"C:\Users\Ali Asar\source\repos\Hotel Management System\Hotel Management System\Icons\eyevisible.png");

            if (passwordTextField.UseSystemPasswordChar == true)
            {
                passwordTextField.UseSystemPasswordChar = false;
                //passwordTextField.IconRight = myimage2;
            }
            else if (passwordTextField.UseSystemPasswordChar == false)
            {
                passwordTextField.UseSystemPasswordChar = true;
                //passwordTextField.IconRight = myimage1;
            }
        }
    }

    // Define a class to deserialize the API response

   
}
