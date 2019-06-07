using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RGBEditor editor = new RGBEditor();
            if (args.Length > 0)
            {
                if (args[0] == "/?")
                {
                    MessageBox.Show(@"Usage: SM64_RGB_Editor [/?] [filename]
    filename    The ROM file to open", "SM64 RGB Editor");
                    Application.Exit();
                }
                else
                {
                    editor.Open(args[0]);
                }
            }
            Application.Run(editor);
        }
    }
}
