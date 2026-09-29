using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hotel_Management_System
{
    /// <summary>
    /// Pintu masuk tunggal ke sistem door lock. Vendor per kamar diatur di web backend
    /// lewat field "door_lock" ("onity" / "prousb") dan opsional "lock_no" di /products/list.
    /// Kamar tanpa field door_lock dianggap Onity.
    /// </summary>
    internal class DoorLockConnection
    {
        public const string Onity = "onity";
        public const string ProUsb = "prousb";

        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);
        private static readonly object cacheLock = new object();
        private static Dictionary<string, RoomLock> roomLocks;
        private static DateTime roomLocksLoadedAt;

        private readonly OnityConnection onity = new OnityConnection();
        private readonly ProUsbConnection proUsb = new ProUsbConnection();
        private readonly HttpConnection conn = new HttpConnection();

        public string LastError { get; private set; } = "";

        public Boolean createCard(string room, DateTime endDate)
        {
            LastError = "";
            RoomLock roomLock = GetRoomLock(room);
            if (roomLock == null)
            {
                return false;
            }

            if (roomLock.Vendor == ProUsb)
            {
                bool ok = proUsb.createCard(room, endDate, roomLock.LockNo);
                LastError = ok ? "" : "proUSB: " + proUsb.LastError;
                return ok;
            }

            if (!onity.createCard(room, endDate))
            {
                LastError = "Onity: periksa koneksi encoder IP dan Port.";
                return false;
            }
            return true;
        }

        public Boolean checkoutCard(string room)
        {
            LastError = "";
            RoomLock roomLock = GetRoomLock(room);
            if (roomLock == null)
            {
                return false;
            }

            if (roomLock.Vendor == ProUsb)
            {
                bool ok = proUsb.checkoutCard(room);
                LastError = ok ? "" : "proUSB: " + proUsb.LastError;
                return ok;
            }

            return onity.checkoutCard(room);
        }

        /// <summary>
        /// Kartu yang dibaca belum diketahui vendornya: coba encoder proUSB (lokal, cepat gagal) lalu Onity.
        /// </summary>
        public string readCard()
        {
            ProUsbCardInfo info = readProUsbCardInfo();
            if (info != null && info.LockNo != "")
            {
                return info.Room != "" ? info.Room : "LockNo " + info.LockNo;
            }
            return onity.readCard();
        }

        public string readOnityCard()
        {
            return onity.readCard();
        }

        /// <summary>
        /// Uji tulis kartu tamu proUSB langsung dengan LockNo, tanpa lewat setting kamar di backend.
        /// </summary>
        public Boolean writeProUsbTestCard(string lockNo, DateTime endDate)
        {
            bool ok = proUsb.createCard("LockNo " + lockNo, endDate, lockNo);
            LastError = ok ? "" : proUsb.LastError;
            return ok;
        }

        public Boolean writeProUsbRoomSetCard(string lockNo, byte dai)
        {
            bool ok = proUsb.createRoomSetCard(lockNo, dai);
            LastError = ok ? "" : proUsb.LastError;
            return ok;
        }

        public Boolean writeProUsbTimeSetCard(byte dai)
        {
            bool ok = proUsb.createTimeSetCard(dai);
            LastError = ok ? "" : proUsb.LastError;
            return ok;
        }

        /// <summary>
        /// Semua kamar dari server beserta setting door lock-nya (untuk pilihan kamar di Door Lock Setup).
        /// Null kalau server tidak bisa dihubungi.
        /// </summary>
        public List<DoorLockRoom> getRooms()
        {
            HttpData result = conn.GetRoomList().GetAwaiter().GetResult();
            if (!result.status || result.data == null)
            {
                LastError = "Gagal mengambil daftar kamar dari server. " + (result.message ?? "");
                return null;
            }

            Dictionary<string, RoomLock> map = LoadRoomLocks();
            var rooms = new List<DoorLockRoom>();
            foreach (JToken item in JArray.Parse(result.data.ToString()))
            {
                string name = (string)item["ROOM NAME"] ?? "";
                RoomLock roomLock;
                if (map == null || !map.TryGetValue(RoomKey(name), out roomLock))
                {
                    roomLock = new RoomLock { Vendor = Onity, LockNo = "" };
                }
                rooms.Add(new DoorLockRoom { Name = name, Vendor = roomLock.Vendor, LockNo = roomLock.LockNo });
            }
            return rooms;
        }

        public ProUsbCardInfo readProUsbCardInfo()
        {
            ProUsbCardInfo info = proUsb.readCardInfo();
            LastError = info == null ? proUsb.LastError : "";
            if (info != null && info.LockNo != "")
            {
                // Nomor kamar dicari dari lock_no di backend / file dummy
                Dictionary<string, RoomLock> map = LoadRoomLocks();
                if (map != null)
                {
                    info.Room = map.Where(kv => kv.Value.Vendor == ProUsb && kv.Value.LockNo == info.LockNo)
                        .Select(kv => kv.Key).FirstOrDefault() ?? "";
                }
            }
            return info;
        }

        public static void ClearCache()
        {
            lock (cacheLock)
            {
                roomLocks = null;
            }
        }

        /// <summary>
        /// File uji coba: kalau ada, setting door lock diambil dari file ini, bukan dari backend.
        /// </summary>
        public static string DummyFilePath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "doorlock_dummy.txt"); }
        }

        public static bool IsDummyMode
        {
            get { return File.Exists(DummyFilePath); }
        }

        private RoomLock GetRoomLock(string room)
        {
            string key = RoomKey(room);
            RoomLock roomLock;

            if (!IsDummyMode)
            {
                lock (cacheLock)
                {
                    bool fresh = roomLocks != null && DateTime.Now - roomLocksLoadedAt < CacheDuration;
                    if (fresh && roomLocks.TryGetValue(key, out roomLock))
                    {
                        return roomLock;
                    }
                }
            }

            Dictionary<string, RoomLock> map = LoadRoomLocks(forceReload: true);
            if (map == null)
            {
                return null;
            }

            if (map.TryGetValue(key, out roomLock))
            {
                Console.WriteLine($"Door lock{(IsDummyMode ? " DUMMY" : "")}: kamar {room} -> {roomLock.Vendor} {roomLock.LockNo}");
                return roomLock;
            }

            Console.WriteLine($"Door lock: kamar {room} tidak ada di backend, pakai Onity");
            return new RoomLock { Vendor = Onity, LockNo = "" };
        }

        /// <summary>
        /// Setting door lock semua kamar: dari file dummy kalau ada, selain itu dari backend (cache 5 menit).
        /// Null kalau backend tidak bisa dihubungi (LastError diisi).
        /// </summary>
        private Dictionary<string, RoomLock> LoadRoomLocks(bool forceReload = false)
        {
            if (IsDummyMode)
            {
                return LoadDummyRoomLocks();
            }

            lock (cacheLock)
            {
                if (!forceReload && roomLocks != null && DateTime.Now - roomLocksLoadedAt < CacheDuration)
                {
                    return roomLocks;
                }
            }

            // Dipanggil dari Task.Run / BackgroundWorker, jadi aman menunggu hasil HTTP secara sinkron
            HttpData result = conn.GetRoomList().GetAwaiter().GetResult();
            if (!result.status || result.data == null)
            {
                LastError = "Gagal mengambil pengaturan door lock kamar dari server. " + (result.message ?? "");
                return null;
            }

            var loaded = new Dictionary<string, RoomLock>();
            foreach (JToken item in JArray.Parse(result.data.ToString()))
            {
                string roomKey = RoomKey((string)item["ROOM NAME"]);
                if (roomKey == "" || loaded.ContainsKey(roomKey))
                {
                    continue;
                }

                string vendor = ((string)item["door_lock"] ?? "").Trim().ToLowerInvariant();
                loaded[roomKey] = new RoomLock
                {
                    Vendor = vendor == ProUsb ? ProUsb : Onity,
                    LockNo = ((string)item["lock_no"] ?? "").Trim(),
                };
            }

            lock (cacheLock)
            {
                roomLocks = loaded;
                roomLocksLoadedAt = DateTime.Now;
            }
            return loaded;
        }

        // Format per baris: kamar=onity  |  kamar=prousb  |  kamar=prousb,LockNo   (# = komentar)
        private static Dictionary<string, RoomLock> LoadDummyRoomLocks()
        {
            var map = new Dictionary<string, RoomLock>();
            foreach (string raw in File.ReadAllLines(DummyFilePath))
            {
                string line = raw.Trim();
                if (line == "" || line.StartsWith("#") || !line.Contains("="))
                {
                    continue;
                }

                string[] parts = line.Split('=');
                string[] value = parts[1].Split(',');
                string vendor = value[0].Trim().ToLowerInvariant();
                map[RoomKey(parts[0])] = new RoomLock
                {
                    Vendor = vendor == ProUsb ? ProUsb : Onity,
                    LockNo = value.Length > 1 ? value[1].Trim() : "",
                };
            }
            return map;
        }

        // Sama dengan cara BookingsScreen mengambil nomor kamar: angka dari bagian sebelum '-'
        private static string RoomKey(string room)
        {
            if (string.IsNullOrEmpty(room))
            {
                return "";
            }
            return Regex.Replace(room.Split('-')[0], @"[^\d]", "");
        }

        private class RoomLock
        {
            public string Vendor { get; set; }
            public string LockNo { get; set; }
        }
    }

    internal class DoorLockRoom
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string LockNo { get; set; }

        public override string ToString()
        {
            return Vendor == DoorLockConnection.ProUsb
                ? $"{Name} - proUSB {(LockNo != "" ? LockNo : "(lock_no kosong)")}"
                : $"{Name} - Onity";
        }
    }
}
