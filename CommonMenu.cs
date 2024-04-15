using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Handles the option menu. The common options menu used by the tray and the app window
 */

namespace HexadecaPicker
{
    internal class CommonMenu
    {
        /// <summary>
        /// Gets an array of common menu items, used for the tray and the options menu.
        /// </summary>
        /// <param name="form">The main form</param>
        /// <returns>Returns a list of items</returns>
        public static object[] GetCommonMenuItems(Form form)
        {
            //Add the items to use
            ToolStripMenuItem itemMagnify = new ToolStripMenuItem("Magnify");

            ToolStripMenuItem itemTwitter = new ToolStripMenuItem("Twitter");
            ToolStripMenuItem itemGithub = new ToolStripMenuItem("Github");
            ToolStripMenuItem itemYoutube = new ToolStripMenuItem("Youtube");

            ToolStripSeparator div = new ToolStripSeparator();//They had to be two seperate objects.
            ToolStripSeparator div2 = new ToolStripSeparator();

            ToolStripMenuItem itemAbout = new ToolStripMenuItem("About");
            ToolStripMenuItem itemMinimizeToTray = new ToolStripMenuItem("Minimize to Tray");
            ToolStripMenuItem itemExit = new ToolStripMenuItem("Exit");

            //Handle Clicks
            itemMagnify.Click += new EventHandler((o, ev) => { frmMain.ToggleZoomWindow(form); });
            itemTwitter.Click += new EventHandler((o, ev) => { Process.Start("https://twitter.com/JennaGrip"); });
            itemGithub.Click += new EventHandler((o, ev) => { Process.Start("https://github.com/OnThisPhone"); });
            itemYoutube.Click += new EventHandler((o, ev) => { Process.Start("https://www.youtube.com/channel/UCX9yu9x08bV49OUimOIZzhQ"); });
            itemAbout.Click += new EventHandler((o, ev) => { MessageBox.Show("Made by Victoria Grip.\nI got tired of not having a color picker that wasn't slow to boot up (Photoshop), so i made this.\nCredits to AriqStock for the color picker icon.\nCompletely open. Do what you want with it. Credit is optional.", "About"); });
            itemMinimizeToTray.Click += new EventHandler((o, ev) => { form.Close(); });
            itemExit.Click += new EventHandler((o, ev) => { Application.Exit(); });

            //(Eh.. Not that pretty)
            object[] r = {itemMagnify, div2, itemTwitter, itemGithub, itemYoutube, itemAbout, div, itemMinimizeToTray, itemExit };
            return r;
        }

        /// <summary>
        /// Gets the common menu strip as a context menu strip item
        /// </summary>
        /// <param name="form">The main form</param>
        /// <returns>A menu object</returns>
        public static ContextMenuStrip GetCommonMenuStrip(Form form)
        {
            //Declare some values
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            object[] items = GetCommonMenuItems(form);

            //Add items (Because it includes a seperator (Which is a different type), you have to check for types)
            foreach (object it in items)
            {
                if (it.GetType() == typeof(ToolStripMenuItem))
                    contextMenu.Items.Add((ToolStripMenuItem)it);

                if (it.GetType() == typeof(ToolStripSeparator))
                    contextMenu.Items.Add((ToolStripSeparator)it);
            }

            //Return the menu
            return contextMenu;
        }
    }
}
