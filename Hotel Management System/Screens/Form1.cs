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
        OnityConnection onity = new OnityConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OnityIP = IPtextBox1.Text;
            Properties.Settings.Default.OnityPort = PorttextBox2.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Data telah tersimpan");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPtextBox1.Text = Properties.Settings.Default.OnityIP;
            PorttextBox2.Text = Properties.Settings.Default.OnityPort;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string room = onity.readCard();
            ResulttextBox3.Text = room;
        }
    }
}
