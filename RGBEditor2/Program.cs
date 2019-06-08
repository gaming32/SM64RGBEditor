using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    static class Program
    {
        static void Help(RGBEditor editor)
        {
            MessageBox.Show(@"Usage: SM64_RGB_Editor [/?] [filename] [item_name]
    filename    The ROM file to open
    item_name   The name of the RGB item to select from the list", "SM64 RGB Editor");
            editor.Close();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RGBEditor editor = new RGBEditor();
            if (args.Contains("/?")) Help(editor);
            else if (args.Length >= 1)
            {
                editor.Open(args[0]);
                if (args.Length >= 2 && args[1] != "/E") editor.Select(args[1]);
                if (args.Length >= 3 && args[2] != "/E") editor.FillRGB(Color.FromArgb(
                    int.Parse(args[2], System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(args[3], System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(args[4], System.Globalization.NumberStyles.AllowHexSpecifier)));
                if (args.Length >= 6 && args[5] != "/E") editor.FillShade(Color.FromArgb(
                    int.Parse(args[5], System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(args[6], System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(args[7], System.Globalization.NumberStyles.AllowHexSpecifier)));
                if (args.Contains("/E"))
                {
                    editor.button2_Click(null, null);
                    editor.Close();
                }
            }
            try { Application.Run(editor); }
            catch (ObjectDisposedException) { }
        }
    }
}
