using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Hexadeca Picker
 * Created by Victoria Grip
 * Copyright 2024
 * 
 * This app lets you conveniently pick colors on the screen and copy various values to the clipboard
 * Not much more to it than that.
 * 
 * NOTE I haven't tested the app on different pixel ratios, so the zoom function might be a bit wonky on anything that isn't 1x
 * 
 * TODO Add so that it can use a quick key combo to pick colors (global)
 */

namespace HexadecaPicker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Prevent the app from running in multiple instances
            if (Common.IsAppAlreadyRunning())
                Application.Exit();

            //Initializes the forms app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
