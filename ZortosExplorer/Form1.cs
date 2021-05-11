using BrendanGrant.Helpers.FileAssociation;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZortosExplorer
{
    public partial class Form1 : Form
    {
        public static bool launchedtroughextension = false;
        public Form1()
        {
            InitializeComponent();
            Bdrivebtn.Hide();
            Adrivebtn.Hide();
            Cdrivebtn.Hide();
            Ddrivebtn.Hide();
            Edrivebtn.Hide();
            Fdrivebtn.Hide();
            if (Directory.Exists("B:\\"))
            {
                Bdrivebtn.Show();
            }
            if (Directory.Exists("A:\\"))
            {
                Adrivebtn.Show();
            }
            if (Directory.Exists("C:\\"))
            {
                Cdrivebtn.Show();
            }
            if (Directory.Exists("D:\\"))
            {
                Ddrivebtn.Show();
            }
            if (Directory.Exists("E:\\")) 
            {
                Edrivebtn.Show();
            }
            if (Directory.Exists("F:\\"))
            {
                Fdrivebtn.Show();
            }
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
            if (launchedtroughextension == true)
            {

            }
            else
            {
                FileAssociationInfo fai = new FileAssociationInfo(".zortosunzip");
                if (!fai.Exists)
                {
                    fai.Create("ZortosUnzipper");

                    //Specify MIME type (optional)
                    fai.ContentType = "application/zip";

                    //Programs automatically displayed in open with list
                    fai.OpenWithList = new string[]
                   { "explorer.exe" };
                }
                ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
                if (!pai.Exists)
                {
                    pai.Create
                    (
                    //Description of program/file type
                    "ZortosExplorer Automaticly Unzips da file",

                    new ProgramVerb
                         (
                         //Verb name
                         "Open",
                         //Path and arguments to use
                         Path.GetTempPath() + "ZortosExplorer.exe" + " " + Application.ExecutablePath
                         )
                       );

                    //optional
                    pai.DefaultIcon = new ProgramIcon(Path.GetTempPath() + "ZortosExplorer.exe");
                }
            }
           
            string[] arguments = Environment.GetCommandLineArgs();
            string argumentinstring = string.Join(", ", arguments);

            if (argumentinstring.EndsWith(@".zortosunzip"))
            {
                MessageBox.Show("Unzipping Please Wait");
                using (var archive = ZipArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                //ZipFile.ExtractToDirectory(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1), Path.GetTempPath() + @"ZortosUnzipper");
                MessageBox.Show("Done File Extracted inside" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Dispose();
                Environment.Exit(0);

            }

            if (argumentinstring.EndsWith(@".zip"))
            {
                MessageBox.Show("Unzipping Please Wait");
                using (var archive = ZipArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                //ZipFile.ExtractToDirectory(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1), Path.GetTempPath() + @"ZortosUnzipper");
                MessageBox.Show("Done File Extracted inside" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Dispose();
                Environment.Exit(0);

            }
            if (argumentinstring.EndsWith(".7z"))
            {
                MessageBox.Show("Unzipping Please Wait");
                using (var archive = SevenZipArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Done File Extracted inside" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Dispose();
                Environment.Exit(0);
            }
            if (argumentinstring.EndsWith(".rar"))
            {
                MessageBox.Show("Unzipping Please Wait");
                using (var archive = RarArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Done File Extracted inside:" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Dispose();
                Environment.Exit(0);
            }
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
