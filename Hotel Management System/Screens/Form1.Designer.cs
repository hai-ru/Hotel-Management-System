namespace Hotel_Management_System.Screens
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOnity = new System.Windows.Forms.TabPage();
            this.grpOnitySetup = new System.Windows.Forms.GroupBox();
            this.lblOnityIp = new System.Windows.Forms.Label();
            this.IPtextBox1 = new System.Windows.Forms.TextBox();
            this.lblOnityPort = new System.Windows.Forms.Label();
            this.PorttextBox2 = new System.Windows.Forms.TextBox();
            this.btnSaveOnity = new System.Windows.Forms.Button();
            this.grpOnityRead = new System.Windows.Forms.GroupBox();
            this.btnReadOnity = new System.Windows.Forms.Button();
            this.OnityResultTextBox = new System.Windows.Forms.TextBox();
            this.tabProUsb = new System.Windows.Forms.TabPage();
            this.grpProUsbConfig = new System.Windows.Forms.GroupBox();
            this.lblHotelId = new System.Windows.Forms.Label();
            this.ProUsbHotelIdTextBox = new System.Windows.Forms.TextBox();
            this.lblDai = new System.Windows.Forms.Label();
            this.ProUsbDaiTextBox = new System.Windows.Forms.TextBox();
            this.lblSettingDai = new System.Windows.Forms.Label();
            this.ProUsbSettingDaiTextBox = new System.Windows.Forms.TextBox();
            this.btnSaveProUsb = new System.Windows.Forms.Button();
            this.grpProUsbRead = new System.Windows.Forms.GroupBox();
            this.btnReadProUsb = new System.Windows.Forms.Button();
            this.grpProUsbWrite = new System.Windows.Forms.GroupBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.RoomComboBox = new System.Windows.Forms.ComboBox();
            this.lblLockNo = new System.Windows.Forms.Label();
            this.TestLockNoTextBox = new System.Windows.Forms.TextBox();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.TestCheckoutPicker = new System.Windows.Forms.DateTimePicker();
            this.btnWriteGuest = new System.Windows.Forms.Button();
            this.btnWriteRoomSet = new System.Windows.Forms.Button();
            this.btnWriteTimeSet = new System.Windows.Forms.Button();
            this.lblSettingNote = new System.Windows.Forms.Label();
            this.grpProUsbResult = new System.Windows.Forms.GroupBox();
            this.ProUsbResultTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabOnity.SuspendLayout();
            this.grpOnitySetup.SuspendLayout();
            this.grpOnityRead.SuspendLayout();
            this.tabProUsb.SuspendLayout();
            this.grpProUsbConfig.SuspendLayout();
            this.grpProUsbRead.SuspendLayout();
            this.grpProUsbWrite.SuspendLayout();
            this.grpProUsbResult.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabOnity);
            this.tabControl1.Controls.Add(this.tabProUsb);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(614, 461);
            this.tabControl1.TabIndex = 0;
            //
            // tabOnity
            //
            this.tabOnity.Controls.Add(this.grpOnitySetup);
            this.tabOnity.Controls.Add(this.grpOnityRead);
            this.tabOnity.Location = new System.Drawing.Point(4, 22);
            this.tabOnity.Name = "tabOnity";
            this.tabOnity.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnity.Size = new System.Drawing.Size(606, 435);
            this.tabOnity.TabIndex = 0;
            this.tabOnity.Text = "Onity";
            this.tabOnity.UseVisualStyleBackColor = true;
            //
            // grpOnitySetup
            //
            this.grpOnitySetup.Controls.Add(this.lblOnityIp);
            this.grpOnitySetup.Controls.Add(this.IPtextBox1);
            this.grpOnitySetup.Controls.Add(this.lblOnityPort);
            this.grpOnitySetup.Controls.Add(this.PorttextBox2);
            this.grpOnitySetup.Controls.Add(this.btnSaveOnity);
            this.grpOnitySetup.Location = new System.Drawing.Point(10, 10);
            this.grpOnitySetup.Name = "grpOnitySetup";
            this.grpOnitySetup.Size = new System.Drawing.Size(260, 160);
            this.grpOnitySetup.TabIndex = 0;
            this.grpOnitySetup.TabStop = false;
            this.grpOnitySetup.Text = "Konfigurasi Onity";
            //
            // lblOnityIp
            //
            this.lblOnityIp.AutoSize = true;
            this.lblOnityIp.Location = new System.Drawing.Point(7, 21);
            this.lblOnityIp.Name = "lblOnityIp";
            this.lblOnityIp.Size = new System.Drawing.Size(97, 13);
            this.lblOnityIp.TabIndex = 0;
            this.lblOnityIp.Text = "IP Onity Encoder";
            //
            // IPtextBox1
            //
            this.IPtextBox1.Location = new System.Drawing.Point(10, 37);
            this.IPtextBox1.Name = "IPtextBox1";
            this.IPtextBox1.Size = new System.Drawing.Size(240, 20);
            this.IPtextBox1.TabIndex = 1;
            //
            // lblOnityPort
            //
            this.lblOnityPort.AutoSize = true;
            this.lblOnityPort.Location = new System.Drawing.Point(7, 64);
            this.lblOnityPort.Name = "lblOnityPort";
            this.lblOnityPort.Size = new System.Drawing.Size(53, 13);
            this.lblOnityPort.TabIndex = 2;
            this.lblOnityPort.Text = "Port Onity";
            //
            // PorttextBox2
            //
            this.PorttextBox2.Location = new System.Drawing.Point(10, 80);
            this.PorttextBox2.Name = "PorttextBox2";
            this.PorttextBox2.Size = new System.Drawing.Size(240, 20);
            this.PorttextBox2.TabIndex = 3;
            //
            // btnSaveOnity
            //
            this.btnSaveOnity.Location = new System.Drawing.Point(10, 115);
            this.btnSaveOnity.Name = "btnSaveOnity";
            this.btnSaveOnity.Size = new System.Drawing.Size(240, 30);
            this.btnSaveOnity.TabIndex = 4;
            this.btnSaveOnity.Text = "Simpan Konfigurasi Onity";
            this.btnSaveOnity.UseVisualStyleBackColor = true;
            this.btnSaveOnity.Click += new System.EventHandler(this.btnSaveOnity_Click);
            //
            // grpOnityRead
            //
            this.grpOnityRead.Controls.Add(this.btnReadOnity);
            this.grpOnityRead.Controls.Add(this.OnityResultTextBox);
            this.grpOnityRead.Location = new System.Drawing.Point(280, 10);
            this.grpOnityRead.Name = "grpOnityRead";
            this.grpOnityRead.Size = new System.Drawing.Size(314, 160);
            this.grpOnityRead.TabIndex = 1;
            this.grpOnityRead.TabStop = false;
            this.grpOnityRead.Text = "Baca Kartu Onity";
            //
            // btnReadOnity
            //
            this.btnReadOnity.Location = new System.Drawing.Point(10, 22);
            this.btnReadOnity.Name = "btnReadOnity";
            this.btnReadOnity.Size = new System.Drawing.Size(294, 30);
            this.btnReadOnity.TabIndex = 0;
            this.btnReadOnity.Text = "Baca Kartu Onity";
            this.btnReadOnity.UseVisualStyleBackColor = true;
            this.btnReadOnity.Click += new System.EventHandler(this.btnReadOnity_Click);
            //
            // OnityResultTextBox
            //
            this.OnityResultTextBox.Location = new System.Drawing.Point(10, 60);
            this.OnityResultTextBox.Multiline = true;
            this.OnityResultTextBox.Name = "OnityResultTextBox";
            this.OnityResultTextBox.ReadOnly = true;
            this.OnityResultTextBox.Size = new System.Drawing.Size(294, 90);
            this.OnityResultTextBox.TabIndex = 1;
            //
            // tabProUsb
            //
            this.tabProUsb.Controls.Add(this.grpProUsbConfig);
            this.tabProUsb.Controls.Add(this.grpProUsbRead);
            this.tabProUsb.Controls.Add(this.grpProUsbWrite);
            this.tabProUsb.Controls.Add(this.grpProUsbResult);
            this.tabProUsb.Location = new System.Drawing.Point(4, 22);
            this.tabProUsb.Name = "tabProUsb";
            this.tabProUsb.Padding = new System.Windows.Forms.Padding(3);
            this.tabProUsb.Size = new System.Drawing.Size(606, 435);
            this.tabProUsb.TabIndex = 1;
            this.tabProUsb.Text = "proUSB";
            this.tabProUsb.UseVisualStyleBackColor = true;
            //
            // grpProUsbConfig
            //
            this.grpProUsbConfig.Controls.Add(this.lblHotelId);
            this.grpProUsbConfig.Controls.Add(this.ProUsbHotelIdTextBox);
            this.grpProUsbConfig.Controls.Add(this.lblDai);
            this.grpProUsbConfig.Controls.Add(this.ProUsbDaiTextBox);
            this.grpProUsbConfig.Controls.Add(this.lblSettingDai);
            this.grpProUsbConfig.Controls.Add(this.ProUsbSettingDaiTextBox);
            this.grpProUsbConfig.Controls.Add(this.btnSaveProUsb);
            this.grpProUsbConfig.Location = new System.Drawing.Point(10, 10);
            this.grpProUsbConfig.Name = "grpProUsbConfig";
            this.grpProUsbConfig.Size = new System.Drawing.Size(260, 190);
            this.grpProUsbConfig.TabIndex = 0;
            this.grpProUsbConfig.TabStop = false;
            this.grpProUsbConfig.Text = "Konfigurasi proUSB";
            //
            // lblHotelId
            //
            this.lblHotelId.AutoSize = true;
            this.lblHotelId.Location = new System.Drawing.Point(7, 21);
            this.lblHotelId.Name = "lblHotelId";
            this.lblHotelId.Size = new System.Drawing.Size(140, 13);
            this.lblHotelId.TabIndex = 0;
            this.lblHotelId.Text = "Hotel ID (dlsCoID)";
            //
            // ProUsbHotelIdTextBox
            //
            this.ProUsbHotelIdTextBox.Location = new System.Drawing.Point(10, 37);
            this.ProUsbHotelIdTextBox.Name = "ProUsbHotelIdTextBox";
            this.ProUsbHotelIdTextBox.Size = new System.Drawing.Size(240, 20);
            this.ProUsbHotelIdTextBox.TabIndex = 1;
            //
            // lblDai
            //
            this.lblDai.AutoSize = true;
            this.lblDai.Location = new System.Drawing.Point(7, 64);
            this.lblDai.Name = "lblDai";
            this.lblDai.Size = new System.Drawing.Size(140, 13);
            this.lblDai.TabIndex = 2;
            this.lblDai.Text = "Dai kartu tamu (default 2)";
            //
            // ProUsbDaiTextBox
            //
            this.ProUsbDaiTextBox.Location = new System.Drawing.Point(10, 80);
            this.ProUsbDaiTextBox.Name = "ProUsbDaiTextBox";
            this.ProUsbDaiTextBox.Size = new System.Drawing.Size(240, 20);
            this.ProUsbDaiTextBox.TabIndex = 3;
            //
            // lblSettingDai
            //
            this.lblSettingDai.AutoSize = true;
            this.lblSettingDai.Location = new System.Drawing.Point(7, 107);
            this.lblSettingDai.Name = "lblSettingDai";
            this.lblSettingDai.Size = new System.Drawing.Size(150, 13);
            this.lblSettingDai.TabIndex = 4;
            this.lblSettingDai.Text = "Dai kartu setting (default 1)";
            //
            // ProUsbSettingDaiTextBox
            //
            this.ProUsbSettingDaiTextBox.Location = new System.Drawing.Point(10, 123);
            this.ProUsbSettingDaiTextBox.Name = "ProUsbSettingDaiTextBox";
            this.ProUsbSettingDaiTextBox.Size = new System.Drawing.Size(240, 20);
            this.ProUsbSettingDaiTextBox.TabIndex = 5;
            //
            // btnSaveProUsb
            //
            this.btnSaveProUsb.Location = new System.Drawing.Point(10, 150);
            this.btnSaveProUsb.Name = "btnSaveProUsb";
            this.btnSaveProUsb.Size = new System.Drawing.Size(240, 30);
            this.btnSaveProUsb.TabIndex = 6;
            this.btnSaveProUsb.Text = "Simpan Konfigurasi proUSB";
            this.btnSaveProUsb.UseVisualStyleBackColor = true;
            this.btnSaveProUsb.Click += new System.EventHandler(this.btnSaveProUsb_Click);
            //
            // grpProUsbRead
            //
            this.grpProUsbRead.Controls.Add(this.btnReadProUsb);
            this.grpProUsbRead.Location = new System.Drawing.Point(10, 206);
            this.grpProUsbRead.Name = "grpProUsbRead";
            this.grpProUsbRead.Size = new System.Drawing.Size(260, 62);
            this.grpProUsbRead.TabIndex = 1;
            this.grpProUsbRead.TabStop = false;
            this.grpProUsbRead.Text = "Baca Kartu proUSB";
            //
            // btnReadProUsb
            //
            this.btnReadProUsb.Location = new System.Drawing.Point(10, 22);
            this.btnReadProUsb.Name = "btnReadProUsb";
            this.btnReadProUsb.Size = new System.Drawing.Size(240, 30);
            this.btnReadProUsb.TabIndex = 0;
            this.btnReadProUsb.Text = "Baca Kartu di Encoder";
            this.btnReadProUsb.UseVisualStyleBackColor = true;
            this.btnReadProUsb.Click += new System.EventHandler(this.btnReadProUsb_Click);
            //
            // grpProUsbWrite
            //
            this.grpProUsbWrite.Controls.Add(this.lblRoom);
            this.grpProUsbWrite.Controls.Add(this.RoomComboBox);
            this.grpProUsbWrite.Controls.Add(this.lblLockNo);
            this.grpProUsbWrite.Controls.Add(this.TestLockNoTextBox);
            this.grpProUsbWrite.Controls.Add(this.lblCheckout);
            this.grpProUsbWrite.Controls.Add(this.TestCheckoutPicker);
            this.grpProUsbWrite.Controls.Add(this.btnWriteGuest);
            this.grpProUsbWrite.Controls.Add(this.btnWriteRoomSet);
            this.grpProUsbWrite.Controls.Add(this.btnWriteTimeSet);
            this.grpProUsbWrite.Controls.Add(this.lblSettingNote);
            this.grpProUsbWrite.Location = new System.Drawing.Point(280, 10);
            this.grpProUsbWrite.Name = "grpProUsbWrite";
            this.grpProUsbWrite.Size = new System.Drawing.Size(314, 258);
            this.grpProUsbWrite.TabIndex = 2;
            this.grpProUsbWrite.TabStop = false;
            this.grpProUsbWrite.Text = "Tulis Kartu proUSB";
            //
            // lblRoom
            //
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(7, 21);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(38, 13);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "Kamar";
            //
            // RoomComboBox
            //
            this.RoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoomComboBox.Location = new System.Drawing.Point(10, 37);
            this.RoomComboBox.Name = "RoomComboBox";
            this.RoomComboBox.Size = new System.Drawing.Size(294, 21);
            this.RoomComboBox.TabIndex = 1;
            this.RoomComboBox.SelectedIndexChanged += new System.EventHandler(this.RoomComboBox_SelectedIndexChanged);
            //
            // lblLockNo
            //
            this.lblLockNo.AutoSize = true;
            this.lblLockNo.Location = new System.Drawing.Point(7, 65);
            this.lblLockNo.Name = "lblLockNo";
            this.lblLockNo.Size = new System.Drawing.Size(92, 13);
            this.lblLockNo.TabIndex = 2;
            this.lblLockNo.Text = "Lock No (8 digit)";
            //
            // TestLockNoTextBox
            //
            this.TestLockNoTextBox.Location = new System.Drawing.Point(10, 81);
            this.TestLockNoTextBox.MaxLength = 8;
            this.TestLockNoTextBox.Name = "TestLockNoTextBox";
            this.TestLockNoTextBox.Size = new System.Drawing.Size(140, 20);
            this.TestLockNoTextBox.TabIndex = 3;
            //
            // lblCheckout
            //
            this.lblCheckout.AutoSize = true;
            this.lblCheckout.Location = new System.Drawing.Point(161, 65);
            this.lblCheckout.Name = "lblCheckout";
            this.lblCheckout.Size = new System.Drawing.Size(120, 13);
            this.lblCheckout.TabIndex = 4;
            this.lblCheckout.Text = "Checkout (jam 12:00)";
            //
            // TestCheckoutPicker
            //
            this.TestCheckoutPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TestCheckoutPicker.Location = new System.Drawing.Point(164, 81);
            this.TestCheckoutPicker.Name = "TestCheckoutPicker";
            this.TestCheckoutPicker.Size = new System.Drawing.Size(140, 20);
            this.TestCheckoutPicker.TabIndex = 5;
            //
            // btnWriteGuest
            //
            this.btnWriteGuest.Location = new System.Drawing.Point(10, 112);
            this.btnWriteGuest.Name = "btnWriteGuest";
            this.btnWriteGuest.Size = new System.Drawing.Size(294, 30);
            this.btnWriteGuest.TabIndex = 6;
            this.btnWriteGuest.Text = "Tulis Kartu Tamu";
            this.btnWriteGuest.UseVisualStyleBackColor = true;
            this.btnWriteGuest.Click += new System.EventHandler(this.btnWriteGuest_Click);
            //
            // btnWriteRoomSet
            //
            this.btnWriteRoomSet.Location = new System.Drawing.Point(10, 150);
            this.btnWriteRoomSet.Name = "btnWriteRoomSet";
            this.btnWriteRoomSet.Size = new System.Drawing.Size(294, 30);
            this.btnWriteRoomSet.TabIndex = 7;
            this.btnWriteRoomSet.Text = "Tulis Kartu Set Nomor Kamar (Room Setting)";
            this.btnWriteRoomSet.UseVisualStyleBackColor = true;
            this.btnWriteRoomSet.Click += new System.EventHandler(this.btnWriteRoomSet_Click);
            //
            // btnWriteTimeSet
            //
            this.btnWriteTimeSet.Location = new System.Drawing.Point(10, 186);
            this.btnWriteTimeSet.Name = "btnWriteTimeSet";
            this.btnWriteTimeSet.Size = new System.Drawing.Size(294, 30);
            this.btnWriteTimeSet.TabIndex = 8;
            this.btnWriteTimeSet.Text = "Tulis Kartu Set Waktu (Time Setting)";
            this.btnWriteTimeSet.UseVisualStyleBackColor = true;
            this.btnWriteTimeSet.Click += new System.EventHandler(this.btnWriteTimeSet_Click);
            //
            // lblSettingNote
            //
            this.lblSettingNote.ForeColor = System.Drawing.Color.Firebrick;
            this.lblSettingNote.Location = new System.Drawing.Point(7, 222);
            this.lblSettingNote.Name = "lblSettingNote";
            this.lblSettingNote.Size = new System.Drawing.Size(300, 30);
            this.lblSettingNote.TabIndex = 9;
            this.lblSettingNote.Text = "Kartu setting untuk teknisi/admin. Room Setting mengubah nomor kunci pintu yang ditempel.";
            //
            // grpProUsbResult
            //
            this.grpProUsbResult.Controls.Add(this.ProUsbResultTextBox);
            this.grpProUsbResult.Location = new System.Drawing.Point(10, 274);
            this.grpProUsbResult.Name = "grpProUsbResult";
            this.grpProUsbResult.Size = new System.Drawing.Size(584, 150);
            this.grpProUsbResult.TabIndex = 3;
            this.grpProUsbResult.TabStop = false;
            this.grpProUsbResult.Text = "Hasil";
            //
            // ProUsbResultTextBox
            //
            this.ProUsbResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProUsbResultTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.ProUsbResultTextBox.Multiline = true;
            this.ProUsbResultTextBox.Name = "ProUsbResultTextBox";
            this.ProUsbResultTextBox.ReadOnly = true;
            this.ProUsbResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProUsbResultTextBox.TabIndex = 0;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Door Lock Setup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOnity.ResumeLayout(false);
            this.grpOnitySetup.ResumeLayout(false);
            this.grpOnitySetup.PerformLayout();
            this.grpOnityRead.ResumeLayout(false);
            this.grpOnityRead.PerformLayout();
            this.tabProUsb.ResumeLayout(false);
            this.grpProUsbConfig.ResumeLayout(false);
            this.grpProUsbConfig.PerformLayout();
            this.grpProUsbRead.ResumeLayout(false);
            this.grpProUsbWrite.ResumeLayout(false);
            this.grpProUsbWrite.PerformLayout();
            this.grpProUsbResult.ResumeLayout(false);
            this.grpProUsbResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOnity;
        private System.Windows.Forms.GroupBox grpOnitySetup;
        private System.Windows.Forms.Label lblOnityIp;
        private System.Windows.Forms.TextBox IPtextBox1;
        private System.Windows.Forms.Label lblOnityPort;
        private System.Windows.Forms.TextBox PorttextBox2;
        private System.Windows.Forms.Button btnSaveOnity;
        private System.Windows.Forms.GroupBox grpOnityRead;
        private System.Windows.Forms.Button btnReadOnity;
        private System.Windows.Forms.TextBox OnityResultTextBox;
        private System.Windows.Forms.TabPage tabProUsb;
        private System.Windows.Forms.GroupBox grpProUsbConfig;
        private System.Windows.Forms.Label lblHotelId;
        private System.Windows.Forms.TextBox ProUsbHotelIdTextBox;
        private System.Windows.Forms.Label lblDai;
        private System.Windows.Forms.TextBox ProUsbDaiTextBox;
        private System.Windows.Forms.Label lblSettingDai;
        private System.Windows.Forms.TextBox ProUsbSettingDaiTextBox;
        private System.Windows.Forms.Button btnSaveProUsb;
        private System.Windows.Forms.GroupBox grpProUsbRead;
        private System.Windows.Forms.Button btnReadProUsb;
        private System.Windows.Forms.GroupBox grpProUsbWrite;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox RoomComboBox;
        private System.Windows.Forms.Label lblLockNo;
        private System.Windows.Forms.TextBox TestLockNoTextBox;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.DateTimePicker TestCheckoutPicker;
        private System.Windows.Forms.Button btnWriteGuest;
        private System.Windows.Forms.Button btnWriteRoomSet;
        private System.Windows.Forms.Button btnWriteTimeSet;
        private System.Windows.Forms.Label lblSettingNote;
        private System.Windows.Forms.GroupBox grpProUsbResult;
        private System.Windows.Forms.TextBox ProUsbResultTextBox;
    }
}
