# Setup Auto Updater untuk Kartika Hotel Management System

## Cara Install dan Konfigurasi

### 1. Install NuGet Package
Buka Package Manager Console dan jalankan:
```
Install-Package Autoupdater.NET.Official
```

Atau via NuGet Package Manager:
- Klik kanan pada project → Manage NuGet Packages
- Cari "Autoupdater.NET.Official"
- Klik Install

### 2. Update AssemblyInfo.cs
Pastikan version number di `Properties/AssemblyInfo.cs` sudah sesuai:
```csharp
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
```

### 3. Modifikasi Program.cs
Program.cs sudah diupdate untuk check update saat aplikasi startup.

### 4. Setup Server untuk Host Update Files

#### A. Upload file version.xml
Upload file `version.xml` ke server Anda (misalnya: https://yourdomain.com/updates/version.xml)

#### B. Upload installer/executable
Setiap kali rilis versi baru:
1. Build aplikasi dalam mode Release
2. Buat installer atau zip file dari executable
3. Upload ke server (misalnya: https://yourdomain.com/updates/KartikaHotelManagementSetup.exe)
4. Update `version.xml` dengan versi baru dan URL download

### 5. Update URL di UpdaterManager.cs
Ganti placeholder URL dengan URL server Anda:
```csharp
private const string UPDATE_XML_URL = "https://yourdomain.com/updates/version.xml";
```

## Struktur File Server

Siapkan folder di server Anda dengan struktur:
```
/updates/
    ├── version.xml                         (file info versi)
    ├── KartikaHotelManagementSetup.exe    (installer versi terbaru)
    └── changelog.html                      (opsional - daftar perubahan)
```

## Cara Kerja

1. **Saat Startup**: Aplikasi akan otomatis check update dari server
2. **Ada Update**: User akan melihat dialog dengan pilihan:
   - Yes: Download dan install update
   - No: Skip update kali ini
   - Remind Later: Tanya lagi nanti
3. **Download**: Update akan didownload otomatis
4. **Install**: Aplikasi akan close dan installer akan jalan

## Mandatory Update

Untuk membuat update wajib (user tidak bisa skip):
1. Set `<mandatory>true</mandatory>` di version.xml
2. User harus update sebelum bisa gunakan aplikasi

## Manual Check Update

Anda bisa tambahkan menu "Check for Updates" di aplikasi:
```csharp
private void checkForUpdatesMenuItem_Click(object sender, EventArgs e)
{
    UpdaterManager.CheckForUpdatesManual();
}
```

## Testing

### Testing Lokal
1. Host version.xml di local web server (IIS/XAMPP)
2. Ganti URL ke http://localhost/updates/version.xml
3. Ubah version number di version.xml lebih tinggi dari versi aplikasi
4. Jalankan aplikasi, harusnya muncul dialog update

### Testing dengan File
Untuk testing tanpa server:
```csharp
// Di Program.cs, ganti dengan path lokal
AutoUpdater.Start("file://C:/path/to/version.xml");
```

## Alternatif Hosting

### GitHub Releases
1. Upload installer ke GitHub Releases
2. Gunakan URL raw untuk version.xml:
   ```
   https://raw.githubusercontent.com/username/repo/main/updates/version.xml
   ```

### Google Drive / Dropbox
1. Upload files dan buat public share link
2. Gunakan direct download link

### Web Hosting Gratis
- Netlify
- Vercel
- Firebase Hosting
- Azure Blob Storage (dengan static website)

## Changelog Example (changelog.html)

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>What's New</title>
</head>
<body>
    <h2>Version 1.0.1.0</h2>
    <ul>
        <li>Fixed bug pada booking system</li>
        <li>Improved performance dashboard</li>
        <li>Added new reporting feature</li>
    </ul>
    
    <h2>Version 1.0.0.0</h2>
    <ul>
        <li>Initial release</li>
    </ul>
</body>
</html>
```

## Troubleshooting

### Update tidak terdeteksi
- Cek versi di AssemblyInfo.cs vs version.xml
- Pastikan version.xml bisa diakses via browser
- Cek firewall/antivirus tidak block aplikasi

### Download gagal
- Pastikan URL installer benar dan accessible
- Check space di local machine cukup
- Cek format file version.xml valid XML

### Error saat install
- Pastikan aplikasi punya write permission
- Jalankan sebagai Administrator jika perlu
- Check antivirus tidak block installer

## Best Practices

1. **Semantic Versioning**: Gunakan format Major.Minor.Patch.Build (1.0.0.0)
2. **Testing**: Selalu test update di environment staging dulu
3. **Backup**: User sebaiknya backup data sebelum update major version
4. **Changelog**: Selalu dokumentasikan perubahan untuk user
5. **Rollback Plan**: Simpan installer versi lama untuk rollback jika perlu

## Security

- Gunakan HTTPS untuk download URL
- Implement checksum validation di version.xml
- Sign executable dengan code signing certificate
- Validate download integrity sebelum install
