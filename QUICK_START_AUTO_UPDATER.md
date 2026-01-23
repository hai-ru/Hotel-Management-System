# Quick Start Guide - Install Auto Updater

## Langkah 1: Install NuGet Package

### Via Visual Studio (RECOMMENDED):
1. Buka **Hotel Management System.sln** di Visual Studio
2. Klik kanan pada project **"Hotel Management System"** di Solution Explorer
3. Pilih **"Manage NuGet Packages"**
4. Klik tab **"Browse"**
5. Search: `Autoupdater.NET.Official`
6. Klik package **Autoupdater.NET.Official** (by RBSoft)
7. Klik tombol **"Install"**
8. Klik **"OK"** pada dialog konfirmasi

### Via Package Manager Console:
1. Di Visual Studio, buka: **Tools → NuGet Package Manager → Package Manager Console**
2. Jalankan command:
   ```powershell
   Install-Package Autoupdater.NET.Official
   ```

### Via Command Line (PowerShell):
```powershell
cd "c:\Users\omjok\OneDrive\Desktop\Hotel Kartika Research\Hotel-Management-System"
dotnet add "Hotel Management System/Hotel Management System.csproj" package Autoupdater.NET.Official
```

## Langkah 2: Rebuild Project

1. Di Visual Studio, pilih: **Build → Rebuild Solution**
2. Pastikan tidak ada error

## Langkah 3: Update AssemblyInfo.cs

Buka `Properties/AssemblyInfo.cs` dan set version number:
```csharp
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
```

## Langkah 4: Setup Server untuk Host Updates

### Pilihan A: GitHub (GRATIS & MUDAH)

1. **Buat folder `updates` di repository GitHub Anda**

2. **Upload file `version.xml` ke folder tersebut**

3. **Update URL di UpdaterManager.cs**:
   ```csharp
   private const string UPDATE_XML_URL = 
       "https://raw.githubusercontent.com/USERNAME/REPO/main/updates/version.xml";
   ```
   
   Ganti `USERNAME` dan `REPO` dengan milik Anda.

4. **Setiap kali rilis versi baru**:
   - Upload installer ke GitHub Releases
   - Update `version.xml` dengan URL installer dari Releases
   - Format URL: `https://github.com/USERNAME/REPO/releases/download/v1.0.1/Setup.exe`

### Pilihan B: Web Hosting Sendiri

1. **Upload ke web hosting**:
   ```
   yourdomain.com/
   └── updates/
       ├── version.xml
       ├── KartikaHotelManagementSetup.exe
       └── changelog.html
   ```

2. **Update URL di UpdaterManager.cs**:
   ```csharp
   private const string UPDATE_XML_URL = 
       "https://yourdomain.com/updates/version.xml";
   ```

### Pilihan C: Google Drive (Mudah tapi Perlu Perhatian)

1. **Upload version.xml ke Google Drive**
2. **Set sharing ke "Anyone with the link"**
3. **Ambil Direct Download Link** (gunakan tool online untuk convert sharing link ke direct link)
4. **Gunakan link tersebut di UpdaterManager.cs**

⚠️ Note: Google Drive kadang throttle bandwidth, jadi tidak ideal untuk production.

## Langkah 5: Testing

### Test Lokal dengan Fake Update:

1. **Buat folder temporary untuk test**:
   ```
   C:\TestUpdate\
   └── version.xml
   ```

2. **Copy file version.xml ke sana dan edit**:
   ```xml
   <version>9.9.9.0</version>  <!-- Version tinggi untuk test -->
   ```

3. **Sementara ubah UpdaterManager.cs**:
   ```csharp
   private const string UPDATE_XML_URL = "file:///C:/TestUpdate/version.xml";
   ```

4. **Jalankan aplikasi** → Harusnya muncul dialog update

5. **Setelah test, kembalikan URL ke server asli**

## Langkah 6: Build Installer

### Menggunakan Inno Setup (GRATIS):

1. **Download Inno Setup**: https://jrsoftware.org/isdl.php
2. **Install Inno Setup**
3. **Buat script installer** (contoh di bawah)
4. **Compile script**
5. **Upload hasil installer ke server**

### Contoh Inno Setup Script:

```ini
[Setup]
AppName=Kartika Hotel Management System
AppVersion=1.0.0
DefaultDirName={pf}\Kartika Hotel
DefaultGroupName=Kartika Hotel
OutputDir=Output
OutputBaseFilename=KartikaHotelSetup_v1.0.0
Compression=lzma2
SolidCompression=yes

[Files]
Source: "Hotel Management System\bin\Release\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{group}\Kartika Hotel"; Filename: "{app}\Kartika Hotel Management System.exe"
Name: "{commondesktop}\Kartika Hotel"; Filename: "{app}\Kartika Hotel Management System.exe"

[Run]
Filename: "{app}\Kartika Hotel Management System.exe"; Description: "Launch Kartika Hotel"; Flags: postinstall nowait skipifsilent
```

## Workflow Update (Setelah Setup Selesai)

### Saat Rilis Versi Baru:

1. **Update version di AssemblyInfo.cs**:
   ```csharp
   [assembly: AssemblyVersion("1.0.1.0")]
   ```

2. **Build Release**:
   - Visual Studio: Build → Configuration Manager → Release
   - Build → Build Solution

3. **Buat Installer** dengan Inno Setup

4. **Upload installer ke server/GitHub**

5. **Update version.xml**:
   ```xml
   <version>1.0.1.0</version>
   <url>https://link-ke-installer-baru.exe</url>
   ```

6. **User yang jalankan aplikasi lama akan otomatis dapat notifikasi update**

## Troubleshooting

### Error: "Could not load file AutoUpdaterDotNET.dll"
- **Solusi**: Rebuild project atau restore NuGet packages

### Update tidak terdeteksi
- **Check**: Version di version.xml lebih tinggi dari AssemblyVersion?
- **Check**: URL version.xml bisa diakses via browser?
- **Check**: Format XML valid?

### Firewall/Antivirus Block
- **Solusi**: Whitelist aplikasi di antivirus
- **Solusi**: Sign executable dengan code signing certificate

### Build Error
- **Solusi**: Clean solution dulu (Build → Clean Solution)
- **Solusi**: Close & reopen Visual Studio
- **Solusi**: Delete bin dan obj folders

## FAQ

**Q: Berapa sering aplikasi check update?**
A: Saat ini hanya check saat startup. Bisa ditambahkan timer untuk periodic check.

**Q: Apakah update bisa dibatalkan user?**
A: Ya, kecuali Anda set `<mandatory>true</mandatory>` di version.xml.

**Q: Bagaimana cara rollback jika update bermasalah?**
A: Turunkan version number di version.xml atau user install versi lama manual.

**Q: Apakah perlu code signing certificate?**
A: Tidak wajib, tapi sangat direkomendasikan agar tidak kena SmartScreen warning.

**Q: File apa saja yang harus di-upload ke server?**
A: Minimal version.xml dan installer (.exe). Changelog opsional.

## Next Steps

1. ✅ Install NuGet package
2. ✅ Rebuild project
3. ⬜ Setup server hosting
4. ⬜ Update URL di UpdaterManager.cs
5. ⬜ Test update flow
6. ⬜ Create installer
7. ⬜ Deploy ke production

Need help? Check the full documentation in [AUTO_UPDATER_SETUP.md](AUTO_UPDATER_SETUP.md)
