using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZortosExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (Textboxurl.Text.Contains("www"))
            {
                return;
            }
            webBrowser1.Url = new Uri(Textboxurl.Text);

        }
        string url = "";

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
                webBrowser1.GoBack();
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Textboxurl_TextChanged(object sender, EventArgs e)
        {

        }

        private void Textboxurl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (Textboxurl.Text.Contains("www"))
                {
                    return;
                }
                webBrowser1.Url = new Uri(Textboxurl.Text);
               
            }
        }
        
       
        private void Textboxurl_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("c:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("B:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private async void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            await Task.Delay(200);
            if (Textboxurl.Text == "")
            {

            }
            else
            {
                url = webBrowser1.Url.AbsoluteUri;
                url = url.Remove(0, 8);
                Textboxurl.Text = url;
                Textboxurl.Update();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("A:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("D:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("F:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("E:\\");
            url = webBrowser1.Url.AbsoluteUri;
            url = url.Remove(0, 8);
            Textboxurl.Text = url;
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("^(v)");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("^(c)");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }

    
}
