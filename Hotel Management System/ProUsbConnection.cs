using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Hotel_Management_System
{
    /// <summary>
    /// Koneksi ke encoder kartu proUSB (proUSBHotelCardSystem / CardLock.exe) lewat proRFL.dll.
    /// proRFL.dll dan d12c.dll harus ada di folder aplikasi, dan aplikasi harus jalan 32-bit.
    /// </summary>
    internal class ProUsbConnection
    {
        #region proRFL.dll

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int initializeUSB(byte fUSB);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void CloseUSB(byte fUSB);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int Buzzer(byte fUSB, int t);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GuestCard(byte fUSB, int dlsCoID, byte CardNo, byte dai, byte LLock, byte pdoors,
            byte[] BDate, byte[] EDate, byte[] LockNo, byte[] cardHexStr);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int RoomSetCard(byte fUSB, int dlsCoID, byte CardNo, byte dai, byte flag,
            byte[] BDate, byte[] LockNo, byte[] cardHexStr);

        // Parameter ke-5 selalu 0 (sama dengan CardLock.exe)
        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int TimeSetCard(byte fUSB, int dlsCoID, byte CardNo, byte dai, byte zero,
            byte[] DateTime, byte[] cardHexStr);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int CardErase(byte fUSB, int dlsCoID, byte[] cardHexStr);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int ReadCard(byte fUSB, byte[] Buffer);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetGuestLockNoByCardDataStr(int dlsCoID, byte[] cardHexStr, byte[] LockNo);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetGuestETimeByCardDataStr(int dlsCoID, byte[] cardHexStr, byte[] ETime);

        [DllImport("proRFL.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetCardTypeByCardDataStr(byte[] cardHexStr, byte[] CardType);

        #endregion

        // proUSB = 1 (encoder USB)
        private const byte USB = 1;

        // Semua akses ke encoder diserialkan, karena dipanggil dari Task.Run / BackgroundWorker
        private static readonly object deviceLock = new object();

        public string LastError { get; private set; } = "";

        private static int HotelId
        {
            get { return int.Parse(Properties.Settings.Default.ProUsbHotelId); }
        }

        private static byte Dai
        {
            get { return byte.Parse(Properties.Settings.Default.ProUsbDai); }
        }

        /// <param name="lockNo">Lock No. 8 digit dari CardLock (Rooms Definition), diisi di backend field lock_no</param>
        public Boolean createCard(string room, DateTime endDate, string lockNo)
        {
            try
            {
                lockNo = (lockNo ?? "").Trim();
                if (lockNo.Length != 8 || !lockNo.All(char.IsDigit))
                {
                    return Fail($"Lock No kamar {room} belum diisi / bukan 8 digit (\"{lockNo}\"). " +
                        "Isi lock_no di backend sesuai kolom Lock No. di CardLock (Rooms Definition), mis. 01010199.");
                }

                // Sama dengan CardLock: CheckOutTime = 12:00 (System.ini)
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 12, 0, 0);

                lock (deviceLock)
                {
                    Open();
                    try
                    {
                        byte[] cardHex = new byte[1024];
                        // BDate = sekarang, supaya kartu tamu sebelumnya di kamar ini otomatis tidak berlaku.
                        // LLock = 1 (GuestLLock=1 di System.ini), dai sama dengan kartu buatan CardLock.
                        int st = GuestCard(USB, HotelId, 0, Dai, 1, 0,
                            Ansi(DateTime.Now.ToString("yyMMddHHmm")),
                            Ansi(endDate.ToString("yyMMddHHmm")),
                            Ansi(lockNo),
                            cardHex);

                        if (st != 0)
                        {
                            return Fail($"GuestCard gagal (kode {st}) untuk kamar {room} / lock {lockNo}");
                        }

                        Buzzer(USB, 50);
                        Console.WriteLine($"proUSB: kartu kamar {room} (lock {lockNo}) s/d {endDate:yyyy-MM-dd HH:mm}");
                        return true;
                    }
                    finally
                    {
                        CloseUSB(USB);
                    }
                }
            }
            catch (Exception exception)
            {
                return Fail(exception.Message);
            }
        }

        /// <summary>
        /// Kartu Room Setting: menanamkan LockNo ke kunci pintu. Dai kartu setting di CardLock = 1 (tabel Dai).
        /// </summary>
        public Boolean createRoomSetCard(string lockNo, byte dai)
        {
            lockNo = (lockNo ?? "").Trim();
            if (lockNo.Length != 8 || !lockNo.All(char.IsDigit))
            {
                return Fail($"Lock No harus 8 digit (\"{lockNo}\")");
            }

            return WriteSettingCard("RoomSetCard", buf =>
                RoomSetCard(USB, HotelId, 0, dai, 0, Ansi(DateTime.Now.ToString("yyMMddHHmm")), Ansi(lockNo), buf));
        }

        /// <summary>
        /// Kartu Time Setting: menyetel jam kunci pintu ke jam PC saat kartu dibuat (tanpa detik).
        /// </summary>
        public Boolean createTimeSetCard(byte dai)
        {
            return WriteSettingCard("TimeSetCard", buf =>
                TimeSetCard(USB, HotelId, 0, dai, 0, Ansi(DateTime.Now.ToString("yyMMddHHmm")), buf));
        }

        private Boolean WriteSettingCard(string name, Func<byte[], int> write)
        {
            try
            {
                lock (deviceLock)
                {
                    Open();
                    try
                    {
                        int st = write(new byte[1024]);
                        if (st != 0)
                        {
                            return Fail($"{name} gagal (kode {st})");
                        }

                        Buzzer(USB, 50);
                        return true;
                    }
                    finally
                    {
                        CloseUSB(USB);
                    }
                }
            }
            catch (Exception exception)
            {
                return Fail(exception.Message);
            }
        }

        /// <summary>
        /// proUSB tidak punya checkout per kamar seperti Onity: kartu yang ada di encoder dihapus.
        /// </summary>
        public Boolean checkoutCard(string room)
        {
            try
            {
                lock (deviceLock)
                {
                    Open();
                    try
                    {
                        int st = CardErase(USB, HotelId, new byte[1024]);
                        if (st != 0)
                        {
                            return Fail($"CardErase gagal (kode {st})");
                        }

                        Buzzer(USB, 50);
                        return true;
                    }
                    finally
                    {
                        CloseUSB(USB);
                    }
                }
            }
            catch (Exception exception)
            {
                return Fail(exception.Message);
            }
        }

        public string readCard()
        {
            ProUsbCardInfo info = readCardInfo();
            return info == null ? "" : info.Room;
        }

        public ProUsbCardInfo readCardInfo()
        {
            try
            {
                lock (deviceLock)
                {
                    Open();
                    try
                    {
                        byte[] cardHex = new byte[1024];
                        int st = ReadCard(USB, cardHex);
                        if (st != 0)
                        {
                            Fail($"ReadCard gagal (kode {st})");
                            return null;
                        }

                        ProUsbCardInfo info = Decode(FromAnsi(cardHex));
                        if (info == null)
                        {
                            Fail("Data kartu tidak dikenali: " + FromAnsi(cardHex));
                        }
                        return info;
                    }
                    finally
                    {
                        CloseUSB(USB);
                    }
                }
            }
            catch (Exception exception)
            {
                Fail(exception.Message);
                return null;
            }
        }

        private void Open()
        {
            int st = initializeUSB(USB);
            if (st != 0)
            {
                throw new InvalidOperationException($"Encoder proUSB tidak terdeteksi (initializeUSB kode {st})");
            }
        }

        private bool Fail(string message)
        {
            LastError = message;
            Console.WriteLine("proUSB: " + message);
            return false;
        }

        /// <summary>
        /// Urai data ReadCard sendiri. Fungsi Get...ByCardDataStr di proRFL.dll (2010) hanya menerima
        /// header "551501", sedangkan reader V9H mengembalikan "551D01", padahal isi bloknya sama.
        /// Data: "55" + 2 hex + "01" + blok 16 byte. Layout blok sesuai GuestCard di proRFL.dll:
        ///   0 C9 (kartu tamu) | 1-3 Hotel ID | 4 LockNo[3] (+0x80 LLock) | 5 LockNo[2]+0x80 | 6 LockNo[1]+0x80
        ///   7 pdoors&lt;&lt;4 | LockNo[0] | 8 dai | 9 tipe&lt;&lt;4 | CardNo (tamu = 0x6_) | 10-12 tanggal mulai | 13-15 tanggal berakhir
        /// </summary>
        public static ProUsbCardInfo Decode(string data)
        {
            if (data == null || data.Length < 38 || !data.StartsWith("55"))
            {
                return null;
            }

            byte[] b = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                b[i] = Convert.ToByte(data.Substring(6 + i * 2, 2), 16);
            }

            // Tipe kartu = 4 bit atas byte 9 (tabel Dai di CardLock.mdb punya CardType 0-15); kartu tamu = 6
            var info = new ProUsbCardInfo { RawData = data };
            int type = b[9] >> 4;
            string typeName;
            if (b[0] != 0xC9)
            {
                info.CardType = "Kartu kosong / tidak dikenal";
                return info;
            }
            if (!CardTypeNames.TryGetValue(type, out typeName))
            {
                typeName = "Tipe " + type;
            }

            info.HotelId = (b[1] << 16) | ((b[2] & 0x3F) << 8) | b[3];
            info.Dai = b[8];
            info.StartTime = DecodeTime(b[10], b[11], b[12]);

            if (type != 6)
            {
                info.CardType = $"Bukan kartu tamu: {typeName} (tipe {type})";
                if (type == 2)
                {
                    // RoomSetCard: urutan LockNo sama dengan kartu tamu, tanpa +0x80
                    info.SettingLockNo = $"{b[7] & 0x0F:00}{b[6]:00}{b[5]:00}{b[4]:00}";
                    info.CardType += $"\r\nUntuk LockNo: {info.SettingLockNo}";
                }
                // Room/Time Setting: byte 13-15 berisi angka acak (rand() di proRFL.dll), bukan tanggal
                if (type != 2 && type != 3)
                {
                    info.EndTime = DecodeTime(b[13], b[14], b[15]);
                }
                return info;
            }

            info.CardType = typeName;
            info.HotelId = (b[1] << 16) | ((b[2] & 0x3F) << 8) | b[3];
            info.LockNo = $"{b[7] & 0x0F:00}{b[6] - 0x80:00}{b[5] - 0x80:00}{b[4] & 0x7F:00}";
            info.Dai = b[8];
            info.CardNo = b[9] & 0x0F;
            info.StartTime = DecodeTime(b[10], b[11], b[12]);
            info.EndTime = DecodeTime(b[13], b[14], b[15]);
            return info;
        }

        // Konstanta tipe dari fungsi pembuat kartu di proRFL.dll (RecordCard 0x10, RoomSetCard 0x20, dst.)
        private static readonly Dictionary<int, string> CardTypeNames = new Dictionary<int, string>
        {
            { 0, "System Card" },
            { 1, "Record Card" },
            { 2, "Room Setting Card" },
            { 3, "Time Setting Card" },
            { 4, "Limit Card" },
            { 5, "Group Setting Card" },
            { 6, "Kartu tamu" },
            { 7, "Check-Out Card" },
            { 8, "Group Card" },
            { 10, "Emergency Card" },
            { 11, "Master Card" },
            { 12, "Building Card" },
            { 13, "Floor Card" },
        };

        // Tahun disimpan sebagai (yy - 9) mod 16: ambil kandidat yang paling dekat dengan tahun sekarang
        private static DateTime? DecodeTime(byte ym, byte dh, byte hm)
        {
            int nowYy = DateTime.Now.Year % 100;
            int yy = (ym >> 4) + 9;
            while (yy + 8 < nowYy) yy += 16;
            while (yy - 8 > nowYy) yy -= 16;

            try
            {
                return new DateTime(2000 + yy, ym & 0x0F, dh >> 3, ((dh & 0x07) << 2) | (hm >> 6), hm & 0x3F, 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        private static byte[] Ansi(string s)
        {
            return Encoding.ASCII.GetBytes(s + "\0");
        }

        private static string FromAnsi(byte[] buffer)
        {
            int len = Array.IndexOf(buffer, (byte)0);
            return Encoding.ASCII.GetString(buffer, 0, len < 0 ? buffer.Length : len).Trim();
        }
    }

    internal class ProUsbCardInfo
    {
        public string RawData { get; set; }
        public string CardType { get; set; }
        public int HotelId { get; set; }
        public string LockNo { get; set; } = "";
        // Hanya untuk Room Setting Card
        public string SettingLockNo { get; set; } = "";
        public int Dai { get; set; }
        public int CardNo { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        // Diisi DoorLockConnection dari lock_no di backend
        public string Room { get; set; } = "";
    }
}
