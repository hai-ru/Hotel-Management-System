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
            loadingText.Visible = false;
        }


        private async void refreshTable(string date = null,string search_name = "")
        {
            loadingText.Visible = true;
            HttpData result = await conn.GetHistoryList(date,search_name);
            if (!result.status)
            {
                MessageBox.Show(result.message);
                return;
            }
            System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
            bookingTable.DataSource = MyTable;
            loadingText.Visible = false;
        }

        private void ReservationScreen_Load(object sender, EventArgs e)
        {
            //FilterTableCheckinDate.Value = DateTime.Today;
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
                idField.Text = row.Cells[0].Value.ToString();
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
            string id = idField.Text;
            if(id == "")
            {
                MessageBox.Show("Pilih data id disamping terlebih dahulu...");
                return;
            }
            string link = "https://development.norapos.com/api/hotel/print?bill=1&id="+id;
            Form2 form2 = new Form2(link);
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

        private void searchBoxField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                refreshTable(null,serachBoxField.Text);
            }
        }

        private void serachBoxField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
