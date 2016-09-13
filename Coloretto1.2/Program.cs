using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Timers;

namespace Coloretto1._2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            
            Application.SetCompatibleTextRenderingDefault(false);
            Home form = new Home();

            form.Show();
            Application.Run(form);
          
            
        }
    }
}
