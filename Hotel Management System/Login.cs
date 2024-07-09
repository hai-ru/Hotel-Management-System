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
        private const string BaseUrl = "https://development.norapos.com/api/login";

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

        private async Task<string> GetAccessToken(string username, string password)
        {
            string token = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

                    HttpResponseMessage response = await client.PostAsync(BaseUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        try
                        {
                            var options = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            };
                            var responseData = JsonSerializer.Deserialize<ApiResponse>(responseContent, options);

                            if (responseData.status)
                            {
                                // Login successful
                                if (responseData.data != null)
                                {
                                    token = responseData.data.token;
                                }
                            }
                            else
                            {
                                // Login failed due to incorrect credentials
                                errorLabel.Text = responseData.message;
                                errorLabel.Visible = true;
                            }
                        }
                        catch (JsonException ex)
                        {
                            MessageBox.Show($"Error parsing response: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // HTTP request failed
                        errorLabel.Text = "Failed to connect to server.";
                        errorLabel.Visible = true;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return token;
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = usernameTextField.Text;
            string password = passwordTextField.Text;

            string token = await GetAccessToken(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                // Store the token securely
                Properties.Settings.Default.Token = token; // Example of storing in application settings
                Properties.Settings.Default.Save();

                this.Hide();
                Dashboard db = new Dashboard();
                db.Show();
            }
        }


        private void TokenEployeeId()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT EmployeeId FROM Authentication.Login WHERE username = '" + usernameTextField.Text + "' AND password = '" + passwordTextField.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetValue(0) != DBNull.Value)
                {
                    employeeIdToken = dr.GetInt32(0);
                }
            }
        }

        private void TokenHotelIdHOTEL()
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT HotelId FROM Authentication.Login WHERE Username = '" + usernameTextField.Text + "' AND Password = '" + passwordTextField.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hotelIdToken = dr.GetInt32(0);
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

        private void passwordTextField_TextChanged(object sender, EventArgs e)
        {

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

    public class DataConverter : JsonConverter<Data>
    {
        public override Data Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                // Deserialize as Data object
                return JsonSerializer.Deserialize<Data>(ref reader, options);
            }
            else if (reader.TokenType == JsonTokenType.StartArray)
            {
                // Skip the array (empty array case)
                reader.Skip();
                return null;
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Serialization not implemented.");
        }
    }

    // Define a class to deserialize the API response
    public class ApiResponse
    {
        public bool status { get; set; }
        public string message { get; set; }

        [JsonConverter(typeof(DataConverter))]
        public Data data { get; set; }
    }

    public class Data
    {
        public string token { get; set; }
    }
}
