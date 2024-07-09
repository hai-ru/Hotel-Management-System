using Hotel_Management_System.Screens;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Controllers
{
    public partial class RoomsScreen : Form
    {
        private const string BaseUrl = "https://your-backend-api-url/api/rooms"; // Replace with your actual API URL
        private HttpClient client;

        public RoomsScreen()
        {
            InitializeComponent();
            client = new HttpClient();
            roomIdField.ReadOnly = false;
            costField.ReadOnly = true;
        }

        private async Task populateTableAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(BaseUrl);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                var rooms = JsonSerializer.Deserialize<List<Room>>(responseData);

                roomsTable.DataSource = rooms;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON parse error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void populate()
        {
            await populateTableAsync();
            await populateTypeComboBoxAsync();
        }

        private async void Rooms_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void clearFields()
        {
            roomIdField.Text = "";
            roomNoField.Text = "";
            availableField.SelectedIndex = -1;
            typeCmbox.SelectedIndex = -1;
            costField.Text = "";
        }

        private async Task populateTypeComboBoxAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/types");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                var roomTypes = JsonSerializer.Deserialize<List<RoomType>>(responseData);

                typeCmbox.Items.Clear();
                foreach (var type in roomTypes)
                {
                    typeCmbox.Items.Add(type.Name);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON parse error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (roomNoField.Text != "" && typeCmbox.Text != "" && costField.Text != "" && availableField.Text != "")
            {
                var newRoom = new Room
                {
                    RoomNumber = roomNoField.Text,
                    HotelId = Statics.hotelIdTKN,
                    RoomTypeId = typeCmbox.SelectedIndex,
                    Available = availableField.Text
                };

                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(newRoom), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(BaseUrl, content);
                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Room inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    await populateTableAsync();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (roomIdField.Text == "")
            {
                MessageBox.Show("Please enter id to update record.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                var updatedRoom = new Room
                {
                    RoomId = int.Parse(roomIdField.Text),
                    RoomNumber = roomNoField.Text,
                    RoomTypeId = typeCmbox.SelectedIndex,
                    Available = availableField.Text
                };

                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(updatedRoom), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync($"{BaseUrl}/{updatedRoom.RoomId}", content);
                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    await populateTableAsync();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (roomIdField.Text == "")
            {
                MessageBox.Show("Please enter id to delete.", "Missing Info", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/{roomIdField.Text}");
                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    await populateTableAsync();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void typeCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findCost();
        }

        private void findCost()
        {
            // This method should fetch the cost of the room type from the server
            // Implement the logic to fetch the cost based on the selected room type
        }

        private void RoomsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addButton.Enabled = false;
            roomIdField.Text = roomsTable.SelectedRows[0].Cells[0].Value.ToString();
            roomNoField.Text = roomsTable.SelectedRows[0].Cells[1].Value.ToString();
            availableField.Text = roomsTable.SelectedRows[0].Cells[3].Value.ToString();
            typeCmbox.SelectedItem = getNameFromId(int.Parse(roomsTable.SelectedRows[0].Cells[2].Value.ToString()));
            findCost();
        }

        private void typeCmbox_Click(object sender, EventArgs e)
        {
            typeCmbox.Items.Clear();
            populateTypeComboBoxAsync();
        }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public string Available { get; set; }
    }

    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
    }
}
