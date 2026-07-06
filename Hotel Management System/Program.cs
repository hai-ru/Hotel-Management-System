using Hotel_Management_System.Controllers;
using Hotel_Management_System.Screens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ConfigurationRepair.EnsureSettingsConfigValid();
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Pengaturan aplikasi rusak. File konfigurasi pengguna yang rusak telah dihapus. Silakan jalankan ulang aplikasi.", "Kesalahan Konfigurasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Configuration repair failed: {ex.Message}");
            }
            
            // Check for updates saat startup (silent mode)
            // User akan melihat dialog hanya jika ada update tersedia
            try
            {
                UpdaterManager.CheckForUpdates(showNoUpdateAvailable: false);
            }
            catch (Exception ex)
            {
                // Jangan ganggu startup jika update check gagal
                Console.WriteLine($"Auto update check failed: {ex.Message}");
            }
            
            Application.Run(new SplashScreen());

        }
    }
}
