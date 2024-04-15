using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Common functions used by everything.
 * 
 */

namespace HexadecaPicker
{
    internal class Common
    {
        //Import some dll functions
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, CopyPixelOperation dwRop);

        [DllImport("gdi32.dll")]
        private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursor(IntPtr hCursor);

        // Predefined system cursor constants
        public const int IDC_ARROW = 32512; // Standard arrow cursor
        public const int IDC_CROSS = 32515; // Crosshair cursor

        //Define some class name references from the DLL files
        private const string TrayWndClassName = "Shell_TrayWnd";
        private const string TrayNotifyClassName = "TrayNotifyWnd";

        /// <summary>
        /// Gets the position of the system tray
        /// </summary>
        /// <returns>Point x y</returns>
        public static Rectangle GetSystemTrayPosition()
        {
            //Get the handle for the taks bar
            IntPtr trayWndHandle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, TrayWndClassName, null);
            if (trayWndHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("System tray not found. I guess you just don't have one?");
            }

            IntPtr trayNotifyHandle = FindWindowEx(trayWndHandle, IntPtr.Zero, TrayNotifyClassName, null);
            if (trayNotifyHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("System tray notify window not found.");
            }

            //Get the rect for the tray
            Rectangle trayRect;
            if(!GetWindowRect(trayNotifyHandle, out trayRect))
            {
                throw new InvalidOperationException("Could not get tray position");
            }

            //Return result
            return trayRect;
        }

        /// <summary>
        /// Handles placing the window at the correct position depending on where the system tray is.
        /// Only supports doing it on the primary screen, and only for taskbars to the top or bottom. Sorry to everyone else.
        /// </summary>
        /// <param name="f">The form reference</param>
        /// <param name="r">The rectangle returned by the GetSystemTrayPosition function</param>
        /// <returns>Final X and Y position of the window</returns>
        public static void PlaceWindowAtSystemTray(Form f, Rectangle r)
        {
            //Get the screen resolution of the primary screen (Sorry, those who with multiple screens. This might look weird on for you)
            int sw = Screen.PrimaryScreen.Bounds.Width;
            int sh = Screen.PrimaryScreen.Bounds.Height;

            //Get taskbar height
            int taskbarHeight = (r.Height - r.Y);

            //Set window location to be next to the system tray
            if (r.Y == 0 && r.Width == sw)                      //If the tray is at the top
            {
                f.Top = r.Bottom;
                f.Left = sw - f.Width;
            }
            else if(r.Y + taskbarHeight == sh && r.Width == sw)      //If tray is at the bottom
            {
                f.Top = sh - f.Height - taskbarHeight;
                f.Left = sw - f.Width;
            }


        }

        /// <summary>
        /// Gets the pixel color at specified point
        /// </summary>
        /// <param name="x">x pos</param>
        /// <param name="y">y pos</param>
        /// <returns>A hex color value (ex: #ff0055)</returns>
        public static string GetPixelColorAtPoint(int x, int y)
        {
            //Use imported functions to get pixel's color
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);

            // Extract RGB components from the pixel value
            byte r = (byte)(pixel & 0x000000FF);
            byte g = (byte)((pixel & 0x0000FF00) >> 8);
            byte b = (byte)((pixel & 0x00FF0000) >> 16);

            //Get pixel color as a Color object
            Color pixelColor = Color.FromArgb(r, g, b);

            return ColorTranslator.ToHtml(pixelColor);
        }

        /// <summary>
        /// Converts a Color object to a hex string
        /// </summary>
        /// <param name="color">Color object</param>
        /// <returns>Hex string</returns>
        public static string ColorToHex(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        /// <summary>
        /// Changes the cursor to a built-in one.
        /// </summary>
        /// <param name="type">The type of cursor</param>
        public static void ChangeCursor(int type)
        {
            IntPtr cursorHandle = LoadCursor(IntPtr.Zero, type);
            SetCursor(cursorHandle);
        }

        /// <summary>
        /// Delays changing back a button's text from one text to another
        /// </summary>
        /// <param name="f">The Form reference. Used to change controls on the main thread</param>
        /// <param name="btn">Reference to the button</param>
        /// <param name="originalVal">The original string it had</param>
        public static void DelayChangeBackOfButton(Form f, Button btn, string originalVal)
        {
            //Set button to "Copied" to indicate it was copied. Also set some other properties
            btn.Text = "Copied";
            btn.Enabled = false;
            btn.BackColor = Color.WhiteSmoke;

            //Show an indication for a few milliseconds
            Thread delayThread = new Thread(() =>
            {
                //Pause the thread for a smidge
                Thread.Sleep(850);

                //Change text back to the original value (Makes sure to run it on the main thread with Invoke
                f.Invoke(new Action(() =>
                {
                    btn.Text = originalVal;
                    btn.Enabled = true;
                    btn.BackColor = Color.Transparent;
                }));
            });

            //Start thread
            delayThread.Start();
        }

        /// <summary>
        /// Check if the app is already running.
        /// </summary>
        /// <returns></returns>
        public static bool IsAppAlreadyRunning()
        {
            object mutex = new Mutex(true, "ID059182-1958-1837-6099910211-19583-183", out bool created);
            ((Mutex)mutex).ReleaseMutex();

            return created;
        }

        /// <summary>
        /// Changes whether the app should auto run when the system starts or not
        /// </summary>
        /// <param name="autoRun">True adds a regedit key that makes the app auto run at startup</param>
        public static void ChangeAppAutoRun(bool autoRun)
        {
            //Open the specified key in the registry
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                //Set some strings to use for the key
                string name = Application.ProductName + ".exe";
                string path = System.Reflection.Assembly.GetEntryAssembly().Location;

                //Add or remove the key depending on the autorun parameter
                if (autoRun) key.SetValue(name, path);
                else key.DeleteValue(name, false);
            }
        }

        /// <summary>
        /// Sets the clipboard to value
        /// </summary>
        /// <param name="value">Value to put on the clipboard</param>
        /// <param name="lowerCase">Makes it lower case</param>
        public static void SetClipboard(string value, bool lowerCase)
        {
            //Make the value lower case if specified
            if (lowerCase)
                value = value.ToLower();

            //Copy to clipboard
            Clipboard.SetText(value);
        }
    }
}
