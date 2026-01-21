using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Screens
{
    public partial class NetworkDiagnosticsScreen : Form
    {
        private NetworkMonitor networkMonitor;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private bool isAutoRefresh = false;

        public NetworkDiagnosticsScreen()
        {
            InitializeComponent();
            networkMonitor = new NetworkMonitor();
            
            // Auto refresh timer (optional)
            autoRefreshTimer = new System.Windows.Forms.Timer();
            autoRefreshTimer.Interval = 10000; // 10 seconds
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;
        }

        private void NetworkDiagnosticsScreen_Load(object sender, EventArgs e)
        {
            // Run initial test
            RunConnectionTest();
        }

        private async void testButton_Click(object sender, EventArgs e)
        {
            await RunConnectionTest();
        }

        private async Task RunConnectionTest()
        {
            // Disable button saat testing
            testButton.Enabled = false;
            statusLabel.Text = "Testing connection...";
            statusLabel.ForeColor = Color.Gray;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            
            try
            {
                var status = await networkMonitor.TestConnection();
                
                // Update UI dengan hasil
                UpdateUI(status);
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Test failed: " + ex.Message;
                statusLabel.ForeColor = Color.Red;
                MessageBox.Show($"Error testing connection: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                testButton.Enabled = true;
            }
        }

        private void UpdateUI(NetworkMonitor.NetworkStatus status)
        {
            // Status Label
            statusLabel.Text = status.Quality;
            statusLabel.ForeColor = GetQualityColor(status.Quality);
            
            // Details
            messageLabel.Text = status.Message;
            pingLabel.Text = status.IsConnected ? $"{status.PingTime} ms" : "N/A";
            speedLabel.Text = status.IsConnected ? $"{status.DownloadSpeed:F0} KB/s" : "N/A";
            lastTestLabel.Text = status.TestTime.ToString("HH:mm:ss");
            
            // Recommendation
            recommendationTextBox.Text = networkMonitor.GetRecommendation(status.Quality);
            
            // Connection indicator
            connectionIndicator.BackColor = GetQualityColor(status.Quality);
            
            // Update quality bar
            UpdateQualityBar(status.Quality);
        }

        private Color GetQualityColor(string quality)
        {
            switch (quality)
            {
                case "Excellent":
                    return Color.FromArgb(0, 192, 0); // Dark Green
                case "Good":
                    return Color.FromArgb(0, 128, 0); // Green
                case "Fair":
                    return Color.Orange;
                case "Poor":
                    return Color.OrangeRed;
                case "Very Poor":
                case "No Connection":
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }

        private void UpdateQualityBar(string quality)
        {
            switch (quality)
            {
                case "Excellent":
                    qualityBar.Value = 100;
                    qualityBar.ForeColor = Color.Green;
                    break;
                case "Good":
                    qualityBar.Value = 75;
                    qualityBar.ForeColor = Color.LightGreen;
                    break;
                case "Fair":
                    qualityBar.Value = 50;
                    qualityBar.ForeColor = Color.Orange;
                    break;
                case "Poor":
                    qualityBar.Value = 25;
                    qualityBar.ForeColor = Color.OrangeRed;
                    break;
                default:
                    qualityBar.Value = 0;
                    qualityBar.ForeColor = Color.Red;
                    break;
            }
        }

        private void autoRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isAutoRefresh = autoRefreshCheckBox.Checked;
            
            if (isAutoRefresh)
            {
                autoRefreshTimer.Start();
            }
            else
            {
                autoRefreshTimer.Stop();
            }
        }

        private async void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isAutoRefresh && testButton.Enabled)
            {
                await RunConnectionTest();
            }
        }

        private async void quickPingButton_Click(object sender, EventArgs e)
        {
            quickPingButton.Enabled = false;
            quickPingLabel.Text = "Pinging...";
            
            try
            {
                long pingTime = await networkMonitor.QuickPing();
                
                if (pingTime >= 0)
                {
                    quickPingLabel.Text = $"{pingTime} ms";
                    quickPingLabel.ForeColor = pingTime < 100 ? Color.Green : 
                                              pingTime < 200 ? Color.Orange : Color.Red;
                }
                else
                {
                    quickPingLabel.Text = "Failed";
                    quickPingLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                quickPingLabel.Text = "Error";
                quickPingLabel.ForeColor = Color.Red;
                MessageBox.Show($"Quick ping failed: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                quickPingButton.Enabled = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            autoRefreshTimer.Stop();
            this.Close();
        }
    }
}
