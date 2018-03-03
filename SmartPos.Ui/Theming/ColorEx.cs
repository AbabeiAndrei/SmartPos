using System;
using System.Drawing;

namespace SmartPos.Ui.Theming
{
    public static class ColorEx
    {
        public static Color ToColor(this int color)
        {
            var str = Convert.ToString(color, 16);

            if (str.Length != 6)
                return Color.FromArgb(color);

            var red = Convert.ToInt32(str[0] + "" + str[1], 16);
            var blue = Convert.ToInt32(str[2] + "" + str[3], 16);
            var green = Convert.ToInt32(str[4] + "" + str[5], 16);

            return Color.FromArgb(red, blue, green);
        }
    }
}
