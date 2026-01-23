// ====================================================================
// CONTOH IMPLEMENTASI: Manual Check Update dari Menu/Button
// ====================================================================

// Cara 1: Dari Menu Item (misalnya di Dashboard atau Settings)
// -----------------------------------------------------------
private void checkForUpdatesMenuItem_Click(object sender, EventArgs e)
{
    // Panggil dengan parameter true agar tampilkan pesan "No update available"
    UpdaterManager.CheckForUpdatesManual();
}


// Cara 2: Dari Button (misalnya di Settings Screen)
// -----------------------------------------------------------
private void btnCheckUpdate_Click(object sender, EventArgs e)
{
    UpdaterManager.CheckForUpdatesManual();
}


// ====================================================================
// CONTOH: Tambahkan Menu "Check for Updates" di Dashboard
// ====================================================================

// Di Dashboard.Designer.cs, tambahkan menu item:
/*
private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;

// Di InitializeComponent():
this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

// Setup properties:
this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
*/

// Di Dashboard.cs, tambahkan handler:
/*
private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
{
    UpdaterManager.CheckForUpdatesManual();
}
*/


// ====================================================================
// CONTOH: Menampilkan Versi Aplikasi di About/Settings
// ====================================================================
private string GetApplicationVersion()
{
    return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
}

// Tampilkan di Label:
// lblVersion.Text = $"Version {GetApplicationVersion()}";


// ====================================================================
// CONTOH: Konfigurasi Lanjutan di UpdaterManager
// ====================================================================

// Jika ingin update secara otomatis tanpa dialog (silent update):
/*
AutoUpdater.Mandatory = true;
AutoUpdater.UpdateMode = Mode.ForcedDownload;
AutoUpdater.RunUpdateAsAdmin = false;
*/

// Jika ingin custom download path:
/*
AutoUpdater.DownloadPath = Environment.CurrentDirectory;
*/

// Jika ingin custom JSON format (bukan XML):
/*
AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;

private static void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
{
    dynamic json = JsonConvert.DeserializeObject(args.RemoteData);
    args.UpdateInfo = new UpdateInfoEventArgs
    {
        CurrentVersion = json.version,
        DownloadURL = json.url,
        Mandatory = new Mandatory
        {
            Value = json.mandatory.value,
            MinimumVersion = json.mandatory.minimum_version,
            UpdateMode = json.mandatory.mode
        }
    };
}
*/


// ====================================================================
// TESTING: Cara Test Auto Updater Secara Lokal
// ====================================================================

// 1. Setup local web server (IIS atau XAMPP)
// 2. Taruh version.xml di folder web (misal: C:\inetpub\wwwroot\updates\)
// 3. Edit version.xml, set version lebih tinggi dari aplikasi
// 4. Di UpdaterManager.cs, ubah URL:
//    private const string UPDATE_XML_URL = "http://localhost/updates/version.xml";
// 5. Jalankan aplikasi, harusnya muncul dialog update


// ====================================================================
// DEPLOYMENT: Checklist Sebelum Release
// ====================================================================

/*
1. Update version number di Properties/AssemblyInfo.cs:
   [assembly: AssemblyVersion("1.0.1.0")]
   [assembly: AssemblyFileVersion("1.0.1.0")]

2. Build project dalam mode Release

3. Create installer (menggunakan Inno Setup, NSIS, atau MSI)

4. Upload installer ke server

5. Update version.xml di server:
   - Ubah <version> ke versi baru
   - Ubah <url> ke link installer baru
   - Update <changelog> jika ada

6. Test dengan aplikasi versi lama, pastikan update detection berjalan

7. Inform user tentang update (email, notification, dll)
*/
