using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
 * A class that holds all the different colors the app uses
 * Also has some helper functions for converting and using the different types of colors
 * 
 * Hexadecimal color value such as #ff0044
 * Hue Saturation Lightness color value such as 360,100,20
 * Red Green Blue color value such as 255,30,59
 */
namespace HexadecaPicker
{
    internal class ColorValues
    {
        public enum TYPE { HEX, HSL, RGB }

        //Define contents. All the different color spaces
        public Color col;    //The color object this color is currently set to
        public string hex;   //The hex string of the current color
        public string hsl;   //The hsl string of the current color
        public string rgb;   //The rgb string of the current color

        public ColorValues(string hex)
        {
            //Set values that can be assigned to simply
            this.col = ColorTranslator.FromHtml(hex);
            this.hex = hex;

            //Convert from HEX and set RGB
            string hexOnly = hex.Replace("#", "");
            int r = Convert.ToInt32(hexOnly.Substring(0, 2), 16);
            int g = Convert.ToInt32(hexOnly.Substring(2, 2), 16);
            int b = Convert.ToInt32(hexOnly.Substring(4, 2), 16);
            this.rgb = $"{r},{g},{b}";

            //Convert HEX and set HSL
            this.hsl = HexToHsl(hex);

            //this.hsl = hsl;
            //this.rgb = rgb;
        }

        /// <summary>
        /// Gets a color value with alpha. HSL doesn't have alpha. So it just returns itself
        /// </summary>
        /// <returns>The color but with alpha</returns>
        public string GetColorWithAlpha(TYPE type)
        {
            //Check type and add an alpha value in a unique way depending on color space
            if (type == TYPE.HEX)
                return this.hex + "ff";
            else if (type == TYPE.HSL)
                return this.hsl;
            else if (type == TYPE.RGB)
                return this.rgb + ",255";

            //Returns empty if no type was specified. I guess it would be empty
            return "";
        }

        /// <summary>
        /// Converts a hex value to hsl
        /// </summary>
        /// <param name="hex">Input</param>
        /// <returns>hsl as string</returns>
        public static string HexToHsl(string hex)
        {
            //Convert hex to RGB
            Color rgbColor = HexToRgb(hex);

            //Normalize RGB values
            double r = (double)rgbColor.R / 255;
            double g = (double)rgbColor.G / 255;
            double b = (double)rgbColor.B / 255;

            //Find max and min RGB values
            double max = Math.Max(Math.Max(r, g), b);
            double min = Math.Min(Math.Min(r, g), b);

            //Calculate Hue
            double h;
            if (max == min)
            {
                h = 0; //undefined
            }
            else if (max == r)
            {
                h = 60 * (((g - b) / (max - min)) % 6);
            }
            else if (max == g)
            {
                h = 60 * (((b - r) / (max - min)) + 2);
            }
            else
            {
                h = 60 * (((r - g) / (max - min)) + 4);
            }

            //Ensure H is within the range [0, 360]
            if (h < 0)
            {
                h += 360;
            }

            //Calculate Lightness
            double l = (max + min) / 2;

            //Calculate Saturation
            double s;
            if (l <= 0.5)
            {
                s = (max - min) / (max + min);
            }
            else
            {
                s = (max - min) / (2 - max - min);
            }

            //Do a NaN check. Some weird NaN thing happens.
            int ss = (int)Math.Round(s * 100);
            if (Double.IsNaN(s) || s < 0)
                ss = 100;

            //Format HSL values for CSS
            return $"{Math.Round(h)},{ss},{Math.Round(l * 100)}";
        }

        //Helper function for the HSL conversion one.
        private static Color HexToRgb(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Wraps a value in CSS. Depending on the type. So a 
        /// </summary>
        /// <param name="value">The color value itself</param>
        /// <param name="type">Type of value it is</param>
        /// <returns>CSS wrapped value</returns>
        public static string WrapInCSS(string value, TYPE type)
        {
            if (type == TYPE.HEX)
                return value;
            else if (type == TYPE.HSL)
                return $"hsl({value});";
            else if (type == TYPE.RGB)
                return $"rgb({value});";

            return value;
        }
    }
}
