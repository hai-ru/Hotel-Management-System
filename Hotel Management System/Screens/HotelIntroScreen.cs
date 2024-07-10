using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Screens
{
    public partial class HotelIntroScreen : Form
    {
        private const string BaseUrl = "https://development.norapos.com/api/business";

        private HttpConnection conn = new HttpConnection();

        public HotelIntroScreen()
        {
            InitializeComponent();
        }

        private async void HotelIntroScreen_Load(object sender, EventArgs e)
        {
            HttpData res = await conn.GetHotelDetails();
            if (!res.status)
            {
                MessageBox.Show(res.message);
                return;
            }
            
            string hotel_name = res.data.name ?? "";
            hotelName.Text = hotel_name;
        }

        //private async Task GetHotelDetails()
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Properties.Settings.Default.Token);

        //            HttpResponseMessage response = await client.PostAsync(BaseUrl, null);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                Hotel hotel = JsonSerializer.Deserialize<Hotel>(json);

        //                if (hotel != null)
        //                {
        //                    hotelName.Text = hotel.name;
        //                    contactLabel.Text = hotel.contact;
        //                    emailLabel.Text = hotel.email;
        //                    webLabel.Text = hotel.website;
        //                    descripLabel.Text = hotel.description;
        //                    string address = $"{hotel.street}, {hotel.city}, {hotel.state}, {hotel.country}";
        //                    streetLabel.Text = address;
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to retrieve hotel details: " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        // Define a class to represent the Hotel JSON structure
        public class Hotel
        {
            public int id { get; set; }
            public string name { get; set; }
            public string contact { get; set; }
            public string email { get; set; }
            public string website { get; set; }
            public string description { get; set; }
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
        }

        private void addressLabel_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        private void cityLabel_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        private void hotelName_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }
    }
}
