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
using static Hotel_Management_System.Controllers.BookingsScreen;

namespace Hotel_Management_System.Screens
{
    public partial class ReservationScreen : Form
    {
        DatabaseConnection dc = new DatabaseConnection();
        String query;

        HttpConnection conn = new HttpConnection();
        OnityConnection onity = new OnityConnection();

        Guest[] guests = new Guest[] { };
        Room[] rooms = new Room[] { };
        Ota[] otas = new Ota[] { };
        PaymentMethod[] paymentMethods = new PaymentMethod[] { };

        private int durasi_menginap = 1;
        public ReservationScreen()
        {
            InitializeComponent();
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
            guestSelect.Items.Clear();

            // Bind rooms to roomIdCMBox
            guestSelect.DisplayMember = "text"; // Set the DisplayMember to "text" property

            foreach (Guest guest in guests)
            {
                guestSelect.Items.Add(guest); // Add guest to combo box
            }
        }

        private void clearFields()
        {
            //bookingIdField.Text = "";
            guestSelect.SelectedIndex = -1;
            checkinPicker.Text = "";
            checkoutPicker.Text = "";
            amountField.Text = "";
            paymentComboBox.SelectedIndex = -1;
            otaComboBox.SelectedIndex = -1;
        }

        private async void refreshTable(string date = null)
        {
            HttpData result = await conn.GetReservationList(date);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
            bookingTable.DataSource = MyTable;
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

        private void ReservationScreen_Load(object sender, EventArgs e)
        {
            FilterTableCheckinDate.Value = DateTime.Today;
            populateGuestComboBoxAsync();
            refreshTable(FilterTableCheckinDate.Value.ToString("yyyy-MM-dd"));
            populateOTAComboBoxAsync();
            populatePaymentMethodComboBoxAsync();
        }

        private void guestIdCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (guestSelect.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
               paymentComboBox.SelectedIndex != 1 && otaComboBox.SelectedIndex != 1)
            {
                // Extract values from form fields
                var selectedGuest = guestSelect.SelectedItem as Guest;

                string contact_id = selectedGuest?.Id.ToString();
                string lamainap = (DateTime.Parse(checkoutPicker.Text) - DateTime.Parse(checkinPicker.Text)).Days.ToString();
                // Trim non-numeric characters from amountField.Text and depositField.Text
                string harga_total = string.Concat(amountField.Text.Where(char.IsDigit));

                if (paymentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Silahkan pilih metode pembayaran yang di lakukan");
                    return;
                }

                string payment_method = paymentComboBox.SelectedItem.ToString();
                string ota = otaComboBox.SelectedItem == null ? "" : otaComboBox.SelectedItem.ToString();


                // Call StoreCheckin method
                HttpData result = await conn.StoreReservation(harga_total, checkinPicker.Text.ToString(), checkoutPicker.Text.ToString(), lamainap, contact_id, ota);


                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Berhasil menambahkan reservasi!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    guestSelect.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();

                    // Create a new WebBrowser instance
                    WebBrowser myWebBrowser = new WebBrowser();
                    //myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;

                    // Get the HTML content from the response
                    string htmlContent = result.data.receipt.html_content;

                    // Set the HTML content directly to the WebBrowser
                    myWebBrowser.DocumentText = htmlContent;

                    // Print the content
                    //myWebBrowser.Print();
                }
                else
                {
                    MessageBox.Show(result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Semua input harus terisi.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void amountField_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = bookingTable.SelectedRows[0];
                amountField.Text = row.Cells[1].Value.ToString();
                string guestId = row.Cells[5].Value.ToString();
                //string methodName = row.Cells[6].Value.ToString();
                string otaName = row.Cells[8].Value.ToString();

                string checkinDateVal = row.Cells[2].Value.ToString();
                string checkoutDateVal = row.Cells[3].Value.ToString(); 

                // Convert the date to DateTime
                DateTime checkinDate = DateTime.Parse(checkinDateVal);
                DateTime checkoutDate = DateTime.Parse(checkoutDateVal);

                // Set the date pickers
                checkinPicker.Value = checkinDate;
                checkoutPicker.Value = checkoutDate;

                // Find and select the guest
                var selectedGuest = guests.FirstOrDefault(guest => guest.Id.ToString() == guestId);
                if (selectedGuest != null)
                {
                    guestSelect.SelectedItem = selectedGuest; // Assuming guestIdCMBox is data-bound to guest IDs
                }
                else
                {
                    // Handle the case where the guest is not found (optional)
                    MessageBox.Show("Guest not found");
                }

                // Find and select the OTA
                var selectedOta = otas.FirstOrDefault(ota => ota.label == otaName);
                if (selectedOta != null)
                {
                    otaComboBox.SelectedItem = selectedOta;
                }
                else
                {
                    MessageBox.Show("OTA not found");
                }
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

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (guestSelect.SelectedIndex != -1 && amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
      paymentComboBox.SelectedIndex != 1 && otaComboBox.SelectedIndex != 1)
            {
                // Extract values from form fields
                var selectedGuest = guestSelect.SelectedItem as Guest;

                string contact_id = selectedGuest?.Id.ToString();
                string lamainap = (DateTime.Parse(checkoutPicker.Text) - DateTime.Parse(checkinPicker.Text)).Days.ToString();
                // Trim non-numeric characters from amountField.Text and depositField.Text
                string harga_total = string.Concat(amountField.Text.Where(char.IsDigit));

                if (paymentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Silahkan pilih metode pembayaran yang di lakukan");
                    return;
                }

                string payment_method = paymentComboBox.SelectedItem.ToString();
                string ota = otaComboBox.SelectedItem == null ? "" : otaComboBox.SelectedItem.ToString();


                // Call StoreCheckin method
                HttpData result = await conn.UpdateReservation(harga_total, checkinPicker.Text.ToString(), checkoutPicker.Text.ToString(), lamainap, contact_id, ota);


                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Berhasil menambahkan reservasi!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    guestSelect.Items.Clear();
                    populateGuestComboBoxAsync();
                    refreshTable();

                    // Create a new WebBrowser instance
                    WebBrowser myWebBrowser = new WebBrowser();
                    //myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;

                    // Get the HTML content from the response
                    string htmlContent = result.data.receipt.html_content;

                    // Set the HTML content directly to the WebBrowser
                    myWebBrowser.DocumentText = htmlContent;

                    // Print the content
                    //myWebBrowser.Print();
                }
                else
                {
                    MessageBox.Show(result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Semua input harus terisi.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
