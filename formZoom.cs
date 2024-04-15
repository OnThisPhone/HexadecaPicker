using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Form window that handles everything related to zooming
 * 
 * NOTE The way the graphics are blitted onto the window/form isn't the fastest (There are better ways of doing it), but
 *      it works for this application. Fast enough!
 */

namespace HexadecaPicker
{
    public partial class formZoom : Form
    {
        private static int w;                           //Width of form
        private static int h;                           //Height of form
        private static int zw;                          //Zoom width of form
        private static int zh;                          //Zoom height of form
        private readonly static float zoomFactor = 4;   //Zoom factor
        private static Timer locationUpdateTimer = null;//Timer for updating the window location with the mouse cursor
        public static PictureBox curCol;                //Current color, as displayed in the zoom window

        public formZoom()
        {
            //Initialize other half of class
            InitializeComponent();

            //Get the height and width of the form and the zoom width and height
            w = this.Width;
            h = this.Height;
            zw = (int)((float)w / zoomFactor);
            zh = (int)((float)h / zoomFactor);

            //Set the "target" box to the zoom factor
            pctTarget.Width *= (int)zoomFactor;
            pctTarget.Height *= (int)zoomFactor;
            curCol = pctCurrentColor;

            //Set the timer the window is updated on
            locationUpdateTimer = new Timer();
            locationUpdateTimer.Interval = 2;
            locationUpdateTimer.Tick += (s, e) =>
            {
                //Get cursor positions
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;

                //Update location of the window
                Location = new Point(x + 20, y + 20);
            };
            locationUpdateTimer.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            locationUpdateTimer.Stop();
            locationUpdateTimer = null;
        }

        /// <summary>
        /// Updates the zoom window
        /// </summary>
        /// <param name="x">mouse x</param>
        /// <param name="y">mouse y</param>
        public void UpdateZoomWindow(int x, int y)
        {
            //Initialize the bitmap object
            Bitmap ss = new Bitmap(zw, zh);

            //Update x and y to make so that the window centers on the mouse position. Instead of having it at the upper left
            x -= zw / 2;
            y -= zh / 2;

            //Blit graphics from the user's screen to the bitmap object
            using (Graphics g = Graphics.FromImage(ss))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.CopyFromScreen(x, y, 0, 0, new Size(zw, zh));
            }

            //Show the bitmap object on the form itself
            pctZoom.Image = ss;
        }
    }
}
