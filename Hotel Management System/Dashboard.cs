using Hotel_Management_System.Controllers;
using Hotel_Management_System.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class Dashboard : Form
    {
        private NetworkMonitor networkMonitor = new NetworkMonitor();
        private bool isCheckingNetwork = false;

        public Dashboard()
        {
            InitializeComponent();
            this.FormClosing += Dashboard_FormClosing;
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure application exits when Dashboard form is closed
            Application.Exit();
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void loadForm(object form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            loadForm(new RoomsScreen());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadForm(new HotelsScreen());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loadForm(new BookingsScreen());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            loadForm(new CheckoutScreen());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            loadForm(new GuestsScreen());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadForm(new EmployeesScreen());
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            loadForm(new ServicesScreen());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Get version from Assembly
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"v{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            
            // Set version label
            lblVersionNumber.Text = versionString;
            
            // Set version and last update in title
            string lastUpdate = "21 Jan 2026";
            this.Text = $"Kartika Hotel Management System - {versionString} (Updated: {lastUpdate})";
            
            // Load the RoomsScreen by default when the dashboard starts.
            loadForm(new RoomsScreen());            
            // Start network status monitoring
            networkStatusTimer.Start();
            CheckNetworkStatus(); // Check immediately on load            
            // Start network status monitoring
            networkStatusTimer.Start();
            CheckNetworkStatus(); // Check immediately on load
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            d.Show();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            loadForm(new ReservationScreen());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            loadForm(new HistoryScreen());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Optionally add custom painting logic here.
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void networkDiagnosticsButton_Click(object sender, EventArgs e)
        {
            // Open Network Diagnostics as popup/modal
            NetworkDiagnosticsScreen networkScreen = new NetworkDiagnosticsScreen();
            networkScreen.ShowDialog(this);
        }

        private async void CheckNetworkStatus()
        {
            if (isCheckingNetwork) return; // Prevent multiple simultaneous checks
            
            isCheckingNetwork = true;
            lblNetworkStatus.Text = "🔄 Checking...";
            lblNetworkStatus.ForeColor = Color.Gray;
            
            try
            {
                var status = await networkMonitor.TestConnection();
                
                if (status.IsConnected)
                {
                    if (status.PingTime < 100)
                    {
                        lblNetworkStatus.Text = $"✅ Online ({status.PingTime}ms)";
                        lblNetworkStatus.ForeColor = Color.Green;
                    }
                    else if (status.PingTime < 300)
                    {
                        lblNetworkStatus.Text = $"⚠️ Slow ({status.PingTime}ms)";
                        lblNetworkStatus.ForeColor = Color.Orange;
                    }
                    else
                    {
                        lblNetworkStatus.Text = $"⚠️ Poor ({status.PingTime}ms)";
                        lblNetworkStatus.ForeColor = Color.DarkOrange;
                    }
                }
                else
                {
                    lblNetworkStatus.Text = "❌ Offline";
                    lblNetworkStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblNetworkStatus.Text = "❌ Error";
                lblNetworkStatus.ForeColor = Color.Red;
                Console.WriteLine($"Network check error: {ex.Message}");
            }
            finally
            {
                isCheckingNetwork = false;
            }
        }

        private void networkStatusTimer_Tick(object sender, EventArgs e)
        {
            // Check network status every 30 seconds
            CheckNetworkStatus();
        }

        private void lblNetworkStatus_Click(object sender, EventArgs e)
        {
            // Open Network Diagnostics when clicking on network status
            NetworkDiagnosticsScreen networkScreen = new NetworkDiagnosticsScreen();
            networkScreen.ShowDialog(this);
        }
    }
}
