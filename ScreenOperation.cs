using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Contains a bunch of functionality that lets the app lock inputs and fetch color info on the screen.
 */

namespace HexadecaPicker
{
    internal class ScreenOperation
    {
        //Set some static variables
        private static Timer timer;
        private static bool pickingColor = false;
        private static IntPtr hookID = IntPtr.Zero;
        private static HookProc hookProc;//Make a static reference to the hook to make sure the garbage collector doesn't come around to collect
        private static Control sMainForm;

        //Some state bools. Used for checking if the ticker/timer has to run or not
        public static bool colorIsPicking = false;
        public static bool zoomIsShowing = false;

        //Import WinAPI functions and constants
        private const int WH_MOUSE_LL = 14;

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202
        }

        /// <summary>
        /// MAIN INSERTION POINT
        /// Locks any interaction on the user's screen until one click is made.
        /// </summary>
        public static void LockScreen(Control mainForm)
        {
            //Automatically open the zoom window if auto zoom was enabled
            if (Properties.Settings.Default.AutoZoom && frmMain.zoomWindow == null)
                frmMain.ToggleZoomWindow((Form)mainForm);

            //Set a static reference to mainForm
            sMainForm = mainForm;

            //Set up the mouse hook and block other inputs
            BlockInput(true);
            hookProc = HookCallback;
            hookID = SetHook(hookProc);

            //Sets a timer that constantly updates controls that show colors and what not. But only if nothing is showing or picking
            if(!colorIsPicking && !zoomIsShowing)
                SetTicker(mainForm);

            //Mark color is picking as true, because this function makes it so.
            colorIsPicking = true;
        }

        /// <summary>
        /// Sets the ticker used for updating information to the main window and zoom window
        /// </summary>
        /// <param name="mainForm">Reference to the main form</param>
        public static void SetTicker(Control mainForm)
        {
            timer = new Timer();
            timer.Interval = 160;
            timer.Tick += (s, e) =>
            {
                //Get cursor positions
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;

                if (colorIsPicking)
                {
                    //Update the color controls and info in the colorpicker
                    string v = Common.GetPixelColorAtPoint(x, y);
                    ColorPicker.ChangeColor(mainForm, v);
                }

                if (zoomIsShowing)
                {
                    //Update the zoom window if it's showing. The position of it is updated in the formZoom class (To make it update more often)
                    if (frmMain.zoomWindow != null)
                    {
                        frmMain.zoomWindow.UpdateZoomWindow(x, y);
                        formZoom.curCol.BackColor = ColorPicker.currentColor.col;
                    }
                }

                //Debug.
                //mainForm.Controls.Find("lblStatus", true)[0].Text = "" + Cursor.Position.X;
            };
            timer.Start();
        }
        
        /// <summary>
        /// Stops the timer/ticker depending on the state of the two booleans (zoomIsShowing and colorIsPicking)
        /// </summary>
        public static void StopTicker()
        {
            timer.Enabled = false;
            timer.Stop();
            timer = null;
        }

        //Helper. Define the callback function for the mouse hook
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //Left mouse button is clicked
            if (nCode >= 0 && (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam || MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam))
            {
                //Make sure input is blocked in case it wasn't earlier. Might be unnecessary.
                BlockInput(true);

                //This makes so that picking is done after this left click is done.
                TogglePickingColor();

                //Prevents clickthrough
                return (IntPtr)1;
            }

            //Win API stuff. Unimportant
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        //Helper. Set up the global mouse hook
        private static IntPtr SetHook(HookProc proc)
        {
            using (ProcessModule curModule = Process.GetCurrentProcess().MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        //Helper. Unhook the mouse hook
        private static void Unhook()
        {
            UnhookWindowsHookEx(hookID);
        }

        //Helper. Toggle between picking color and not picking color
        static void TogglePickingColor()
        {
            pickingColor = !pickingColor;
            if (pickingColor)
            {
                //Start picking color (Does nothing)
            }
            else
            {
                //Color is currently not being picked. Since it just closed
                colorIsPicking = false;

                //Stop picking color
                if (!colorIsPicking && !zoomIsShowing)
                    StopTicker();

                BlockInput(false);
                sMainForm.Controls.Find("lblStatus", true)[0].Text = "Ready";

                //Unhook the mouse hook
                Unhook();

                //Remove zoom window automatically if it's set to do so
                if (Properties.Settings.Default.AutoZoom && frmMain.zoomWindow != null)
                    frmMain.ToggleZoomWindow((Form)sMainForm);
            }
        }
    }
}
