using System;

namespace Hotel_Management_System.Controllers
{
    partial class BookingsScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkinPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.checkoutPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.amountField = new Guna.UI2.WinForms.Guna2TextBox();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bookingTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.FilterTableCheckinDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.depositField = new Guna.UI2.WinForms.Guna2TextBox();
            this.paymentComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.otaComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.depositTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.noteTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.bookingIdField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.kamarTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guestIdCMBox = new System.Windows.Forms.ComboBox();
            this.reservasiCb = new System.Windows.Forms.ComboBox();
            this.NoKamarcomboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.loadingText = new System.Windows.Forms.Label();
            this.kosongText = new System.Windows.Forms.Label();
            this.printCard = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bookingIdTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bookingTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Check In";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(9, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nama Tamu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(767, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(10, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "Check-in";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label6.Location = new System.Drawing.Point(157, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "Check-out";
            // 
            // checkinPicker
            // 
            this.checkinPicker.BackColor = System.Drawing.Color.Transparent;
            this.checkinPicker.BorderRadius = 15;
            this.checkinPicker.Checked = true;
            this.checkinPicker.CustomFormat = "yyyy-MM-dd";
            this.checkinPicker.FillColor = System.Drawing.Color.DimGray;
            this.checkinPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkinPicker.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkinPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.checkinPicker.Location = new System.Drawing.Point(9, 140);
            this.checkinPicker.Margin = new System.Windows.Forms.Padding(2);
            this.checkinPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkinPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkinPicker.Name = "checkinPicker";
            this.checkinPicker.Size = new System.Drawing.Size(129, 36);
            this.checkinPicker.TabIndex = 70;
            this.checkinPicker.Value = new System.DateTime(2024, 7, 17, 1, 4, 43, 652);
            this.checkinPicker.ValueChanged += new System.EventHandler(this.checkinPicker_ValueChanged);
            // 
            // checkoutPicker
            // 
            this.checkoutPicker.BackColor = System.Drawing.Color.Transparent;
            this.checkoutPicker.BorderRadius = 15;
            this.checkoutPicker.Checked = true;
            this.checkoutPicker.CustomFormat = "yyyy-MM-dd";
            this.checkoutPicker.FillColor = System.Drawing.Color.DimGray;
            this.checkoutPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkoutPicker.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkoutPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.checkoutPicker.Location = new System.Drawing.Point(161, 140);
            this.checkoutPicker.Margin = new System.Windows.Forms.Padding(2);
            this.checkoutPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkoutPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkoutPicker.Name = "checkoutPicker";
            this.checkoutPicker.Size = new System.Drawing.Size(126, 36);
            this.checkoutPicker.TabIndex = 71;
            this.checkoutPicker.Value = new System.DateTime(2024, 7, 22, 0, 4, 28, 0);
            this.checkoutPicker.ValueChanged += new System.EventHandler(this.checkoutPicker_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label8.Location = new System.Drawing.Point(8, 244);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Harga Total";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // amountField
            // 
            this.amountField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.amountField.DefaultText = "";
            this.amountField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.amountField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.amountField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountField.Location = new System.Drawing.Point(11, 266);
            this.amountField.Name = "amountField";
            this.amountField.PasswordChar = '\0';
            this.amountField.PlaceholderText = "";
            this.amountField.ReadOnly = true;
            this.amountField.SelectedText = "";
            this.amountField.Size = new System.Drawing.Size(152, 32);
            this.amountField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.amountField.TabIndex = 75;
            this.amountField.TextChanged += new System.EventHandler(this.amountField_TextChanged);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BorderRadius = 20;
            this.addButton.BorderThickness = 1;
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addButton.Location = new System.Drawing.Point(4, 534);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(150, 25);
            this.addButton.TabIndex = 80;
            this.addButton.Text = "ADD";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(9, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 88;
            this.label7.Text = "No. Kamar";
            // 
            // bookingTable
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.bookingTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bookingTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bookingTable.ColumnHeadersHeight = 40;
            this.bookingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bookingTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.bookingTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bookingTable.Location = new System.Drawing.Point(32, 54);
            this.bookingTable.Name = "bookingTable";
            this.bookingTable.ReadOnly = true;
            this.bookingTable.RowHeadersVisible = false;
            this.bookingTable.RowHeadersWidth = 51;
            this.bookingTable.RowTemplate.Height = 35;
            this.bookingTable.Size = new System.Drawing.Size(908, 537);
            this.bookingTable.TabIndex = 115;
            this.bookingTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.bookingTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.bookingTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.bookingTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.bookingTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.bookingTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.bookingTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bookingTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.bookingTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bookingTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bookingTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.bookingTable.ThemeStyle.HeaderStyle.Height = 40;
            this.bookingTable.ThemeStyle.ReadOnly = true;
            this.bookingTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.bookingTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bookingTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.bookingTable.ThemeStyle.RowsStyle.Height = 35;
            this.bookingTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bookingTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.bookingTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingTable_CellContentClick);
            this.bookingTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingTable_CellDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label9.Location = new System.Drawing.Point(9, 301);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "Total Pembayaran";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // FilterTableCheckinDate
            // 
            this.FilterTableCheckinDate.BackColor = System.Drawing.Color.Transparent;
            this.FilterTableCheckinDate.BorderRadius = 15;
            this.FilterTableCheckinDate.Checked = true;
            this.FilterTableCheckinDate.CustomFormat = "yyyy-MM-dd";
            this.FilterTableCheckinDate.FillColor = System.Drawing.Color.DimGray;
            this.FilterTableCheckinDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FilterTableCheckinDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.FilterTableCheckinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FilterTableCheckinDate.Location = new System.Drawing.Point(153, 15);
            this.FilterTableCheckinDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.FilterTableCheckinDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.FilterTableCheckinDate.Name = "FilterTableCheckinDate";
            this.FilterTableCheckinDate.Size = new System.Drawing.Size(152, 36);
            this.FilterTableCheckinDate.TabIndex = 120;
            this.FilterTableCheckinDate.Value = new System.DateTime(2024, 8, 5, 0, 0, 0, 0);
            this.FilterTableCheckinDate.ValueChanged += new System.EventHandler(this.FilterTableCheckinDate_ValueChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button1.Location = new System.Drawing.Point(4, 563);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(150, 27);
            this.guna2Button1.TabIndex = 121;
            this.guna2Button1.Text = "WRITE CARD";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button2.Location = new System.Drawing.Point(161, 563);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(155, 28);
            this.guna2Button2.TabIndex = 122;
            this.guna2Button2.Text = "READ CARD";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // depositField
            // 
            this.depositField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.depositField.DefaultText = "";
            this.depositField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.depositField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.depositField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.depositField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.depositField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.depositField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.depositField.Location = new System.Drawing.Point(11, 323);
            this.depositField.Name = "depositField";
            this.depositField.PasswordChar = '\0';
            this.depositField.PlaceholderText = "";
            this.depositField.SelectedText = "";
            this.depositField.Size = new System.Drawing.Size(279, 32);
            this.depositField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.depositField.TabIndex = 118;
            this.depositField.TextChanged += new System.EventHandler(this.depositField_TextChanged);
            // 
            // paymentComboBox
            // 
            this.paymentComboBox.BackColor = System.Drawing.Color.Transparent;
            this.paymentComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.paymentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.paymentComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.paymentComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.paymentComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.paymentComboBox.ItemHeight = 30;
            this.paymentComboBox.Location = new System.Drawing.Point(10, 379);
            this.paymentComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.paymentComboBox.Name = "paymentComboBox";
            this.paymentComboBox.Size = new System.Drawing.Size(128, 36);
            this.paymentComboBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.paymentComboBox.TabIndex = 124;
            this.paymentComboBox.SelectedIndexChanged += new System.EventHandler(this.paymentComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(4, 357);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "Metode Bayar";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // otaComboBox
            // 
            this.otaComboBox.BackColor = System.Drawing.Color.Transparent;
            this.otaComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.otaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otaComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otaComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otaComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.otaComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.otaComboBox.ItemHeight = 30;
            this.otaComboBox.Location = new System.Drawing.Point(146, 379);
            this.otaComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.otaComboBox.Name = "otaComboBox";
            this.otaComboBox.Size = new System.Drawing.Size(144, 36);
            this.otaComboBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.otaComboBox.TabIndex = 126;
            this.otaComboBox.SelectedIndexChanged += new System.EventHandler(this.otaComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(146, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 125;
            this.label10.Text = "Agen Travel";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(7, 415);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 128;
            this.label11.Text = "Deposit";
            // 
            // depositTextBox1
            // 
            this.depositTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.depositTextBox1.DefaultText = "";
            this.depositTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.depositTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.depositTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.depositTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.depositTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.depositTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.depositTextBox1.Location = new System.Drawing.Point(10, 438);
            this.depositTextBox1.Name = "depositTextBox1";
            this.depositTextBox1.PasswordChar = '\0';
            this.depositTextBox1.PlaceholderText = "";
            this.depositTextBox1.SelectedText = "";
            this.depositTextBox1.Size = new System.Drawing.Size(279, 32);
            this.depositTextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.depositTextBox1.TabIndex = 127;
            this.depositTextBox1.TextChanged += new System.EventHandler(this.depositTextBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(10, 470);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 130;
            this.label12.Text = "Catatan";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.noteTextBox.DefaultText = "";
            this.noteTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.noteTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.noteTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.noteTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.noteTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.noteTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.noteTextBox.Location = new System.Drawing.Point(11, 489);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.PasswordChar = '\0';
            this.noteTextBox.PlaceholderText = "";
            this.noteTextBox.SelectedText = "";
            this.noteTextBox.Size = new System.Drawing.Size(276, 32);
            this.noteTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.noteTextBox.TabIndex = 129;
            this.noteTextBox.TextChanged += new System.EventHandler(this.noteTextBox_TextChanged);
            // 
            // bookingIdField
            // 
            this.bookingIdField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bookingIdField.DefaultText = "";
            this.bookingIdField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bookingIdField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bookingIdField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookingIdField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookingIdField.Enabled = false;
            this.bookingIdField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookingIdField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingIdField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookingIdField.Location = new System.Drawing.Point(11, 21);
            this.bookingIdField.Name = "bookingIdField";
            this.bookingIdField.PasswordChar = '\0';
            this.bookingIdField.PlaceholderText = "";
            this.bookingIdField.ReadOnly = true;
            this.bookingIdField.SelectedText = "";
            this.bookingIdField.Size = new System.Drawing.Size(95, 36);
            this.bookingIdField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.bookingIdField.TabIndex = 132;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label13.Location = new System.Drawing.Point(8, 2);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 20);
            this.label13.TabIndex = 131;
            this.label13.Text = "ID";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.BorderThickness = 1;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button3.Location = new System.Drawing.Point(161, 534);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(155, 25);
            this.guna2Button3.TabIndex = 133;
            this.guna2Button3.Text = "CLEAR";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bookingIdTextBox);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.kamarTextbox);
            this.groupBox2.Controls.Add(this.guestIdCMBox);
            this.groupBox2.Controls.Add(this.reservasiCb);
            this.groupBox2.Controls.Add(this.NoKamarcomboBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.guna2Button3);
            this.groupBox2.Controls.Add(this.bookingIdField);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.depositField);
            this.groupBox2.Controls.Add(this.guna2Button1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.guna2Button2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.noteTextBox);
            this.groupBox2.Controls.Add(this.paymentComboBox);
            this.groupBox2.Controls.Add(this.checkinPicker);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.checkoutPicker);
            this.groupBox2.Controls.Add(this.amountField);
            this.groupBox2.Controls.Add(this.depositTextBox1);
            this.groupBox2.Controls.Add(this.otaComboBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(954, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(316, 591);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label15.Location = new System.Drawing.Point(165, 243);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 20);
            this.label15.TabIndex = 140;
            this.label15.Text = "Booking ID";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // kamarTextbox
            // 
            this.kamarTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kamarTextbox.DefaultText = "";
            this.kamarTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kamarTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kamarTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kamarTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kamarTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kamarTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kamarTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kamarTextbox.Location = new System.Drawing.Point(12, 204);
            this.kamarTextbox.Name = "kamarTextbox";
            this.kamarTextbox.PasswordChar = '\0';
            this.kamarTextbox.PlaceholderText = "";
            this.kamarTextbox.SelectedText = "";
            this.kamarTextbox.Size = new System.Drawing.Size(263, 36);
            this.kamarTextbox.TabIndex = 138;
            this.kamarTextbox.Visible = false;
            // 
            // guestIdCMBox
            // 
            this.guestIdCMBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.guestIdCMBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.guestIdCMBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestIdCMBox.FormattingEnabled = true;
            this.guestIdCMBox.Location = new System.Drawing.Point(9, 83);
            this.guestIdCMBox.Name = "guestIdCMBox";
            this.guestIdCMBox.Size = new System.Drawing.Size(281, 32);
            this.guestIdCMBox.TabIndex = 137;
            // 
            // reservasiCb
            // 
            this.reservasiCb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.reservasiCb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.reservasiCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservasiCb.FormattingEnabled = true;
            this.reservasiCb.Location = new System.Drawing.Point(122, 26);
            this.reservasiCb.Name = "reservasiCb";
            this.reservasiCb.Size = new System.Drawing.Size(163, 32);
            this.reservasiCb.TabIndex = 136;
            this.reservasiCb.SelectedIndexChanged += new System.EventHandler(this.reservasiCb_SelectedIndexChanged_1);
            // 
            // NoKamarcomboBox
            // 
            this.NoKamarcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NoKamarcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NoKamarcomboBox.DropDownHeight = 150;
            this.NoKamarcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoKamarcomboBox.FormattingEnabled = true;
            this.NoKamarcomboBox.IntegralHeight = false;
            this.NoKamarcomboBox.Location = new System.Drawing.Point(12, 208);
            this.NoKamarcomboBox.Name = "NoKamarcomboBox";
            this.NoKamarcomboBox.Size = new System.Drawing.Size(278, 32);
            this.NoKamarcomboBox.TabIndex = 135;
            this.NoKamarcomboBox.SelectedIndexChanged += new System.EventHandler(this.roomIdCMBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label14.Location = new System.Drawing.Point(118, 1);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 133;
            this.label14.Text = "Reservasi";
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderRadius = 20;
            this.guna2Button4.BorderThickness = 1;
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button4.Location = new System.Drawing.Point(702, 26);
            this.guna2Button4.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(238, 22);
            this.guna2Button4.TabIndex = 135;
            this.guna2Button4.Text = "TAMPILKAN SEMUA";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.BackColor = System.Drawing.Color.White;
            this.loadingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.loadingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.loadingText.Location = new System.Drawing.Point(460, 302);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(159, 37);
            this.loadingText.TabIndex = 136;
            this.loadingText.Text = "Loading...";
            // 
            // kosongText
            // 
            this.kosongText.AutoSize = true;
            this.kosongText.BackColor = System.Drawing.Color.White;
            this.kosongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.kosongText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.kosongText.Location = new System.Drawing.Point(432, 338);
            this.kosongText.Name = "kosongText";
            this.kosongText.Size = new System.Drawing.Size(203, 37);
            this.kosongText.TabIndex = 137;
            this.kosongText.Text = "Data Kosong";
            // 
            // printCard
            // 
            this.printCard.BackColor = System.Drawing.Color.Transparent;
            this.printCard.BorderRadius = 20;
            this.printCard.BorderThickness = 1;
            this.printCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.printCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.printCard.Location = new System.Drawing.Point(13, 584);
            this.printCard.Margin = new System.Windows.Forms.Padding(2);
            this.printCard.Name = "printCard";
            this.printCard.Size = new System.Drawing.Size(312, 25);
            this.printCard.TabIndex = 138;
            this.printCard.Text = "PRINT";
            this.printCard.Click += new System.EventHandler(this.printCard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.printCard);
            this.groupBox1.Location = new System.Drawing.Point(945, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 623);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            // 
            // bookingIdTextBox
            // 
            this.bookingIdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bookingIdTextBox.DefaultText = "";
            this.bookingIdTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bookingIdTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bookingIdTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookingIdTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookingIdTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookingIdTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingIdTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookingIdTextBox.Location = new System.Drawing.Point(169, 266);
            this.bookingIdTextBox.Name = "bookingIdTextBox";
            this.bookingIdTextBox.PasswordChar = '\0';
            this.bookingIdTextBox.PlaceholderText = "";
            this.bookingIdTextBox.ReadOnly = false;
            this.bookingIdTextBox.SelectedText = "";
            this.bookingIdTextBox.Size = new System.Drawing.Size(121, 32);
            this.bookingIdTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.bookingIdTextBox.TabIndex = 141;
            this.bookingIdTextBox.TextChanged += new System.EventHandler(this.bookingIdTextBox_TextChanged_1);
            // 
            // BookingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1274, 645);
            this.Controls.Add(this.kosongText);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FilterTableCheckinDate);
            this.Controls.Add(this.bookingTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(118, 123);
            this.Name = "BookingsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.BookingsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkinPicker;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkoutPicker;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox amountField;
        private Guna.UI2.WinForms.Guna2Button addButton;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DataGridView bookingTable;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2DateTimePicker FilterTableCheckinDate;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox depositField;
        private Guna.UI2.WinForms.Guna2ComboBox paymentComboBox;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox otaComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox depositTextBox1;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox noteTextBox;
        private Guna.UI2.WinForms.Guna2TextBox bookingIdField;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.Label kosongText;
        private System.Windows.Forms.ComboBox NoKamarcomboBox;
        private System.Windows.Forms.ComboBox reservasiCb;
        private System.Windows.Forms.ComboBox guestIdCMBox;
        private Guna.UI2.WinForms.Guna2TextBox kamarTextbox;
        private Guna.UI2.WinForms.Guna2Button printCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2TextBox bookingIdTextBox;
    }
}