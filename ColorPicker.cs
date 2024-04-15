using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Contains everything related to picking colors.
 * It can change controls, it fixes HSL, HEX and RGB conversion, etc.
 * 
 */
namespace HexadecaPicker
{
    internal class ColorPicker
    {
        //Globals
        public static ColorValues currentColor;

        /// <summary>
        /// Initializes the currentColor to an object
        /// </summary>
        public static void Init()
        {
            currentColor = new ColorValues("#559977");
        }

        /// <summary>
        /// Changes colors of all the controls
        /// </summary>
        /// <param name="mainForm">The form containing all the controls</param>
        /// <param name="hex">The color value as hex</param>
        public static void ChangeColor(Control mainForm, string hex)
        {
            currentColor = new ColorValues(hex);
            UpdateColorControls(mainForm);
        }

        /// <summary>
        /// Updates all the controls with the current color
        /// </summary>
        public static void UpdateColorControls(Control mainForm)
        {
            //Represents a reference to the main form
            var form = (frmMain)mainForm;

            //Get some controls to be used
            Control pctCurrentColor = (PictureBox)form.Controls.Find("pctCurrentColor", true)[0];
            Control btnCopyColorHex = (Button)form.Controls.Find("btnCopyColorHex", true)[0];
            Control btnCopyColorHsl = (Button)form.Controls.Find("btnCopyColorHsl", true)[0];
            Control btnCopyColorRgb = (Button)form.Controls.Find("btnCopyColorRgb", true)[0];

            pctCurrentColor.BackColor = currentColor.col;
            btnCopyColorHex.Text = currentColor.hex.ToUpper();
            btnCopyColorHsl.Text = currentColor.hsl.ToUpper();
            btnCopyColorRgb.Text = currentColor.rgb.ToUpper();
        }
    }
}
