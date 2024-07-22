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
    public partial class Form2 : Form
    {
        private string url = "";
        private string html = "";

        public Form2(string url = "")
        {
            InitializeComponent();

            this.url = url;

            this.webBrowser1.ScriptErrorsSuppressed = true;

            this.webBrowser1.Navigate(url);
            this.webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Get the HTML content when the document has finished loading
            this.html = webBrowser1.DocumentText;
            // Alternatively, you can access the HTML DOM through webBrowser1.Document
            // Example: HtmlElement body = webBrowser1.Document.Body;

            // Display or use the HTML content as needed
            Console.WriteLine(html);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.webBrowser1.Print();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
