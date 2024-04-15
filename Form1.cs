using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * The main form of the app
 * 
 * NOTE this
 *      I wanted to note, for anyone wonder. Yes, i know the frmMain doesn't need a "this". I just think it makes it more legible
 */

namespace HexadecaPicker
{
    public partial class frmMain : Form
    {
        //Some globals
        public static formZoom zoomWindow;  //Reference to the zoom window

        public frmMain()
        {
            //Initializes the other part of this class
            InitializeComponent();

            //Place the window where the user's system tray is
            Rectangle trayPos = Common.GetSystemTrayPosition();
            Common.PlaceWindowAtSystemTray(this, trayPos);

            //Initialize the current color
            ColorPicker.Init();
            ColorPicker.UpdateColorControls(this);

            //Set a default color
            ColorPicker.ChangeColor(this, "#ffffff");

            //Set right click functionality to the color copy buttons
            btnCopyColorHex.MouseDown += CopyButtonRightClick;
            btnCopyColorHsl.MouseDown += CopyButtonRightClick;
            btnCopyColorRgb.MouseDown += CopyButtonRightClick;

            //Configure the tray icon
            ConfigureNotificationTray();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //Always close the app if windows is shutting down or if an Application.Exit() call is made
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            //Otherwise, minimize to tray.. Or.. Hide the window.
            this.Visible = false;
            e.Cancel = true;
        }

        //Color button listeners
        private void btnCopyColorHex_Click(object sender, EventArgs e) { CopyButtonLeftClick(sender, e); }//Click on Hex button
        private void btnCopyColorRgb_Click(object sender, EventArgs e) { CopyButtonLeftClick(sender, e); }//Click on Rgb button
        private void btnCopyColorHsl_Click(object sender, EventArgs e) { CopyButtonLeftClick(sender, e); }//Click on Hsl
        
        //Click the color box in the lower left corner opens a color picker dialog
        private void pctCurrentColor_Click(object sender, EventArgs e)
        {
            //Initialize and show the color dialog
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            //If the result of the dialog is "ok", process and change the colors
            if(result == DialogResult.OK)
            {
                ColorPicker.ChangeColor(this, Common.ColorToHex(colorDialog.Color));
            }
        }

        //Pick Color button
        private void btnPick_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Picking Color";
            ScreenOperation.LockScreen(this);
        }

        //Options menu button event listener
        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            //Set up the context menu
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            //Add items
            contextMenu = CommonMenu.GetCommonMenuStrip(this);

            //Show the menu
            contextMenu.Show(Cursor.Position);
        }

        //Zoom window button
        private void btnZoomWindow_Click(object sender, EventArgs e)
        {
            ToggleZoomWindow(this);
        }

        //Check box changed listener for lower case
        private void chkLowerCase_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LowerCase = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        //Check box changed listener for auto start
        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();

            Common.ChangeAppAutoRun(((CheckBox)sender).Checked);
        }

        //Toggles the zoom window from showing to not.
        public static void ToggleZoomWindow(Form frm)
        {
            //Toggle it
            if (zoomWindow == null)
            {
                //Set ticker if it's not already running
                if (!ScreenOperation.colorIsPicking && !ScreenOperation.zoomIsShowing)
                    ScreenOperation.SetTicker(frm);

                //Set the form state.
                zoomWindow = new formZoom();
                zoomWindow.Show();

                //Set state of the ticker/timer
                ScreenOperation.zoomIsShowing = true;
            }
            else
            {
                //Set zoom state to false. It's no longer showing
                ScreenOperation.zoomIsShowing = false;

                //Stop ticker if it's applicable
                if (!ScreenOperation.colorIsPicking && !ScreenOperation.zoomIsShowing)
                    ScreenOperation.StopTicker();

                //Set the form state
                zoomWindow.Close();
                zoomWindow = null;
            }
        }

        //Runs when the left button is clicked on any of the color copy buttons (The ones to the top of the window)
        private void CopyButtonLeftClick(object sender, EventArgs e)
        {
            //Get a reference to the sender
            Button btn = (Button)sender;

            if (btn.Text != "Copied")
            {
                //Reference to the main form. Used to update the button back to its original text
                Form f = this;

                //Original value of what was copied.
                string originalVal = btn.Text;

                //Set what's in the text in the clipboard
                Common.SetClipboard(btn.Text, Properties.Settings.Default.LowerCase);

                //Delay changing button text back
                Common.DelayChangeBackOfButton(f, btn, originalVal);
            }
        }

        //Runs when right button is clicked on one of the copy color buttons. Shows a little menu for copy options
        private void CopyButtonRightClick(object sender, EventArgs e)
        {
            //Determine if the right mouse button was clicked
            bool rightClick = ((MouseEventArgs)e).Button == MouseButtons.Right;

            if (rightClick)
            {
                //Get the Control of the object
                Control control = (Control)sender;

                //Get the type that the button has by checking the name of it
                ColorValues.TYPE type = ColorValues.TYPE.HEX;
                if (control.Name == btnCopyColorHex.Name)
                    type = ColorValues.TYPE.HEX;
                else if (control.Name == btnCopyColorHsl.Name)
                    type = ColorValues.TYPE.HSL;
                else if (control.Name == btnCopyColorRgb.Name)
                    type = ColorValues.TYPE.RGB;

                //Get the text of the button
                string text = ((Button)sender).Text;
                string cssText = ColorValues.WrapInCSS(text, type);

                //Define a list of pairs of menu item names and what they copy to the clipboard
                List<Tuple<string, string>> itemInfoPairs = new List<Tuple<string, string>>();
                itemInfoPairs.Add(Tuple.Create("Just Numbers", $"{text.Replace("#", "")}"));
                itemInfoPairs.Add(Tuple.Create("Css color", $"color: {cssText}"));
                itemInfoPairs.Add(Tuple.Create("Css background", $"background-color: {cssText}"));

                //Instantiate the context menu itself
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                //Add items to the menu
                for(int i = 0; i < itemInfoPairs.Count; ++i)
                {
                    //The contents of the menu item. What will be copied
                    string contents = itemInfoPairs[i].Item2;

                    //Create an item for the context menu
                    ToolStripMenuItem item = new ToolStripMenuItem(itemInfoPairs[i].Item1);
                    item.MouseDown += new MouseEventHandler((o, me) =>
                    {
                        //Set what's in the text in the clipboard
                        Common.SetClipboard(contents, Properties.Settings.Default.LowerCase);

                        //Delay changing button text back
                        Common.DelayChangeBackOfButton(this, (Button)sender, text);
                    });

                    //Add the item to the context menu
                    contextMenu.Items.Add(item);
                }

                //Show the menu where the cursor is
                contextMenu.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Configures the notification tray control
        /// </summary>
        private void ConfigureNotificationTray()
        {
            //Define some basic stuff
            ntf.Icon = Properties.Resources.color_picker;
            ntf.Text = Application.ProductName;

            //Set the context menu
            ntf.ContextMenuStrip = CommonMenu.GetCommonMenuStrip(this);

            //Set mouse click behavior
            ntf.MouseClick += new MouseEventHandler((o, e) =>
            {
                //Only do left click actions
                if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    this.Visible = !this.Visible;
                }
            });
        }

    }
}
