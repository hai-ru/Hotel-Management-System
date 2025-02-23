using System;

namespace Hotel_Management_System.Screens
{
    partial class ReservationScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkinPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.checkoutPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.amountField = new Guna.UI2.WinForms.Guna2TextBox();
            this.updateButton = new Guna.UI2.WinForms.Guna2Button();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.bookingTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.FilterTableCheckinDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.deleteButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guestSelect = new System.Windows.Forms.ComboBox();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.depositTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.otaCb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.paymentComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tipeKamarCb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.PrintButton2 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.idField = new Guna.UI2.WinForms.Guna2TextBox();
            this.loadingText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookingTable)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Reservasi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(90, 5);
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
            this.label5.Location = new System.Drawing.Point(1, 67);
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
            this.label6.Location = new System.Drawing.Point(173, 67);
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
            this.checkinPicker.Location = new System.Drawing.Point(1, 89);
            this.checkinPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkinPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkinPicker.Name = "checkinPicker";
            this.checkinPicker.Size = new System.Drawing.Size(152, 36);
            this.checkinPicker.TabIndex = 70;
            this.checkinPicker.Value = new System.DateTime(2024, 7, 17, 1, 4, 43, 652);
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
            this.checkoutPicker.Location = new System.Drawing.Point(176, 89);
            this.checkoutPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkoutPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkoutPicker.Name = "checkoutPicker";
            this.checkoutPicker.Size = new System.Drawing.Size(159, 36);
            this.checkoutPicker.TabIndex = 71;
            this.checkoutPicker.Value = new System.DateTime(2024, 7, 18, 1, 4, 43, 683);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label8.Location = new System.Drawing.Point(3, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Harga Total";
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
            this.amountField.Location = new System.Drawing.Point(7, 155);
            this.amountField.Margin = new System.Windows.Forms.Padding(4);
            this.amountField.Name = "amountField";
            this.amountField.PasswordChar = '\0';
            this.amountField.PlaceholderText = "";
            this.amountField.SelectedText = "";
            this.amountField.Size = new System.Drawing.Size(331, 32);
            this.amountField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.amountField.TabIndex = 75;
            this.amountField.TextChanged += new System.EventHandler(this.amountField_TextChanged);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Transparent;
            this.updateButton.BorderRadius = 20;
            this.updateButton.BorderThickness = 1;
            this.updateButton.Enabled = false;
            this.updateButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.updateButton.Location = new System.Drawing.Point(8, 405);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(157, 36);
            this.updateButton.TabIndex = 83;
            this.updateButton.Text = "UPDATE";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BorderRadius = 20;
            this.addButton.BorderThickness = 1;
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addButton.Location = new System.Drawing.Point(175, 405);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(166, 36);
            this.addButton.TabIndex = 80;
            this.addButton.Text = "ADD";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // bookingTable
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.bookingTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bookingTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bookingTable.ColumnHeadersHeight = 40;
            this.bookingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bookingTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.bookingTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.bookingTable.Location = new System.Drawing.Point(32, 62);
            this.bookingTable.Name = "bookingTable";
            this.bookingTable.ReadOnly = true;
            this.bookingTable.RowHeadersVisible = false;
            this.bookingTable.RowHeadersWidth = 51;
            this.bookingTable.RowTemplate.Height = 35;
            this.bookingTable.Size = new System.Drawing.Size(904, 468);
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
            this.FilterTableCheckinDate.Value = new System.DateTime(2024, 7, 11, 0, 0, 0, 0);
            this.FilterTableCheckinDate.ValueChanged += new System.EventHandler(this.FilterTableCheckinDate_ValueChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.BorderRadius = 20;
            this.deleteButton.BorderThickness = 1;
            this.deleteButton.Enabled = false;
            this.deleteButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.deleteButton.Location = new System.Drawing.Point(175, 447);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(166, 37);
            this.deleteButton.TabIndex = 122;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button1.Location = new System.Drawing.Point(725, 29);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(211, 27);
            this.guna2Button1.TabIndex = 127;
            this.guna2Button1.Text = "TAMPILKAN SEMUA";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guestSelect);
            this.groupBox1.Controls.Add(this.guna2ComboBox1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.depositTextBox1);
            this.groupBox1.Controls.Add(this.otaCb);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.paymentComboBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tipeKamarCb);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.guna2Button2);
            this.groupBox1.Controls.Add(this.PrintButton2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idField);
            this.groupBox1.Controls.Add(this.checkinPicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkoutPicker);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.amountField);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Location = new System.Drawing.Point(942, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 797);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            // 
            // guestSelect
            // 
            this.guestSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.guestSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.guestSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestSelect.FormattingEnabled = true;
            this.guestSelect.Location = new System.Drawing.Point(90, 27);
            this.guestSelect.Name = "guestSelect";
            this.guestSelect.Size = new System.Drawing.Size(248, 32);
            this.guestSelect.TabIndex = 138;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(162, 289);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(173, 36);
            this.guna2ComboBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.guna2ComboBox1.TabIndex = 140;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(158, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 139;
            this.label12.Text = "Catatan";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(5, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 137;
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
            this.depositTextBox1.Location = new System.Drawing.Point(9, 355);
            this.depositTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.depositTextBox1.Name = "depositTextBox1";
            this.depositTextBox1.PasswordChar = '\0';
            this.depositTextBox1.PlaceholderText = "";
            this.depositTextBox1.SelectedText = "";
            this.depositTextBox1.Size = new System.Drawing.Size(331, 32);
            this.depositTextBox1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.depositTextBox1.TabIndex = 138;
            // 
            // otaCb
            // 
            this.otaCb.BackColor = System.Drawing.Color.Transparent;
            this.otaCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.otaCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otaCb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otaCb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.otaCb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.otaCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.otaCb.ItemHeight = 30;
            this.otaCb.Location = new System.Drawing.Point(7, 218);
            this.otaCb.Name = "otaCb";
            this.otaCb.Size = new System.Drawing.Size(146, 36);
            this.otaCb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.otaCb.TabIndex = 136;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(3, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 135;
            this.label10.Text = "Travel Agen";
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
            this.paymentComboBox.Location = new System.Drawing.Point(7, 289);
            this.paymentComboBox.Name = "paymentComboBox";
            this.paymentComboBox.Size = new System.Drawing.Size(146, 36);
            this.paymentComboBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.paymentComboBox.TabIndex = 134;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label9.Location = new System.Drawing.Point(3, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 17);
            this.label9.TabIndex = 133;
            this.label9.Text = "Metode Pembayaran";
            // 
            // tipeKamarCb
            // 
            this.tipeKamarCb.BackColor = System.Drawing.Color.Transparent;
            this.tipeKamarCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipeKamarCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipeKamarCb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tipeKamarCb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tipeKamarCb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tipeKamarCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.tipeKamarCb.ItemHeight = 30;
            this.tipeKamarCb.Location = new System.Drawing.Point(159, 218);
            this.tipeKamarCb.Name = "tipeKamarCb";
            this.tipeKamarCb.Size = new System.Drawing.Size(182, 36);
            this.tipeKamarCb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tipeKamarCb.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(155, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 131;
            this.label7.Text = "Tipe Kamar";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.Enabled = false;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guna2Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button2.Location = new System.Drawing.Point(9, 490);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(332, 38);
            this.guna2Button2.TabIndex = 130;
            this.guna2Button2.Text = "CLEAR";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click_1);
            // 
            // PrintButton2
            // 
            this.PrintButton2.BackColor = System.Drawing.Color.Transparent;
            this.PrintButton2.BorderRadius = 20;
            this.PrintButton2.BorderThickness = 1;
            this.PrintButton2.Enabled = false;
            this.PrintButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.PrintButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PrintButton2.Location = new System.Drawing.Point(8, 447);
            this.PrintButton2.Name = "PrintButton2";
            this.PrintButton2.Size = new System.Drawing.Size(157, 37);
            this.PrintButton2.TabIndex = 129;
            this.PrintButton2.Text = "PRINT";
            this.PrintButton2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(-1, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 127;
            this.label2.Text = "ID";
            // 
            // idField
            // 
            this.idField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idField.DefaultText = "";
            this.idField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.idField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.idField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idField.Enabled = false;
            this.idField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idField.Location = new System.Drawing.Point(3, 25);
            this.idField.Margin = new System.Windows.Forms.Padding(4);
            this.idField.Name = "idField";
            this.idField.PasswordChar = '\0';
            this.idField.PlaceholderText = "";
            this.idField.SelectedText = "";
            this.idField.Size = new System.Drawing.Size(80, 32);
            this.idField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.idField.TabIndex = 128;
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.BackColor = System.Drawing.Color.White;
            this.loadingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.loadingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.loadingText.Location = new System.Drawing.Point(429, 269);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(159, 37);
            this.loadingText.TabIndex = 129;
            this.loadingText.Text = "Loading...";
            // 
            // ReservationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1295, 549);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.FilterTableCheckinDate);
            this.Controls.Add(this.bookingTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(118, 123);
            this.Name = "ReservationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.ReservationScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2Button updateButton;
        private Guna.UI2.WinForms.Guna2Button addButton;
        private Guna.UI2.WinForms.Guna2DataGridView bookingTable;
        private Guna.UI2.WinForms.Guna2DateTimePicker FilterTableCheckinDate;
        private Guna.UI2.WinForms.Guna2Button deleteButton;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button PrintButton2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox idField;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2ComboBox tipeKamarCb;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox paymentComboBox;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ComboBox otaCb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox depositTextBox1;
        private System.Windows.Forms.Label loadingText;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox guestSelect;
    }
}