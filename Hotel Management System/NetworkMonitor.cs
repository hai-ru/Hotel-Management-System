using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    /// <summary>
    /// Monitor koneksi network ke server
    /// Measure ping, latency, dan download speed
    /// </summary>
    internal class NetworkMonitor
    {
        private const string ServerUrl = "https://development.norapos.com";
        private const string ServerHost = "development.norapos.com";
        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

        public class NetworkStatus
        {
            public bool IsConnected { get; set; }
            public long PingTime { get; set; } // milliseconds
            public double DownloadSpeed { get; set; } // KB/s
            public string Quality { get; set; } // "Excellent", "Good", "Fair", "Poor", "No Connection"
            public string Message { get; set; }
            public DateTime TestTime { get; set; }
        }

        /// <summary>
        /// Test koneksi lengkap: ping + download speed
        /// </summary>
        public async Task<NetworkStatus> TestConnection()
        {
            var status = new NetworkStatus
            {
                TestTime = DateTime.Now,
                IsConnected = false,
                PingTime = 0,
                DownloadSpeed = 0,
                Quality = "Testing...",
                Message = "Testing connection..."
            };

            try
            {
                // Test 1: Ping server
                var pingResult = await PingServer();
                status.PingTime = pingResult.pingTime;
                status.IsConnected = pingResult.success;

                if (!status.IsConnected)
                {
                    status.Quality = "No Connection";
                    status.Message = "Cannot reach server. Check internet connection.";
                    return status;
                }

                // Test 2: Download speed test
                var speedResult = await TestDownloadSpeed();
                status.DownloadSpeed = speedResult.speed;

                // Evaluate quality berdasarkan ping dan speed
                status.Quality = EvaluateQuality(status.PingTime, status.DownloadSpeed);
                status.Message = GetQualityMessage(status.Quality, status.PingTime, status.DownloadSpeed);

                return status;
            }
            catch (Exception ex)
            {
                status.IsConnected = false;
                status.Quality = "Error";
                status.Message = $"Test failed: {ex.Message}";
                return status;
            }
        }

        /// <summary>
        /// Ping server untuk measure latency
        /// </summary>
        public async Task<(bool success, long pingTime)> PingServer()
        {
            try
            {
                using (var ping = new Ping())
                {
                    // Ping 3x dan ambil average
                    long totalTime = 0;
                    int successCount = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            var reply = await ping.SendPingAsync(ServerHost, 5000);
                            if (reply.Status == IPStatus.Success)
                            {
                                totalTime += reply.RoundtripTime;
                                successCount++;
                            }
                        }
                        catch
                        {
                            // Ignore individual ping failures
                        }

                        if (i < 2)
                            await Task.Delay(100); // Small delay between pings
                    }

                    if (successCount > 0)
                    {
                        long avgPing = totalTime / successCount;
                        return (true, avgPing);
                    }

                    return (false, 0);
                }
            }
            catch (Exception)
            {
                return (false, 0);
            }
        }

        /// <summary>
        /// Test download speed dengan request sample data
        /// </summary>
        public async Task<(bool success, double speed)> TestDownloadSpeed()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                
                // Download sample data (login page atau small endpoint)
                var response = await client.GetAsync($"{ServerUrl}/api/business");
                
                if (!response.IsSuccessStatusCode)
                {
                    return (false, 0);
                }

                var content = await response.Content.ReadAsByteArrayAsync();
                stopwatch.Stop();

                // Calculate speed in KB/s
                double bytes = content.Length;
                double seconds = stopwatch.Elapsed.TotalSeconds;
                double speedKBps = (bytes / 1024) / seconds;

                return (true, speedKBps);
            }
            catch (Exception)
            {
                return (false, 0);
            }
        }

        /// <summary>
        /// Quick ping test (single ping)
        /// </summary>
        public async Task<long> QuickPing()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(ServerHost, 3000);
                    if (reply.Status == IPStatus.Success)
                    {
                        return reply.RoundtripTime;
                    }
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Evaluate connection quality berdasarkan ping dan speed
        /// </summary>
        private string EvaluateQuality(long pingTime, double downloadSpeed)
        {
            // Prioritas utama: Ping time (lebih penting untuk aplikasi real-time)
            // Download speed sebagai faktor sekunder
            
            // Excellent: Ping < 50ms
            if (pingTime < 50)
            {
                if (downloadSpeed >= 500) return "Excellent";
                if (downloadSpeed >= 100) return "Good";
                return "Good"; // Ping bagus sudah cukup untuk Good
            }
            
            // Good: Ping 50-100ms
            if (pingTime < 100)
            {
                if (downloadSpeed >= 200) return "Good";
                if (downloadSpeed >= 50) return "Fair";
                return "Fair"; // Ping masih OK
            }
            
            // Fair: Ping 100-200ms
            if (pingTime < 200)
            {
                if (downloadSpeed >= 100) return "Fair";
                return "Poor"; // Ping mulai lambat
            }
            
            // Poor: Ping 200-500ms
            if (pingTime < 500)
            {
                return "Poor";
            }
            
            // Very Poor: Ping > 500ms
            return "Very Poor";
        }

        /// <summary>
        /// Get user-friendly message berdasarkan quality
        /// </summary>
        private string GetQualityMessage(string quality, long pingTime, double downloadSpeed)
        {
            switch (quality)
            {
                case "Excellent":
                    return $"✅ Koneksi sangat baik! Ping: {pingTime}ms, Speed: {downloadSpeed:F0} KB/s";
                
                case "Good":
                    return $"✅ Koneksi baik. Ping: {pingTime}ms, Speed: {downloadSpeed:F0} KB/s";
                
                case "Fair":
                    return $"⚠️ Koneksi cukup. Aplikasi mungkin agak lambat. Ping: {pingTime}ms, Speed: {downloadSpeed:F0} KB/s";
                
                case "Poor":
                    return $"⚠️ Koneksi lambat. Loading akan lama. Ping: {pingTime}ms, Speed: {downloadSpeed:F0} KB/s";
                
                case "Very Poor":
                    return $"❌ Koneksi sangat lambat! Banyak fitur akan timeout. Ping: {pingTime}ms, Speed: {downloadSpeed:F0} KB/s";
                
                default:
                    return "Testing connection...";
            }
        }

        /// <summary>
        /// Get recommendation berdasarkan connection quality
        /// </summary>
        public string GetRecommendation(string quality)
        {
            switch (quality)
            {
                case "Excellent":
                case "Good":
                    return "Koneksi optimal. Semua fitur berjalan lancar.";
                
                case "Fair":
                    return "Koneksi cukup. Hindari operasi berat seperti export Excel dalam jumlah besar.";
                
                case "Poor":
                    return "Koneksi lambat. Disarankan:\n" +
                           "• Tunggu beberapa saat sebelum refresh\n" +
                           "• Hindari membuka banyak screen sekaligus\n" +
                           "• Gunakan cache (data tidak selalu fresh)";
                
                case "Very Poor":
                    return "Koneksi sangat buruk. Disarankan:\n" +
                           "❌ Periksa koneksi WiFi/LAN\n" +
                           "❌ Restart router/modem\n" +
                           "❌ Hubungi IT support\n" +
                           "❌ Coba lagi nanti";
                
                case "No Connection":
                    return "Tidak ada koneksi:\n" +
                           "❌ Periksa kabel LAN atau WiFi\n" +
                           "❌ Pastikan internet tersambung\n" +
                           "❌ Coba buka website lain (google.com)\n" +
                           "❌ Hubungi IT support";
                
                default:
                    return "";
            }
        }
    }
}
