using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Hotel_Management_System.Controllers.BookingsScreen;

namespace Hotel_Management_System.Screens
{
    public partial class HistoryScreen : Form
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
        public HistoryScreen()
        {
            InitializeComponent();
        }


        private async void refreshTable(string date = null)
        {
            HttpData result = await conn.GetHistoryList(date);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
            bookingTable.DataSource = MyTable;
        }

        private void ReservationScreen_Load(object sender, EventArgs e)
        {
            FilterTableCheckinDate.Value = DateTime.Today;
            refreshTable();
        }

        private void guestIdCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = bookingTable.SelectedRows[0];
                guna2TextBox1.Text = row.Cells[0].Value.ToString();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("https://development.norapos.com");
            form2.Show();
        }

        private void FilterTableCheckinDate_ValueChanged(object sender, EventArgs e)
        {
            string date = FilterTableCheckinDate.Value.ToString("yyyy-MM-dd");
            refreshTable(date);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}
