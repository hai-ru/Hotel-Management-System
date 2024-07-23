namespace Hotel_Management_System.Screens
{
    partial class HotelIntroScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotelIntroScreen));
            this.bgPanel = new System.Windows.Forms.Panel();
            this.webLabel = new System.Windows.Forms.Label();
            this.descripLabel = new System.Windows.Forms.Label();
            this.hotelName = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bgPanel.BackgroundImage")));
            this.bgPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(1318, 747);
            this.bgPanel.TabIndex = 13;
            // 
            // webLabel
            // 
            this.webLabel.AutoSize = true;
            this.webLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.webLabel.Location = new System.Drawing.Point(77, 466);
            this.webLabel.Name = "webLabel";
            this.webLabel.Size = new System.Drawing.Size(0, 19);
            this.webLabel.TabIndex = 12;
            // 
            // descripLabel
            // 
            this.descripLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripLabel.Location = new System.Drawing.Point(75, 142);
            this.descripLabel.Name = "descripLabel";
            this.descripLabel.Size = new System.Drawing.Size(413, 141);
            this.descripLabel.TabIndex = 8;
            // 
            // hotelName
            // 
            this.hotelName.AutoSize = true;
            this.hotelName.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelName.Location = new System.Drawing.Point(74, 93);
            this.hotelName.Name = "hotelName";
            this.hotelName.Size = new System.Drawing.Size(0, 31);
            this.hotelName.TabIndex = 7;
            this.hotelName.Click += new System.EventHandler(this.hotelName_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(164, 425);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(0, 16);
            this.emailLabel.TabIndex = 15;
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactLabel.Location = new System.Drawing.Point(183, 393);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(0, 16);
            this.contactLabel.TabIndex = 19;
            // 
            // HotelIntroScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1316, 743);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.bgPanel);
            this.Controls.Add(this.webLabel);
            this.Controls.Add(this.descripLabel);
            this.Controls.Add(this.hotelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(118, 123);
            this.Name = "HotelIntroScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HotelIntroScreen";
            this.Load += new System.EventHandler(this.HotelIntroScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label webLabel;
        private System.Windows.Forms.Label descripLabel;
        private System.Windows.Forms.Label hotelName;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label contactLabel;
    }
}