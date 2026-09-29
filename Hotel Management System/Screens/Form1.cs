using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Screens
{
    public partial class Form1 : Form
    {
        DoorLockConnection onity = new DoorLockConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPtextBox1.Text = Properties.Settings.Default.OnityIP;
            PorttextBox2.Text = Properties.Settings.Default.OnityPort;
            ProUsbHotelIdTextBox.Text = Properties.Settings.Default.ProUsbHotelId;
            ProUsbDaiTextBox.Text = Properties.Settings.Default.ProUsbDai;
            ProUsbSettingDaiTextBox.Text = Properties.Settings.Default.ProUsbSettingDai;
            TestCheckoutPicker.Value = DateTime.Today.AddDays(1);

            if (DoorLockConnection.IsDummyMode)
            {
                Text = "Door Lock Setup - MODE DUMMY (doorlock_dummy.txt)";
            }

            LoadRooms();
        }

        #region Onity

        private void btnSaveOnity_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OnityIP = IPtextBox1.Text.Trim();
            Properties.Settings.Default.OnityPort = PorttextBox2.Text.Trim();
            Properties.Settings.Default.Save();
            MessageBox.Show("Konfigurasi Onity tersimpan");
        }

        private async void btnReadOnity_Click(object sender, EventArgs e)
        {
            btnReadOnity.Enabled = false;
            OnityResultTextBox.Text = "Membaca kartu...";
            try
            {
                string room = await Task.Run(() => onity.readOnityCard());
                OnityResultTextBox.Text = room != "" ? "Kamar: " + room : "Gagal membaca kartu Onity. Periksa IP/Port encoder.";
            }
            finally
            {
                btnReadOnity.Enabled = true;
            }
        }

        #endregion

        #region proUSB

        private void btnSaveProUsb_Click(object sender, EventArgs e)
        {
            int hotelId;
            byte dai, settingDai;
            if (!int.TryParse(ProUsbHotelIdTextBox.Text, out hotelId))
            {
                MessageBox.Show("Hotel ID proUSB harus angka (lihat dlsCoID di System.ini proUSB).");
                return;
            }
            if (!byte.TryParse(ProUsbDaiTextBox.Text, out dai) || !byte.TryParse(ProUsbSettingDaiTextBox.Text, out settingDai))
            {
                MessageBox.Show("Dai harus angka 0-255.");
                return;
            }

            Properties.Settings.Default.ProUsbHotelId = ProUsbHotelIdTextBox.Text.Trim();
            Properties.Settings.Default.ProUsbDai = dai.ToString();
            Properties.Settings.Default.ProUsbSettingDai = settingDai.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("Konfigurasi proUSB tersimpan");
        }

        private async void LoadRooms()
        {
            RoomComboBox.Items.Clear();
            RoomComboBox.Items.Add("Memuat daftar kamar...");
            RoomComboBox.SelectedIndex = 0;
            RoomComboBox.Enabled = false;

            List<DoorLockRoom> rooms = await Task.Run(() => onity.getRooms());

            RoomComboBox.Items.Clear();
            if (rooms == null)
            {
                RoomComboBox.Items.Add("(gagal memuat kamar - isi Lock No manual)");
                RoomComboBox.SelectedIndex = 0;
                ProUsbResultTextBox.Text = onity.LastError;
                return;
            }

            RoomComboBox.Items.Add("(isi Lock No manual)");
            foreach (DoorLockRoom room in rooms)
            {
                RoomComboBox.Items.Add(room);
            }
            RoomComboBox.SelectedIndex = 0;
            RoomComboBox.Enabled = true;
        }

        private void RoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var room = RoomComboBox.SelectedItem as DoorLockRoom;
            if (room == null)
            {
                return;
            }

            if (room.Vendor == DoorLockConnection.ProUsb && room.LockNo != "")
            {
                TestLockNoTextBox.Text = room.LockNo;
                ProUsbResultTextBox.Text = $"{room.Name}: Lock No {room.LockNo}";
            }
            else
            {
                TestLockNoTextBox.Text = "";
                ProUsbResultTextBox.Text = room.Vendor == DoorLockConnection.ProUsb
                    ? $"{room.Name} memakai proUSB tapi lock_no belum diisi di backend."
                    : $"{room.Name} memakai Onity (door_lock di backend belum proUSB).";
            }
        }

        private async void btnReadProUsb_Click(object sender, EventArgs e)
        {
            btnReadProUsb.Enabled = false;
            ProUsbResultTextBox.Text = "Membaca kartu...";
            try
            {
                var info = await Task.Run(() => onity.readProUsbCardInfo());
                ProUsbResultTextBox.Text = info == null ? onity.LastError : FormatCard(info);
            }
            finally
            {
                btnReadProUsb.Enabled = true;
            }
        }

        private async void btnWriteGuest_Click(object sender, EventArgs e)
        {
            string lockNo;
            if (!TryGetLockNo(out lockNo))
            {
                return;
            }

            DateTime checkout = TestCheckoutPicker.Value.Date;
            if (!Confirm($"Tulis KARTU TAMU untuk Lock No {lockNo}, berlaku sampai {checkout:dd-MM-yyyy} 12:00?\n\n" +
                "Kartu di encoder akan ditimpa, dan kartu tamu lama kamar ini tidak berlaku lagi."))
            {
                return;
            }

            await WriteAndVerify(btnWriteGuest, () => onity.writeProUsbTestCard(lockNo, checkout));
        }

        private async void btnWriteRoomSet_Click(object sender, EventArgs e)
        {
            string lockNo;
            if (!TryGetLockNo(out lockNo))
            {
                return;
            }

            byte dai = byte.Parse(Properties.Settings.Default.ProUsbSettingDai);
            if (!Confirm($"Tulis KARTU SET NOMOR KAMAR untuk Lock No {lockNo}?\n\n" +
                "Kunci pintu yang ditempel kartu ini akan berganti nomor menjadi " + lockNo + ".\n" +
                "Pastikan kartu ini hanya ditempel ke pintu kamar yang benar.",
                MessageBoxIcon.Warning))
            {
                return;
            }

            await WriteAndVerify(btnWriteRoomSet, () => onity.writeProUsbRoomSetCard(lockNo, dai));
        }

        private async void btnWriteTimeSet_Click(object sender, EventArgs e)
        {
            byte dai = byte.Parse(Properties.Settings.Default.ProUsbSettingDai);
            if (!Confirm($"Tulis KARTU SET WAKTU dengan jam PC sekarang ({DateTime.Now:dd-MM-yyyy HH:mm})?\n\n" +
                "Pastikan jam PC ini sudah benar. Kunci pintu yang ditempel kartu ini akan memakai jam tersebut.",
                MessageBoxIcon.Warning))
            {
                return;
            }

            await WriteAndVerify(btnWriteTimeSet, () => onity.writeProUsbTimeSetCard(dai));
        }

        private bool TryGetLockNo(out string lockNo)
        {
            lockNo = TestLockNoTextBox.Text.Trim();
            if (lockNo.Length == 8 && lockNo.All(char.IsDigit))
            {
                return true;
            }

            MessageBox.Show("Lock No harus 8 digit, sesuai kolom Lock No. di CardLock (Rooms Definition), mis. 01010199.");
            return false;
        }

        private static bool Confirm(string message, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(message, "Tulis Kartu proUSB", MessageBoxButtons.YesNo, icon) == DialogResult.Yes;
        }

        // Tulis kartu lalu baca ulang untuk memastikan isinya
        private async Task WriteAndVerify(Button button, Func<bool> write)
        {
            button.Enabled = false;
            ProUsbResultTextBox.Text = "Menulis kartu...";
            try
            {
                bool ok = await Task.Run(write);
                if (!ok)
                {
                    ProUsbResultTextBox.Text = "GAGAL: " + onity.LastError;
                    return;
                }

                var info = await Task.Run(() => onity.readProUsbCardInfo());
                ProUsbResultTextBox.Text = info == null
                    ? "Kartu ditulis, tapi gagal dibaca ulang: " + onity.LastError
                    : "BERHASIL ditulis\r\n" + FormatCard(info);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private static string FormatCard(ProUsbCardInfo info)
        {
            if (info.LockNo == "")
            {
                return info.CardType + "\r\n" +
                    (info.StartTime != null ? $"Dibuat: {info.StartTime:dd-MM-yyyy HH:mm}\r\n" : "") +
                    (info.EndTime != null && info.EndTime != info.StartTime ? $"Berlaku s/d: {info.EndTime:dd-MM-yyyy HH:mm}\r\n" : "") +
                    (info.HotelId != 0 ? $"Hotel ID: {info.HotelId}  Dai: {info.Dai}\r\n" : "") +
                    $"Data: {info.RawData}";
            }

            return $"{info.CardType}\r\n" +
                $"Kamar: {(info.Room != "" ? info.Room : "(lock_no tidak ada di backend)")}\r\n" +
                $"LockNo: {info.LockNo}\r\n" +
                $"Mulai: {info.StartTime:dd-MM-yyyy HH:mm}   Berlaku s/d: {info.EndTime:dd-MM-yyyy HH:mm}\r\n" +
                $"Hotel ID: {info.HotelId}   Dai: {info.Dai}   CardNo: {info.CardNo}";
        }

        #endregion
    }
}
