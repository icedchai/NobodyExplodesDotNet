
namespace WindowsFormsApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using NobodyExplodesDotNet.Enums;
    using NobodyExplodesDotNet.Types;
    using NobodyExplodesDotNet.Types.Modules;
    using NobodyExplodesDotNet.Types.Widgets;

    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BombForm());
        }
    }
}
 