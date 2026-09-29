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
        DoorLockConnection onity = new DoorLockConnection();

        Guest[] guests = new Guest[] { };
        Reservation[] reservasi = new Reservation[] { };
        Room[] rooms = new Room[] { };
        Ota[] otas = new Ota[] { };
        PaymentMethod[] paymentMethods = new PaymentMethod[] { };

#pragma warning disable CS0414
        private int durasi_menginap = 1;
#pragma warning restore CS0414


        private int roomId;
        
        // Loading states untuk prevent duplicate requests
        private bool isLoadingGuests = false;
        private bool isLoadingRooms = false;
        private bool isLoadingOTA = false;
        private bool isLoadingPayment = false;
        private bool isLoadingReservation = false;
        private bool isLoadingTable = false;
        private CacheManager cache = CacheManager.Instance;
        private System.Windows.Forms.Timer guestSearchTimer;
        private string lastGuestSearch = "";
        
        // Selected guest info - untuk menyimpan contact ID yang dipilih
        private int selectedContactId = 0;
        private string selectedContactName = "";
        private System.Windows.Forms.Label contactIdLabel; // Label untuk menampilkan contact ID
        private bool isSelectingGuest = false; // Flag untuk mencegah TextChanged clear selection
        
        // Helper method untuk convert dynamic data ke string dengan aman
        private string SafeDataToString(dynamic data)
        {
            if (data == null) return "";
            if (data is Newtonsoft.Json.Linq.JArray jArray) return jArray.ToString();
            if (data is Newtonsoft.Json.Linq.JObject jObject) return jObject.ToString();
            return data.ToString();
        }
        
        // Method untuk set selected guest dan update label
        private void SetSelectedGuest(int contactId, string contactName)
        {
            selectedContactId = contactId;
            selectedContactName = contactName;
            
            if (contactIdLabel != null)
            {
                if (contactId > 0)
                {
                    contactIdLabel.Text = $"(ID: {contactId})";
                    contactIdLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 0); // Green
                }
                else
                {
                    contactIdLabel.Text = "";
                }
            }
        }
        
        // Method untuk clear selected guest
        private void ClearSelectedGuest()
        {
            selectedContactId = 0;
            selectedContactName = "";
            if (contactIdLabel != null)
            {
                contactIdLabel.Text = "";
            }
        }

        public BookingsScreen()
        {
            InitializeComponent();
            //bookingIdField.ReadOnly = false;
            checkIfEmployee();
            //addButton.Enabled = false;
            loadingText.Visible = false;
            kosongText.Visible = false;
            
            // Buat label untuk menampilkan contact ID di bawah combobox
            CreateContactIdLabel();
            
            // Optimasi: Jangan load data di constructor
        }
        
        private void CreateContactIdLabel()
        {
            contactIdLabel = new System.Windows.Forms.Label();
            contactIdLabel.AutoSize = true;
            contactIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            contactIdLabel.ForeColor = System.Drawing.Color.Green;
            // Posisikan di samping label "Nama Tamu" (label4)
            contactIdLabel.Location = new System.Drawing.Point(label4.Location.X + label4.Width + 5, label4.Location.Y);
            contactIdLabel.Name = "contactIdLabel";
            contactIdLabel.Text = "";
            
            // Tambahkan ke parent yang sama dengan guestIdCMBox
            if (guestIdCMBox.Parent != null)
            {
                guestIdCMBox.Parent.Controls.Add(contactIdLabel);
            }
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
            // Method kosong - sekarang pake search-based loading
            // Combobox akan load otomatis saat user ketik
        }
        
        private async void SearchAndLoadGuests(string searchQuery)
        {
            if (isLoadingGuests) return;
            if (searchQuery.Length < 2) 
            {
                guestIdCMBox.Items.Clear();
                ClearSelectedGuest();
                return; // Minimal 2 karakter untuk search
            }
            
            isLoadingGuests = true;
            
            // Tampilkan loading indicator
            if (contactIdLabel != null)
            {
                contactIdLabel.Text = "🔍 Mencari...";
                contactIdLabel.ForeColor = System.Drawing.Color.Gray;
            }
            
            // Close dropdown dulu sebelum load data (fix overlap)
            guestIdCMBox.DroppedDown = false;
            
            try
            {
                // Search dengan parameter query
                HttpData result = await conn.GetCustomerList(searchQuery);
                if (!result.status)
                {
                    guestIdCMBox.Items.Clear();
                    ClearSelectedGuest();
                    
                    if (contactIdLabel != null)
                    {
                        contactIdLabel.Text = "⚠ " + (result.message ?? "Error");
                        contactIdLabel.ForeColor = System.Drawing.Color.Red;
                    }
                    return;
                }

                if (result.data == null || SafeDataToString(result.data) == "[]" || SafeDataToString(result.data) == "")
                {
                    guestIdCMBox.Items.Clear();
                    ClearSelectedGuest();
                    
                    if (contactIdLabel != null)
                    {
                        contactIdLabel.Text = "Tidak ditemukan";
                        contactIdLabel.ForeColor = System.Drawing.Color.Orange;
                    }
                    return;
                }

                try
                {
                    string jsonData = SafeDataToString(result.data);
                    guests = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                    
                    guestIdCMBox.BeginUpdate();
                    guestIdCMBox.Items.Clear();

                    if (guests == null || guests.Length == 0)
                    {
                        ClearSelectedGuest();
                        if (contactIdLabel != null)
                        {
                            contactIdLabel.Text = "Tidak ditemukan";
                            contactIdLabel.ForeColor = System.Drawing.Color.Orange;
                        }
                    }
                    else
                    {
                        foreach (Guest guest in guests)
                        {
                            guestIdCMBox.Items.Add(guest);
                        }
                        
                        if (contactIdLabel != null)
                        {
                            contactIdLabel.Text = $"Ditemukan {guests.Length} tamu";
                            contactIdLabel.ForeColor = System.Drawing.Color.Blue;
                        }
                        
                        // Auto open dropdown jika ada hasil dan masih fokus
                        if (guestIdCMBox.Items.Count > 0 && guestIdCMBox.Focused)
                        {
                            // Delay sedikit untuk menghindari overlap
                            await Task.Delay(100);
                            if (guestIdCMBox.Focused) // Cek lagi setelah delay
                            {
                                guestIdCMBox.DroppedDown = true;
                            }
                        }
                    }
                    guestIdCMBox.EndUpdate();
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"JSON Parse Error in SearchAndLoadGuests: {jsonEx.Message}");
                    ClearSelectedGuest();
                    
                    if (contactIdLabel != null)
                    {
                        contactIdLabel.Text = "⚠ Error parsing data";
                        contactIdLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchAndLoadGuests: {ex.Message}");
                guestIdCMBox.BeginUpdate();
                guestIdCMBox.Items.Clear();
                guestIdCMBox.Items.Add(new Guest { 
                    Name = $"⚠ Error: {ex.Message}",
                    Id = 0
                });
                guestIdCMBox.EndUpdate();
            }
            finally
            {
                isLoadingGuests = false;
            }
        }
        
        private void InitializeGuestSearchTimer()
        {
            guestSearchTimer = new System.Windows.Forms.Timer();
            guestSearchTimer.Interval = 500; // 500ms debounce
            guestSearchTimer.Tick += (sender, e) =>
            {
                guestSearchTimer.Stop();
                SearchAndLoadGuests(lastGuestSearch);
            };
        }
        
        private async Task LoadAllGuests()
        {
            if (isLoadingGuests) return;
            
            isLoadingGuests = true;
            
            try
            {
                // Load semua guest tanpa search query (kosong)
                HttpData result = await conn.GetCustomerList("");
                if (!result.status)
                {
                    guestIdCMBox.Items.Clear();
                    
                    if (!string.IsNullOrEmpty(result.message))
                    {
                        guestIdCMBox.BeginUpdate();
                        guestIdCMBox.Items.Add(new Guest { 
                            Name = "⚠ " + result.message,
                            Id = 0
                        });
                        guestIdCMBox.EndUpdate();
                    }
                    return;
                }

                if (result.data == null)
                {
                    guestIdCMBox.Items.Clear();
                    guestIdCMBox.BeginUpdate();
                    guestIdCMBox.Items.Add(new Guest { 
                        Name = "No guests available - Type to search",
                        Id = 0
                    });
                    guestIdCMBox.EndUpdate();
                    return;
                }

                string jsonData = SafeDataToString(result.data);
                guests = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                
                guestIdCMBox.BeginUpdate();
                guestIdCMBox.Items.Clear();

                if (guests == null || guests.Length == 0)
                {
                    guestIdCMBox.Items.Add(new Guest { 
                        Name = "No guests available - Type to search",
                        Id = 0
                    });
                }
                else
                {
                    foreach (Guest guest in guests)
                    {
                        guestIdCMBox.Items.Add(guest);
                    }
                }
                guestIdCMBox.EndUpdate();
            }
            catch (Exception ex)
            {
                guestIdCMBox.BeginUpdate();
                guestIdCMBox.Items.Clear();
                guestIdCMBox.Items.Add(new Guest { 
                    Name = $"⚠ Error: {ex.Message}",
                    Id = 0
                });
                guestIdCMBox.EndUpdate();
            }
            finally
            {
                isLoadingGuests = false;
            }
        }
        
        private async Task LoadGuestByNameAsync(string guestName)
        {
            try
            {
                // Coba search dengan nama guest
                HttpData result = await conn.GetCustomerList(guestName);
                
                Console.WriteLine($"API Response Status: {result.status}");
                Console.WriteLine($"API Response Data Type: {result.data?.GetType().Name ?? "null"}");
                
                if (result.status && result.data != null)
                {
                    try
                    {
                        string jsonData = SafeDataToString(result.data);
                        // Cek apakah data adalah array kosong
                        if (jsonData == "[]" || jsonData == "")
                        {
                            Console.WriteLine("Empty guest data returned");
                            // Fallback ke load semua
                            result = await conn.GetCustomerList("");
                            if (!result.status || result.data == null)
                            {
                                return;
                            }
                            jsonData = SafeDataToString(result.data);
                        }
                        
                        var foundGuests = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                        if (foundGuests != null && foundGuests.Length > 0)
                        {
                            // Update array guests
                            guests = foundGuests;
                            
                            // Set combobox
                            guestIdCMBox.BeginUpdate();
                            guestIdCMBox.Items.Clear();
                            foreach (Guest guest in foundGuests)
                            {
                                guestIdCMBox.Items.Add(guest);
                            }
                            guestIdCMBox.EndUpdate();
                            
                            // Select the first matching guest (case insensitive dan trim whitespace)
                            var matchedGuest = foundGuests.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                g.Name.Trim().Equals(guestName.Trim(), StringComparison.OrdinalIgnoreCase)));
                            
                            if (matchedGuest != null)
                            {
                                guestIdCMBox.SelectedItem = matchedGuest;
                            }
                            else if (foundGuests.Length == 1)
                            {
                                // Jika hanya ada 1 hasil, pilih itu
                                guestIdCMBox.SelectedItem = foundGuests[0];
                            }
                            else
                            {
                                // Pilih yang paling mirip (partial match)
                                var partialMatch = foundGuests.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                    g.Name.IndexOf(guestName, StringComparison.OrdinalIgnoreCase) >= 0));
                                if (partialMatch != null)
                                {
                                    guestIdCMBox.SelectedItem = partialMatch;
                                }
                            }
                            return;
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"JSON Parse Error: {jsonEx.Message}");
                        Console.WriteLine($"Data received: {SafeDataToString(result.data)?.Substring(0, Math.Min(200, SafeDataToString(result.data).Length))}");
                        MessageBox.Show($"Error parsing guest data. Please check the API response format.", "JSON Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                // Jika search gagal atau kosong, coba load semua guest
                Console.WriteLine("Attempting to load all guests...");
                result = await conn.GetCustomerList("");
                if (result.status && result.data != null)
                {
                    try
                    {
                        string jsonData = SafeDataToString(result.data);
                        var allGuests = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                        if (allGuests != null && allGuests.Length > 0)
                        {
                            guests = allGuests;
                            
                            guestIdCMBox.BeginUpdate();
                            guestIdCMBox.Items.Clear();
                            foreach (Guest guest in allGuests)
                            {
                                guestIdCMBox.Items.Add(guest);
                            }
                            guestIdCMBox.EndUpdate();
                            
                            // Cari yang cocok
                            var matchedGuest = allGuests.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                g.Name.Trim().Equals(guestName.Trim(), StringComparison.OrdinalIgnoreCase)));
                            
                            if (matchedGuest != null)
                            {
                                guestIdCMBox.SelectedItem = matchedGuest;
                            }
                            else
                            {
                                // Cari partial match
                                var partialMatch = allGuests.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                    g.Name.IndexOf(guestName, StringComparison.OrdinalIgnoreCase) >= 0));
                                if (partialMatch != null)
                                {
                                    guestIdCMBox.SelectedItem = partialMatch;
                                }
                            }
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"JSON Parse Error (all guests): {jsonEx.Message}");
                        MessageBox.Show($"Unable to parse guest data from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to load guests: {result.message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in LoadGuestByNameAsync: {ex.Message}");
                MessageBox.Show($"Failed to load guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void populateReservasiComboBoxAsync()
        {
            if (isLoadingReservation) return;
            
            isLoadingReservation = true;
            reservasiCb.Enabled = false;
            
            try
            {
                HttpData result = await conn.GetReservationList();
                if (!result.status)
                {
                    MessageBox.Show(result.message);
                    return;
                }

                reservasi = JsonConvert.DeserializeObject<Reservation[]>(result.data.ToString());
                reservasiCb.Items.Clear();
                reservasiCb.DisplayMember = "text";

                foreach (Reservation data in reservasi)
                {
                    reservasiCb.Items.Add(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingReservation = false;
                reservasiCb.Enabled = true;
            }
        }

        private async void populateOTAComboBoxAsync()
        {
            if (isLoadingOTA) return;
            
            isLoadingOTA = true;
            otaComboBox.Enabled = false;
            
            try
            {
                // Cek cache untuk OTA (jarang berubah)
                otas = cache.Get<Ota[]>(CacheKeys.OTA_LIST);
                
                if (otas == null)
                {
                    HttpData result = await conn.GetOTAList();
                    if (!result.status)
                    {
                        MessageBox.Show(result.message);
                        return;
                    }

                    otas = JsonConvert.DeserializeObject<Ota[]>(result.data.ToString());
                    
                    // Cache 1 jam (sangat jarang berubah)
                    cache.Set(CacheKeys.OTA_LIST, otas, TimeSpan.FromHours(1));
                }
                
                otaComboBox.Items.Clear();
                otaComboBox.DisplayMember = "label";

                foreach (Ota ota in otas)
                {
                    otaComboBox.Items.Add(ota);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading OTA: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingOTA = false;
                otaComboBox.Enabled = true;
            }
        }

        private async void populatePaymentMethodComboBoxAsync()
        {
            if (isLoadingPayment) return;
            
            isLoadingPayment = true;
            paymentComboBox.Enabled = false;
            
            try
            {
                // Cek cache untuk Payment Methods (jarang berubah)
                paymentMethods = cache.Get<PaymentMethod[]>(CacheKeys.PAYMENT_METHODS);
                
                if (paymentMethods == null)
                {
                    HttpData result = await conn.GetPaymentList();
                    if (!result.status)
                    {
                        MessageBox.Show(result.message);
                        return;
                    }

                    paymentMethods = JsonConvert.DeserializeObject<PaymentMethod[]>(result.data.ToString());
                    
                    // Cache 1 jam (sangat jarang berubah)
                    cache.Set(CacheKeys.PAYMENT_METHODS, paymentMethods, TimeSpan.FromHours(1));
                }
                
                paymentComboBox.Items.Clear();
                paymentComboBox.DisplayMember = "label";

                foreach (PaymentMethod paymentMethod in paymentMethods)
                {
                    paymentComboBox.Items.Add(paymentMethod);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingPayment = false;
                paymentComboBox.Enabled = true;
            }
        }

        private async void populateRoomAsync()
        {
            if (isLoadingRooms) return;
            
            isLoadingRooms = true;
            NoKamarcomboBox.Enabled = false;
            
            try
            {
                // Rooms tidak di-cache karena status bisa berubah cepat
                HttpData result = await conn.GetRoomList(true,-1,"VC");
                if (!result.status)
                {
                    MessageBox.Show(result.message);
                    return;
                }

                rooms = JsonConvert.DeserializeObject<Room[]>(result.data.ToString());
                NoKamarcomboBox.Items.Clear();
                NoKamarcomboBox.DisplayMember = "ROOM NAME";

                foreach (Room room in rooms)
                {
                    NoKamarcomboBox.Items.Add(room);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingRooms = false;
                NoKamarcomboBox.Enabled = true;
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

        private async void BookingsScreen_Load(object sender, EventArgs e)
        {
            //FilterTableCheckinDate.Value = DateTime.Today;

            checkinPicker.Value = DateTime.Today;
            checkoutPicker.Value = DateTime.Today.AddDays(1);
            
            // Initialize guest search timer
            InitializeGuestSearchTimer();
            
            // Setup guest combobox untuk lazy loading
            guestIdCMBox.AutoCompleteMode = AutoCompleteMode.None;
            guestIdCMBox.TextChanged += (s, ev) => 
            {
                // Skip jika sedang proses pemilihan dari dropdown
                if (isSelectingGuest) return;
                
                guestSearchTimer.Stop();
                lastGuestSearch = guestIdCMBox.Text;
                // Clear selected guest saat text berubah (user mengetik ulang)
                ClearSelectedGuest();
                guestSearchTimer.Start();
            };
            
            // Set contact ID saat guest dipilih dari dropdown
            guestIdCMBox.SelectedIndexChanged += (s, ev) =>
            {
                var selectedGuest = guestIdCMBox.SelectedItem as Guest;
                if (selectedGuest != null && selectedGuest.Id > 0)
                {
                    isSelectingGuest = true; // Prevent TextChanged from clearing
                    SetSelectedGuest(selectedGuest.Id, selectedGuest.Name);
                    guestSearchTimer.Stop(); // Stop search timer
                    isSelectingGuest = false;
                }
            };
            
            // Load guest saat dropdown diklik jika belum ada data
            guestIdCMBox.DropDown += async (s, ev) =>
            {
                if (guestIdCMBox.Items.Count == 0 && !isLoadingGuests)
                {
                    // Load semua guest (tanpa filter)
                    await LoadAllGuests();
                }
            };

            // Optimasi: Load data secara parallel
            // Group 1: Static data yang bisa di-cache (parallel)
            // Group 2: Dynamic data (sequential)
            
            loadingText.Visible = true;
            loadingText.Text = "Loading data...";
            
            try
            {
                // Load static data langsung (sudah async)
                populateOTAComboBoxAsync();
                populatePaymentMethodComboBoxAsync();
                
                await Task.Delay(50);
                
                // Guest data - tidak perlu load di awal, akan load saat user ketik
                
                populateRoomAsync();
                await Task.Delay(50);
                
                populateReservasiComboBoxAsync();
                await Task.Delay(50);
                
                // Load table terakhir (paling berat)
                refreshTable(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingText.Visible = false;
            }
        }

        private async void refreshTable(string date = null)
        {
            if (isLoadingTable) return;
            
            isLoadingTable = true;
            loadingText.Visible = true;
            loadingText.Text = "Loading bookings...";
            bookingTable.Enabled = false;
            kosongText.Visible = false;
            
            try
            {
                HttpData result = await conn.GetCheckinList(date);
                if (!result.status)
                {
                    string errorMsg = string.IsNullOrEmpty(result.message) 
                        ? "Failed to load check-in data. Please check your connection." 
                        : result.message;
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kosongText.Visible = true;
                    kosongText.Text = "No data available";
                    bookingTable.DataSource = null;
                    return;
                }
                
                if (result.data == null)
                {
                    kosongText.Visible = true;
                    kosongText.Text = "No bookings found";
                    bookingTable.DataSource = null;
                    return;
                }
                
                System.Data.DataTable MyTable = JsonConvert.DeserializeObject<System.Data.DataTable>(result.data.ToString());
                
                if (MyTable == null || MyTable.Rows.Count == 0)
                {
                    kosongText.Visible = true;
                    kosongText.Text = "No bookings found";
                    bookingTable.DataSource = null;
                }
                else
                {
                    bookingTable.DataSource = MyTable;
                    kosongText.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kosongText.Visible = true;
                kosongText.Text = "Error loading data";
                bookingTable.DataSource = null;
            }
            finally
            {
                isLoadingTable = false;
                loadingText.Visible = false;
                bookingTable.Enabled = true;
            }
        }

        private void FilterTableCheckinDate_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = FilterTableCheckinDate.Value.ToString("yyyy-MM-dd");
            refreshTable(selectedDate);
        }


        private async void updateButton_Click(object sender, EventArgs e)
        {
            // Ambil nama guest dari combobox text
            string guestSearchName = guestIdCMBox.Text?.Trim();
            if (string.IsNullOrEmpty(guestSearchName))
            {
                MessageBox.Show("Please enter or select a guest name.", "Guest Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guestIdCMBox.Focus();
                return;
            }
            
            // Ambil bagian nama saja (sebelum " - " jika ada format "NAMA - NO HP")
            if (guestSearchName.Contains(" - "))
            {
                guestSearchName = guestSearchName.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
            }
            
            // Cek dulu apakah sudah ada SelectedItem yang valid
            Guest selectedGuest = guestIdCMBox.SelectedItem as Guest;
            
            // Jika tidak ada selected item atau ID = 0, query dari API
            if (selectedGuest == null || selectedGuest.Id == 0)
            {
                loadingText.Visible = true;
                loadingText.Text = "Loading guest data...";
                HttpData guestResult = await conn.GetCustomerList(guestSearchName);
                
                if (guestResult.status && guestResult.data != null)
                {
                    try
                    {
                        string jsonData = SafeDataToString(guestResult.data);
                        var guestResults = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                        
                        if (guestResults != null && guestResults.Length > 0)
                        {
                            selectedGuest = guestResults.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                g.Name.Trim().Equals(guestSearchName, StringComparison.OrdinalIgnoreCase))) ?? guestResults[0];
                        }
                    }
                    catch (JsonException)
                    {
                        // Ignore JSON error, will be caught below
                    }
                }
                loadingText.Visible = false;
            }
            
            if (selectedGuest == null || selectedGuest.Id == 0)
            {
                MessageBox.Show("Guest not found. Please select a valid guest.", "Invalid Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guestIdCMBox.Focus();
                return;
            }
            
            if (amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
                NoKamarcomboBox.SelectedIndex != -1)
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
                    // Guest combobox uses lazy loading - no need to clear/reload
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
            guestIdCMBox.Text = "";
            ClearSelectedGuest(); // Clear contact ID
            checkinPicker.Text = "";
            checkoutPicker.Text = "";
            NoKamarcomboBox.SelectedIndex = -1;
            amountField.Text = "";
            depositField.Text = "";
            depositTextBox1.Text = "";
            noteTextBox.Text = "";
            bookingIdTextBox.Text = "";
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

        private async void bookingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validasi: pastikan ada row yang dipilih
            if (bookingTable.SelectedRows.Count == 0)
            {
                return;
            }
            
            try
            {
                var row = bookingTable.SelectedRows[0];
                
                // Safely get cell values with null checks
                bookingIdField.Text = row.Cells[0].Value?.ToString() ?? "";
                depositTextBox1.Text = row.Cells[1].Value?.ToString() ?? "0";
                amountField.Text = row.Cells[2].Value?.ToString() ?? "0";
                depositField.Text = row.Cells[3].Value?.ToString() ?? "0";
                noteTextBox.Text = row.Cells.Count > 12 ? (row.Cells[12].Value?.ToString() ?? "") : "";
                bookingIdTextBox.Text = "";

                string guestName = row.Cells.Count > 10 ? (row.Cells[10].Value?.ToString() ?? "") : "";
                string roomName = row.Cells.Count > 9 ? (row.Cells[9].Value?.ToString() ?? "") : "";
                string methodName = row.Cells.Count > 5 ? (row.Cells[5].Value?.ToString() ?? "") : "";
                string otaName = row.Cells.Count > 6 ? (row.Cells[6].Value?.ToString() ?? "") : "";
                
                // Debug: tampilkan nama guest yang diambil
                Console.WriteLine($"Guest name from table: '{guestName}'");
                Console.WriteLine($"Total cells in row: {row.Cells.Count}");

                string checkinDateVal = row.Cells.Count > 7 ? (row.Cells[7].Value?.ToString() ?? "") : "";
                string checkoutDateVal = row.Cells.Count > 11 ? (row.Cells[11].Value?.ToString() ?? "") : "";

                // Convert the date format from dd/MM/yyyy to DateTime
                if (!string.IsNullOrEmpty(checkinDateVal) && !string.IsNullOrEmpty(checkoutDateVal))
                {
                    try
                    {
                        DateTime checkinDate = DateTime.ParseExact(checkinDateVal, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime checkoutDate = DateTime.ParseExact(checkoutDateVal, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        // Set the date pickers
                        checkinPicker.Value = checkinDate;
                        checkoutPicker.Value = checkoutDate;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Date parse error. Checkin: '{checkinDateVal}', Checkout: '{checkoutDateVal}'");
                    }
                }

                // Find and select the guest from API
                if (!string.IsNullOrWhiteSpace(guestName))
                {
                    loadingText.Visible = true;
                    loadingText.Text = "Loading guest data...";
                    
                    // Langsung search dari API
                    HttpData guestResult = await conn.GetCustomerList(guestName);
                    
                    if (guestResult.status && guestResult.data != null)
                    {
                        try
                        {
                            // Handle JArray properly using helper
                            string jsonData = SafeDataToString(guestResult.data);
                            
                            var foundGuests = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                            if (foundGuests != null && foundGuests.Length > 0)
                            {
                                // Update array guests
                                guests = foundGuests;
                                
                                // Set combobox
                                guestIdCMBox.BeginUpdate();
                                guestIdCMBox.Items.Clear();
                                foreach (Guest guest in foundGuests)
                                {
                                    guestIdCMBox.Items.Add(guest);
                                }
                                guestIdCMBox.EndUpdate();
                                
                                // Cari exact match
                                var matchedGuest = foundGuests.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                    g.Name.Trim().Equals(guestName.Trim(), StringComparison.OrdinalIgnoreCase)));
                                
                                if (matchedGuest != null)
                                {
                                    guestIdCMBox.SelectedItem = matchedGuest;
                                    SetSelectedGuest(matchedGuest.Id, matchedGuest.Name);
                                }
                                else
                                {
                                    // Ambil yang pertama
                                    guestIdCMBox.SelectedItem = foundGuests[0];
                                    SetSelectedGuest(foundGuests[0].Id, foundGuests[0].Name);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No guests found for: {guestName}");
                            }
                        }
                        catch (JsonException jsonEx)
                        {
                            Console.WriteLine($"JSON Parse Error: {jsonEx.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to load guest from API: {guestResult.message}");
                    }
                    
                    loadingText.Visible = false;
                }
                else
                {
                    MessageBox.Show("Guest name is empty in this booking record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Find and select the room
                var selectedRoom = rooms.FirstOrDefault((System.Func<Room, bool>)(room => room.Name == roomName));
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
                var selectedMethod = paymentMethods.FirstOrDefault((System.Func<PaymentMethod, bool>)(payment => payment.label == methodName));
                if (selectedMethod != null)
                {
                    paymentComboBox.SelectedItem = selectedMethod;
                }
                else
                {
                    MessageBox.Show("Method not found");
                }

                // Find and select the OTA
                var selectedOta = otas.FirstOrDefault((System.Func<Ota, bool>)(ota => ota.label == otaName));
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
                MessageBox.Show($"Date format error: {ex.Message}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"FormatException: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Column index error: {ex.Message}", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"ArgumentOutOfRangeException: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Exception: {ex.GetType().Name} - {ex.Message}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
            }
        }

        private void bookingTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ketika double-click row, trigger sama seperti CellContentClick
            bookingTable_CellContentClick(sender, e);
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            loadingText.Visible = true;
            loadingText.Text = "Processing...";
            
            // Cek apakah sudah ada contact ID yang dipilih
            int contactId = selectedContactId;
            string contactName = selectedContactName;
            
            // Jika belum ada, coba ambil dari SelectedItem combobox
            if (contactId == 0)
            {
                var selectedGuest = guestIdCMBox.SelectedItem as Guest;
                if (selectedGuest != null && selectedGuest.Id > 0)
                {
                    contactId = selectedGuest.Id;
                    contactName = selectedGuest.Name;
                }
            }
            
            // Jika masih belum ada, query dari API berdasarkan text
            if (contactId == 0)
            {
                string guestSearchName = guestIdCMBox.Text?.Trim();
                if (string.IsNullOrEmpty(guestSearchName))
                {
                    MessageBox.Show("Silahkan pilih tamu terlebih dahulu.", "Tamu Diperlukan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    addButton.Enabled = true;
                    loadingText.Visible = false;
                    guestIdCMBox.Focus();
                    return;
                }
                
                // Ambil bagian nama saja (sebelum " - " jika ada format "NAMA - NO HP")
                if (guestSearchName.Contains(" - "))
                {
                    guestSearchName = guestSearchName.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
                }
                
                loadingText.Text = "Mencari tamu...";
                HttpData guestResult = await conn.GetCustomerList(guestSearchName);
                
                if (guestResult.status && guestResult.data != null)
                {
                    try
                    {
                        string jsonData = SafeDataToString(guestResult.data);
                        var guestResults = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                        
                        if (guestResults != null && guestResults.Length > 0)
                        {
                            var matchedGuest = guestResults.FirstOrDefault((System.Func<Guest, bool>)(g => 
                                g.Name.Trim().Equals(guestSearchName, StringComparison.OrdinalIgnoreCase))) ?? guestResults[0];
                            
                            contactId = matchedGuest.Id;
                            contactName = matchedGuest.Name;
                            SetSelectedGuest(contactId, contactName);
                        }
                    }
                    catch (JsonException) { }
                }
            }
            
            // Validasi final
            if (contactId == 0)
            {
                MessageBox.Show("Tamu tidak ditemukan. Silahkan pilih tamu dari daftar.", "Tamu Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                addButton.Enabled = true;
                loadingText.Visible = false;
                guestIdCMBox.Focus();
                return;
            }
            
            loadingText.Text = "Processing...";
            
            if (amountField.Text != "" && checkinPicker.Text != "" && checkoutPicker.Text != "" &&
                NoKamarcomboBox.SelectedIndex != -1)
                {


                var durasi = (DateTime.Parse(checkoutPicker.Text) - DateTime.Parse(checkinPicker.Text)).Days;
                //if (durasi <= 0)
                //{
                //    MessageBox.Show("Tanggal checkout tidak boleh kurang dari hari ini");
                //    return;
                //}

                // Extract values from form fields
                var selectedRoom = NoKamarcomboBox.SelectedItem as Room;

                string contact_id = contactId.ToString();

                string lamainap = durasi.ToString();

                string room_product_id = selectedRoom?.ProductId.ToString();
                // Trim non-numeric characters from amountField.Text and depositField.Text
                string harga_total = string.Concat(amountField.Text.Where(char.IsDigit));
                string payment_amount = string.Concat(depositField.Text.Where(char.IsDigit));
                string deposit = string.Concat(depositTextBox1.Text.Where(char.IsDigit));
                string booking_id = bookingIdTextBox.Text.ToString();

                if (paymentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Silahkan pilih metode pembayaran yang di lakukan");
                    addButton.Enabled = true;
                    loadingText.Visible = false;
                    return;
                }

                string payment_method = paymentComboBox.SelectedItem.ToString();
                string ota = otaComboBox.SelectedItem == null ? "" : otaComboBox.SelectedItem.ToString();

                string notes = noteTextBox.Text;

                var selectedReservasi = reservasiCb.SelectedItem as Reservation;

                string reservation_id = selectedReservasi?.Id.ToString() ?? "";


                // Call StoreCheckin method
                HttpData result = await conn.StoreCheckin(contact_id, lamainap, room_product_id, harga_total, payment_amount, payment_method, ota, deposit, notes, reservation_id, booking_id);

                // Handle the response
                if (result.status)
                {
                    MessageBox.Show("Booking inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Perform additional actions such as clearing fields, updating UI, etc.
                    clearFields();
                    
                    // Reload data in background without blocking UI
                    populateReservasiComboBoxAsync();
                    populateRoomAsync();
                    refreshTable();
                    
                    addButton.Enabled = true;

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

            //var selectedRoom = NoKamarcomboBox.SelectedItem as Room;
            string room_id = "";
            try
            {
                var roomSplit = kamarTextbox.Text.Split('-');
                room_id = new Regex(@"[^\d]").Replace(roomSplit[0],"");
            }
            catch
            {
                room_id = "";
            }

            if (room_id == "")
            {
                MessageBox.Show("Room information is missing. Please select a valid row from the table.", "Room Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string contact_id = "";
            string contact_name = "";
            
            // Prioritas 1: Gunakan selectedContactId jika sudah di-set
            if (selectedContactId > 0)
            {
                contact_id = selectedContactId.ToString();
                contact_name = selectedContactName;
            }
            // Prioritas 2: Gunakan SelectedItem dari combobox
            else if (guestIdCMBox.SelectedItem is Guest selectedGuest && selectedGuest.Id > 0)
            {
                contact_id = selectedGuest.Id.ToString();
                contact_name = selectedGuest.Name;
                SetSelectedGuest(selectedGuest.Id, selectedGuest.Name);
            }
            // Prioritas 3: Query ke API berdasarkan text combobox
            else
            {
                string guestSearchName = guestIdCMBox.Text?.Trim();
                if (string.IsNullOrEmpty(guestSearchName))
                {
                    MessageBox.Show("Guest name is missing. Please enter or select a guest.", "Guest Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Ambil bagian nama saja (sebelum " - " jika ada format "NAMA - NO HP")
                if (guestSearchName.Contains(" - "))
                {
                    guestSearchName = guestSearchName.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
                }
                
                // Query ke API untuk mendapatkan data guest
                loadingText.Visible = true;
                loadingText.Text = "Loading guest data...";
                
                HttpData result = await conn.GetCustomerList(guestSearchName);
                
                if (!result.status || result.data == null)
                {
                    loadingText.Visible = false;
                    MessageBox.Show("Failed to load guest data from server. " + (result.message ?? ""), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Guest[] guestResults;
                try
                {
                    string jsonData = SafeDataToString(result.data);
                    guestResults = JsonConvert.DeserializeObject<Guest[]>(jsonData);
                }
                catch (JsonException ex)
                {
                    loadingText.Visible = false;
                    MessageBox.Show("Failed to parse guest data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (guestResults == null || guestResults.Length == 0)
                {
                    loadingText.Visible = false;
                    MessageBox.Show("Guest not found in database.", "Guest Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var matchedGuest = guestResults.FirstOrDefault((System.Func<Guest, bool>)(g => 
                    g.Name.Trim().Equals(guestSearchName, StringComparison.OrdinalIgnoreCase)));
                
                if (matchedGuest == null)
                {
                    matchedGuest = guestResults[0];
                }
                
                loadingText.Visible = false;
                
                if (matchedGuest.Id == 0)
                {
                    MessageBox.Show("Invalid guest data from API.", "Invalid Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                contact_id = matchedGuest.Id.ToString();
                contact_name = matchedGuest.Name;
                SetSelectedGuest(matchedGuest.Id, matchedGuest.Name);
            }
            
            if (string.IsNullOrEmpty(contact_id) || contact_id == "0")
            {
                MessageBox.Show("Guest ID is invalid. Please select a valid guest.", "Invalid Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkin = checkinPicker.Text;
            string checkout = checkoutPicker.Text;
            //string room_product_id = room_id;

            //var createCardTask = Task.Run(() => onity.createCard(selectedRoom.sku, durasi_menginap));
            var createCardTask = Task.Run(() => onity.createCard(room_id, DateTime.Parse(checkoutPicker.Text)));
            var logCreateCardTask = conn.LogCreateCard(contact_name, checkin, checkout, room_id, contact_id);

            var createCardResult = await createCardTask;

            if (createCardResult)
            {
                MessageBox.Show("Berhasil");

                var logResult = await logCreateCardTask;

                if (logResult.status)
                {
                    MessageBox.Show("Card written successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    
                    // Reload data in background without blocking UI
                    populateReservasiComboBoxAsync();
                    populateRoomAsync();
                    refreshTable();
                    
                    addButton.Enabled = true;
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
                //MessageBox.Show("Periksa Koneksi Onity encoder IP dan Port.");
                if (onity.LastError != "")
                {
                    MessageBox.Show("Gagal menulis kartu.\n" + onity.LastError, "Door Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            // Check if the selected value is "Walk In"
            if (otaComboBox.SelectedItem != null && otaComboBox.SelectedItem.ToString() == "Walk In")
            {
                bookingIdTextBox.Enabled = false;
                bookingIdTextBox.Text = string.Empty;
                // Change the background color to the control color to simulate a greyed-out look
                bookingIdTextBox.BackColor = SystemColors.Control;
            }
            else
            {
                // Re-enable the text box and restore the default background
                bookingIdTextBox.Enabled = true;
                bookingIdTextBox.BackColor = SystemColors.Window;
            }
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
                    var selectedGuest = guests.FirstOrDefault((System.Func<Guest, bool>)(guest => selectedReservasi.Contact_id == guest.Id));
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
                    var otaSelected = otas.FirstOrDefault((System.Func<Ota, bool>)(ota => selectedReservasi.Ota == ota.label));
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
                    var paymentSelected = paymentMethods.FirstOrDefault((System.Func<PaymentMethod, bool>)(data => selectedReservasi.metode_pembayaran == data.label));
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingIdTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
