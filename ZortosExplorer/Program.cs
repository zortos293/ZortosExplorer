using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZortosExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(System.Reflection.Assembly.GetEntryAssembly().Location == Path.GetTempPath() + @"ZortosExplorer.exe")
            {
                Form1.launchedtroughextension = true;
            }
            if (!File.Exists(Path.GetTempPath() + @"ZortosExplorer.exe"))
            {
                
                File.Copy(System.Reflection.Assembly.GetEntryAssembly().Location, Path.GetTempPath() + @"ZortosExplorer.exe");
            }
            else
            {
                File.Delete(Path.GetTempPath() + @"ZortosExplorer.exe");
                File.Copy(System.Reflection.Assembly.GetEntryAssembly().Location, Path.GetTempPath() + @"ZortosExplorer.exe");
            }
            Directory.CreateDirectory(Path.GetTempPath() + @"ZortosUnzipper");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
