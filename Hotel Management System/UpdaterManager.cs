using System;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace Hotel_Management_System
{
    /// <summary>
    /// Manager untuk handle auto update aplikasi
    /// </summary>
    public static class UpdaterManager
    {
        // URL tempat file version.xml di-host (ganti dengan URL server Anda)
        private const string UPDATE_XML_URL = "https://yourdomain.com/updates/version.xml";

        /// <summary>
        /// Initialize dan check for updates
        /// </summary>
        public static void CheckForUpdates(bool showNoUpdateAvailable = false)
        {
            try
            {
                // Konfigurasi AutoUpdater
                AutoUpdater.ShowSkipButton = true; // Tampilkan tombol skip
                AutoUpdater.ShowRemindLaterButton = true; // Tampilkan tombol remind later
                AutoUpdater.Mandatory = false; // Set true jika update wajib
                
                // Kustomisasi tampilan (opsional)
                AutoUpdater.AppTitle = "Kartika Hotel Management System";
                AutoUpdater.Icon = Properties.Resources.Icon; // Gunakan icon aplikasi
                
                // Jika true, akan tampilkan pesan "No update available"
                AutoUpdater.ReportErrors = showNoUpdateAvailable;
                
                // Event handler untuk custom behavior
                AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
                
                // Mulai check update
                AutoUpdater.Start(UPDATE_XML_URL);
            }
            catch (Exception ex)
            {
                // Log error tapi jangan ganggu user experience
                Console.WriteLine($"Update check failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler ketika check update selesai
        /// </summary>
        private static void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    
                    if (args.Mandatory.Value)
                    {
                        // Update wajib
                        dialogResult = MessageBox.Show(
                            $@"Update baru tersedia! Versi {args.CurrentVersion} sekarang tersedia. Anda menggunakan versi {args.InstalledVersion}. " +
                            $"Ini adalah update wajib. Klik OK untuk memulai proses update.",
                            @"Update Wajib",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Update opsional
                        dialogResult = MessageBox.Show(
                            $@"Update baru tersedia! Versi {args.CurrentVersion} sekarang tersedia. Anda menggunakan versi {args.InstalledVersion}. " +
                            $"\n\nApakah Anda ingin update sekarang?",
                            @"Update Tersedia",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);
                    }

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            // Download dan install update
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Tidak ada update
                    if (AutoUpdater.ReportErrors)
                    {
                        MessageBox.Show(@"Tidak ada update tersedia. Anda sudah menggunakan versi terbaru.",
                            @"Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                // Error saat check update
                if (args.Error is System.Net.WebException)
                {
                    MessageBox.Show(
                        @"Tidak dapat terhubung ke server update. Silakan cek koneksi internet Anda.",
                        @"Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message, args.Error.GetType().ToString(), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Force check for updates dengan dialog (dipanggil dari menu)
        /// </summary>
        public static void CheckForUpdatesManual()
        {
            CheckForUpdates(true);
        }

        /// <summary>
        /// Clear updater settings (untuk testing)
        /// </summary>
        public static void ClearUpdaterSettings()
        {
            AutoUpdater.ClearAppDirectory();
        }
    }
}
