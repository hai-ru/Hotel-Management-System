namespace Hotel_Management_System.Screens
{
    partial class NetworkDiagnosticsScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.connectionIndicator = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.qualityBar = new System.Windows.Forms.ProgressBar();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pingLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lastTestLabel = new System.Windows.Forms.Label();
            this.recommendationGroupBox = new System.Windows.Forms.GroupBox();
            this.recommendationTextBox = new System.Windows.Forms.TextBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.testButton = new System.Windows.Forms.Button();
            this.quickPingButton = new System.Windows.Forms.Button();
            this.quickPingLabel = new System.Windows.Forms.Label();
            this.autoRefreshCheckBox = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.mainPanel.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.detailsGroupBox.SuspendLayout();
            this.recommendationGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.progressBar);
            this.mainPanel.Controls.Add(this.buttonPanel);
            this.mainPanel.Controls.Add(this.recommendationGroupBox);
            this.mainPanel.Controls.Add(this.detailsGroupBox);
            this.mainPanel.Controls.Add(this.statusGroupBox);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(800, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(760, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🌐 Network Diagnostics";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.qualityBar);
            this.statusGroupBox.Controls.Add(this.messageLabel);
            this.statusGroupBox.Controls.Add(this.statusLabel);
            this.statusGroupBox.Controls.Add(this.connectionIndicator);
            this.statusGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statusGroupBox.Location = new System.Drawing.Point(20, 60);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.statusGroupBox.Size = new System.Drawing.Size(760, 140);
            this.statusGroupBox.TabIndex = 1;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Connection Status";
            // 
            // connectionIndicator
            // 
            this.connectionIndicator.BackColor = System.Drawing.Color.Gray;
            this.connectionIndicator.Location = new System.Drawing.Point(20, 30);
            this.connectionIndicator.Name = "connectionIndicator";
            this.connectionIndicator.Size = new System.Drawing.Size(30, 30);
            this.connectionIndicator.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.Gray;
            this.statusLabel.Location = new System.Drawing.Point(60, 25);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(680, 35);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Not Tested";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.messageLabel.Location = new System.Drawing.Point(20, 65);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(720, 20);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "Click \'Test Connection\' to start";
            // 
            // qualityBar
            // 
            this.qualityBar.Location = new System.Drawing.Point(20, 95);
            this.qualityBar.Name = "qualityBar";
            this.qualityBar.Size = new System.Drawing.Size(720, 25);
            this.qualityBar.TabIndex = 3;
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.lastTestLabel);
            this.detailsGroupBox.Controls.Add(this.label3);
            this.detailsGroupBox.Controls.Add(this.speedLabel);
            this.detailsGroupBox.Controls.Add(this.label2);
            this.detailsGroupBox.Controls.Add(this.pingLabel);
            this.detailsGroupBox.Controls.Add(this.label1);
            this.detailsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailsGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.detailsGroupBox.Location = new System.Drawing.Point(20, 200);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.detailsGroupBox.Size = new System.Drawing.Size(760, 100);
            this.detailsGroupBox.TabIndex = 2;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Connection Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ping Time:";
            // 
            // pingLabel
            // 
            this.pingLabel.AutoSize = true;
            this.pingLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pingLabel.ForeColor = System.Drawing.Color.Blue;
            this.pingLabel.Location = new System.Drawing.Point(120, 35);
            this.pingLabel.Name = "pingLabel";
            this.pingLabel.Size = new System.Drawing.Size(30, 15);
            this.pingLabel.TabIndex = 1;
            this.pingLabel.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(250, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Download Speed:";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.speedLabel.ForeColor = System.Drawing.Color.Blue;
            this.speedLabel.Location = new System.Drawing.Point(360, 35);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(30, 15);
            this.speedLabel.TabIndex = 3;
            this.speedLabel.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Test:";
            // 
            // lastTestLabel
            // 
            this.lastTestLabel.AutoSize = true;
            this.lastTestLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lastTestLabel.ForeColor = System.Drawing.Color.Blue;
            this.lastTestLabel.Location = new System.Drawing.Point(120, 65);
            this.lastTestLabel.Name = "lastTestLabel";
            this.lastTestLabel.Size = new System.Drawing.Size(30, 15);
            this.lastTestLabel.TabIndex = 5;
            this.lastTestLabel.Text = "N/A";
            // 
            // recommendationGroupBox
            // 
            this.recommendationGroupBox.Controls.Add(this.recommendationTextBox);
            this.recommendationGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.recommendationGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.recommendationGroupBox.Location = new System.Drawing.Point(20, 300);
            this.recommendationGroupBox.Name = "recommendationGroupBox";
            this.recommendationGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.recommendationGroupBox.Size = new System.Drawing.Size(760, 160);
            this.recommendationGroupBox.TabIndex = 3;
            this.recommendationGroupBox.TabStop = false;
            this.recommendationGroupBox.Text = "Recommendations";
            // 
            // recommendationTextBox
            // 
            this.recommendationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.recommendationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recommendationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recommendationTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.recommendationTextBox.Location = new System.Drawing.Point(10, 26);
            this.recommendationTextBox.Multiline = true;
            this.recommendationTextBox.Name = "recommendationTextBox";
            this.recommendationTextBox.ReadOnly = true;
            this.recommendationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recommendationTextBox.Size = new System.Drawing.Size(740, 124);
            this.recommendationTextBox.TabIndex = 0;
            this.recommendationTextBox.Text = "Run a test to get recommendations...";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Controls.Add(this.autoRefreshCheckBox);
            this.buttonPanel.Controls.Add(this.quickPingLabel);
            this.buttonPanel.Controls.Add(this.quickPingButton);
            this.buttonPanel.Controls.Add(this.testButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(20, 510);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(760, 70);
            this.buttonPanel.TabIndex = 4;
            // 
            // testButton
            // 
            this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.testButton.ForeColor = System.Drawing.Color.White;
            this.testButton.Location = new System.Drawing.Point(10, 15);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(150, 40);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "🔍 Test Connection";
            this.testButton.UseVisualStyleBackColor = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // quickPingButton
            // 
            this.quickPingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.quickPingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quickPingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.quickPingButton.ForeColor = System.Drawing.Color.White;
            this.quickPingButton.Location = new System.Drawing.Point(170, 15);
            this.quickPingButton.Name = "quickPingButton";
            this.quickPingButton.Size = new System.Drawing.Size(100, 40);
            this.quickPingButton.TabIndex = 1;
            this.quickPingButton.Text = "⚡ Quick Ping";
            this.quickPingButton.UseVisualStyleBackColor = false;
            this.quickPingButton.Click += new System.EventHandler(this.quickPingButton_Click);
            // 
            // quickPingLabel
            // 
            this.quickPingLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.quickPingLabel.ForeColor = System.Drawing.Color.Blue;
            this.quickPingLabel.Location = new System.Drawing.Point(280, 15);
            this.quickPingLabel.Name = "quickPingLabel";
            this.quickPingLabel.Size = new System.Drawing.Size(100, 40);
            this.quickPingLabel.TabIndex = 2;
            this.quickPingLabel.Text = "- ms";
            this.quickPingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autoRefreshCheckBox
            // 
            this.autoRefreshCheckBox.AutoSize = true;
            this.autoRefreshCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.autoRefreshCheckBox.Location = new System.Drawing.Point(400, 25);
            this.autoRefreshCheckBox.Name = "autoRefreshCheckBox";
            this.autoRefreshCheckBox.Size = new System.Drawing.Size(152, 19);
            this.autoRefreshCheckBox.TabIndex = 3;
            this.autoRefreshCheckBox.Text = "🔄 Auto Refresh (10s)";
            this.autoRefreshCheckBox.UseVisualStyleBackColor = true;
            this.autoRefreshCheckBox.CheckedChanged += new System.EventHandler(this.autoRefreshCheckBox_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeButton.Location = new System.Drawing.Point(650, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 40);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 470);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(760, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // NetworkDiagnosticsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NetworkDiagnosticsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Diagnostics - Hotel Management System";
            this.Load += new System.EventHandler(this.NetworkDiagnosticsScreen_Load);
            this.mainPanel.ResumeLayout(false);
            this.statusGroupBox.ResumeLayout(false);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.recommendationGroupBox.ResumeLayout(false);
            this.recommendationGroupBox.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Panel connectionIndicator;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ProgressBar qualityBar;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pingLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lastTestLabel;
        private System.Windows.Forms.GroupBox recommendationGroupBox;
        private System.Windows.Forms.TextBox recommendationTextBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button quickPingButton;
        private System.Windows.Forms.Label quickPingLabel;
        private System.Windows.Forms.CheckBox autoRefreshCheckBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
