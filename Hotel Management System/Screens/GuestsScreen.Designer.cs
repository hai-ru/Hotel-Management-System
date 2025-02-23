namespace Hotel_Management_System.Controllers
{
    partial class GuestsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestsScreen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guestIdField = new Guna.UI2.WinForms.Guna2TextBox();
            this.GuestId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namaField = new Guna.UI2.WinForms.Guna2TextBox();
            this.numberField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.alamatField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cityField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.provinsiField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.clearButton = new Guna.UI2.WinForms.Guna2Button();
            this.updateButton = new Guna.UI2.WinForms.Guna2Button();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.guestTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.serachBoxField = new Guna.UI2.WinForms.Guna2TextBox();
            this.nikField = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loadingText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "Guests";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BorderThickness = 2;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.Image")));
            this.guna2CircleButton1.Location = new System.Drawing.Point(717, 23);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(29, 26);
            this.guna2CircleButton1.TabIndex = 49;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guestIdField
            // 
            this.guestIdField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guestIdField.DefaultText = "";
            this.guestIdField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guestIdField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guestIdField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guestIdField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guestIdField.Enabled = false;
            this.guestIdField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guestIdField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestIdField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guestIdField.Location = new System.Drawing.Point(763, 63);
            this.guestIdField.Margin = new System.Windows.Forms.Padding(4);
            this.guestIdField.Name = "guestIdField";
            this.guestIdField.PasswordChar = '\0';
            this.guestIdField.PlaceholderText = "";
            this.guestIdField.ReadOnly = true;
            this.guestIdField.SelectedText = "";
            this.guestIdField.Size = new System.Drawing.Size(103, 34);
            this.guestIdField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.guestIdField.TabIndex = 48;
            // 
            // GuestId
            // 
            this.GuestId.AutoSize = true;
            this.GuestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.GuestId.Location = new System.Drawing.Point(758, 38);
            this.GuestId.Name = "GuestId";
            this.GuestId.Size = new System.Drawing.Size(71, 20);
            this.GuestId.TabIndex = 47;
            this.GuestId.Text = "Guest Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(759, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nama Lengkap";
            // 
            // namaField
            // 
            this.namaField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.namaField.DefaultText = "";
            this.namaField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.namaField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.namaField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.namaField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.namaField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.namaField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.namaField.Location = new System.Drawing.Point(762, 124);
            this.namaField.Margin = new System.Windows.Forms.Padding(4);
            this.namaField.Name = "namaField";
            this.namaField.PasswordChar = '\0';
            this.namaField.PlaceholderText = "";
            this.namaField.SelectedText = "";
            this.namaField.Size = new System.Drawing.Size(337, 26);
            this.namaField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.namaField.TabIndex = 51;
            // 
            // numberField
            // 
            this.numberField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numberField.DefaultText = "";
            this.numberField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numberField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numberField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numberField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numberField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numberField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numberField.Location = new System.Drawing.Point(764, 246);
            this.numberField.Margin = new System.Windows.Forms.Padding(4);
            this.numberField.Name = "numberField";
            this.numberField.PasswordChar = '\0';
            this.numberField.PlaceholderText = "";
            this.numberField.SelectedText = "";
            this.numberField.Size = new System.Drawing.Size(337, 26);
            this.numberField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.numberField.TabIndex = 57;
            this.numberField.TextChanged += new System.EventHandler(this.numberField_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(760, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "No Hp";
            // 
            // alamatField
            // 
            this.alamatField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.alamatField.DefaultText = "";
            this.alamatField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.alamatField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.alamatField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.alamatField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.alamatField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.alamatField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alamatField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.alamatField.Location = new System.Drawing.Point(763, 306);
            this.alamatField.Margin = new System.Windows.Forms.Padding(4);
            this.alamatField.Name = "alamatField";
            this.alamatField.PasswordChar = '\0';
            this.alamatField.PlaceholderText = "";
            this.alamatField.SelectedText = "";
            this.alamatField.Size = new System.Drawing.Size(337, 32);
            this.alamatField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.alamatField.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(760, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Alamat";
            // 
            // cityField
            // 
            this.cityField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cityField.DefaultText = "";
            this.cityField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cityField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cityField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cityField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cityField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cityField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cityField.Location = new System.Drawing.Point(946, 377);
            this.cityField.Margin = new System.Windows.Forms.Padding(4);
            this.cityField.Name = "cityField";
            this.cityField.PasswordChar = '\0';
            this.cityField.PlaceholderText = "";
            this.cityField.SelectedText = "";
            this.cityField.Size = new System.Drawing.Size(153, 32);
            this.cityField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cityField.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label9.Location = new System.Drawing.Point(943, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 68;
            this.label9.Text = "Kota";
            // 
            // provinsiField
            // 
            this.provinsiField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.provinsiField.DefaultText = "";
            this.provinsiField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.provinsiField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.provinsiField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.provinsiField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.provinsiField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.provinsiField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinsiField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.provinsiField.Location = new System.Drawing.Point(763, 377);
            this.provinsiField.Margin = new System.Windows.Forms.Padding(4);
            this.provinsiField.Name = "provinsiField";
            this.provinsiField.PasswordChar = '\0';
            this.provinsiField.PlaceholderText = "";
            this.provinsiField.SelectedText = "";
            this.provinsiField.Size = new System.Drawing.Size(156, 31);
            this.provinsiField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.provinsiField.TabIndex = 75;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label13.Location = new System.Drawing.Point(760, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 20);
            this.label13.TabIndex = 74;
            this.label13.Text = "Provinsi";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.BorderRadius = 20;
            this.clearButton.BorderThickness = 1;
            this.clearButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Location = new System.Drawing.Point(764, 493);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(338, 45);
            this.clearButton.TabIndex = 79;
            this.clearButton.Text = "CLEAR";
            this.clearButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Transparent;
            this.updateButton.BorderRadius = 20;
            this.updateButton.BorderThickness = 1;
            this.updateButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.updateButton.Location = new System.Drawing.Point(764, 429);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(155, 45);
            this.updateButton.TabIndex = 78;
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
            this.addButton.Location = new System.Drawing.Point(946, 429);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(155, 45);
            this.addButton.TabIndex = 76;
            this.addButton.Text = "ADD";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // guestTable
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guestTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guestTable.ColumnHeadersHeight = 40;
            this.guestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guestTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.guestTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.Location = new System.Drawing.Point(28, 55);
            this.guestTable.Name = "guestTable";
            this.guestTable.ReadOnly = true;
            this.guestTable.RowHeadersVisible = false;
            this.guestTable.RowHeadersWidth = 51;
            this.guestTable.RowTemplate.Height = 35;
            this.guestTable.Size = new System.Drawing.Size(718, 498);
            this.guestTable.TabIndex = 116;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(151)))), ((int)(((byte)(48)))));
            this.guestTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guestTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guestTable.ThemeStyle.HeaderStyle.Height = 40;
            this.guestTable.ThemeStyle.ReadOnly = true;
            this.guestTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guestTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guestTable.ThemeStyle.RowsStyle.Height = 35;
            this.guestTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guestTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guestTable_CellContentClick);
            // 
            // serachBoxField
            // 
            this.serachBoxField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.serachBoxField.DefaultText = "";
            this.serachBoxField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.serachBoxField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.serachBoxField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.serachBoxField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.serachBoxField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.serachBoxField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serachBoxField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.serachBoxField.Location = new System.Drawing.Point(373, 22);
            this.serachBoxField.Margin = new System.Windows.Forms.Padding(4);
            this.serachBoxField.Name = "serachBoxField";
            this.serachBoxField.PasswordChar = '\0';
            this.serachBoxField.PlaceholderText = "";
            this.serachBoxField.SelectedText = "";
            this.serachBoxField.Size = new System.Drawing.Size(337, 26);
            this.serachBoxField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.serachBoxField.TabIndex = 117;
            this.serachBoxField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBoxField_KeyDown);
            // 
            // nikField
            // 
            this.nikField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nikField.DefaultText = "";
            this.nikField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nikField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nikField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nikField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nikField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nikField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nikField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nikField.Location = new System.Drawing.Point(763, 181);
            this.nikField.Margin = new System.Windows.Forms.Padding(4);
            this.nikField.Name = "nikField";
            this.nikField.PasswordChar = '\0';
            this.nikField.PlaceholderText = "";
            this.nikField.SelectedText = "";
            this.nikField.Size = new System.Drawing.Size(337, 26);
            this.nikField.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.nikField.TabIndex = 119;
            this.nikField.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(760, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 118;
            this.label3.Text = "NIK";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.BackColor = System.Drawing.Color.White;
            this.loadingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.loadingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.loadingText.Location = new System.Drawing.Point(303, 321);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(159, 37);
            this.loadingText.TabIndex = 121;
            this.loadingText.Text = "Loading...";
            // 
            // GuestsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1133, 560);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.nikField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serachBoxField);
            this.Controls.Add(this.guestTable);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.provinsiField);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.alamatField);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cityField);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numberField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.namaField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.guestIdField);
            this.Controls.Add(this.GuestId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(118, 123);
            this.Name = "GuestsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GuestsScreen";
            this.Load += new System.EventHandler(this.GuestsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guestTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2TextBox guestIdField;
        private System.Windows.Forms.Label GuestId;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox namaField;
        private Guna.UI2.WinForms.Guna2TextBox numberField;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox alamatField;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox cityField;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox provinsiField;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button clearButton;
        private Guna.UI2.WinForms.Guna2Button updateButton;
        private Guna.UI2.WinForms.Guna2Button addButton;
        private Guna.UI2.WinForms.Guna2DataGridView guestTable;
        private Guna.UI2.WinForms.Guna2TextBox serachBoxField;
        private Guna.UI2.WinForms.Guna2TextBox nikField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label loadingText;
    }
}