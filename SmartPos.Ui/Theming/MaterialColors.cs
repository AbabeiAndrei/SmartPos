using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Ui.Theming
{

    public enum ColorDepth : short
    {
        Default = C500,
        C50 = 0,
        C100 = 1,
        C200 = 2,
        C300 = 3,
        C400 = 4,
        C500 = 5,
        C600 = 6,
        C700 = 7,
        C800 = 8,
        C900 = 9,
        A100 = 10,
        A200 = 11,
        A400 = 12,
        A700 = 13
    }

    public static class MaterialColors
    {
        private enum MaterialColor : short
        {
            Red = 0,
            Pink = 1,
            Purple = 2,
            DeepPurple = 3,
            Indigo = 4,
            Blue = 5,
            LightBlue = 6,
            Cyan = 7,
            Teal = 8,
            Green = 9,
            LightGreen = 10,
            Lime = 11,
            Yellow = 12,
            Amber = 13,
            Orange = 14,
            DeepOrange = 15,
            Brown = 16,
            Grey = 17
        }

        private static readonly IReadOnlyDictionary<MaterialColor, IReadOnlyDictionary<ColorDepth, Color>> _table;

        public static Color Black => Color.Black;
        public static Color White => Color.White;
        public static Color Transparent => Color.Transparent;

        private static Color Default => Black;

        static MaterialColors()
        {
            var table = new Dictionary<MaterialColor, IReadOnlyDictionary<ColorDepth, Color>>
                        {
                            #region Red
                            {
                                MaterialColor.Red,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xFFEBEE.ToColor() },
                                    {ColorDepth.C100, 0xFFCDD2.ToColor() },
                                    {ColorDepth.C200, 0xEF9A9A.ToColor() },
                                    {ColorDepth.C300, 0xE57373.ToColor() },
                                    {ColorDepth.C400, 0xEF5350.ToColor() },
                                    {ColorDepth.C500, 0xF44336.ToColor() },
                                    {ColorDepth.C600, 0xE53935.ToColor() },
                                    {ColorDepth.C700, 0xD32F2F.ToColor() },
                                    {ColorDepth.C800, 0xC62828.ToColor() },
                                    {ColorDepth.C900, 0xB71C1C.ToColor() },
                                    {ColorDepth.A100, 0xFF8A80.ToColor() },
                                    {ColorDepth.A200, 0xFF5252.ToColor() },
                                    {ColorDepth.A400, 0xFF1744.ToColor() },
                                    {ColorDepth.A700, 0xD50000.ToColor() }

                                }.ToReadOnly()
                            },
                            #endregion
                            #region Pink
                            {
                                MaterialColor.Pink, 
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xFCE4EC.ToColor() },
                                    {ColorDepth.C100, 0xF8BBD0.ToColor() },
                                    {ColorDepth.C200, 0xF48FB1.ToColor() },
                                    {ColorDepth.C300, 0xF06292.ToColor() },
                                    {ColorDepth.C400, 0xEC407A.ToColor() },
                                    {ColorDepth.C500, 0xE91E63.ToColor() },
                                    {ColorDepth.C600, 0xD81B60.ToColor() },
                                    {ColorDepth.C700, 0xC2185B.ToColor() },
                                    {ColorDepth.C800, 0xAD1457.ToColor() },
                                    {ColorDepth.C900, 0x880E4F.ToColor() },
                                    {ColorDepth.A100, 0xFF80AB.ToColor() },
                                    {ColorDepth.A200, 0xFF4081.ToColor() },
                                    {ColorDepth.A400, 0xF50057.ToColor() },
                                    {ColorDepth.A700, 0xC51162.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Purple
                            {
                                MaterialColor.Purple,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xF3E5F5.ToColor() },
                                    {ColorDepth.C100, 0xE1BEE7.ToColor() },
                                    {ColorDepth.C200, 0xCE93D8.ToColor() },
                                    {ColorDepth.C300, 0xBA68C8.ToColor() },
                                    {ColorDepth.C400, 0xAB47BC.ToColor() },
                                    {ColorDepth.C500, 0x9C27B0.ToColor() },
                                    {ColorDepth.C600, 0x8E24AA.ToColor() },
                                    {ColorDepth.C700, 0x7B1FA2.ToColor() },
                                    {ColorDepth.C800, 0x6A1B9A.ToColor() },
                                    {ColorDepth.C900, 0x4A148C.ToColor() },
                                    {ColorDepth.A100, 0xEA80FC.ToColor() },
                                    {ColorDepth.A200, 0xE040FB.ToColor() },
                                    {ColorDepth.A400, 0xD500F9.ToColor() },
                                    {ColorDepth.A700, 0xAA00FF.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Green
                            {
                                MaterialColor.Green,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE8F5E9.ToColor() },
                                    {ColorDepth.C100, 0xC8E6C9.ToColor() },
                                    {ColorDepth.C200, 0xA5D6A7.ToColor() },
                                    {ColorDepth.C300, 0x81C784.ToColor() },
                                    {ColorDepth.C400, 0x66BB6A.ToColor() },
                                    {ColorDepth.C500, 0x4CAF50.ToColor() },
                                    {ColorDepth.C600, 0x43A047.ToColor() },
                                    {ColorDepth.C700, 0x388E3C.ToColor() },
                                    {ColorDepth.C800, 0x2E7D32.ToColor() },
                                    {ColorDepth.C900, 0x1B5E20.ToColor() },
                                    {ColorDepth.A100, 0xB9F6CA.ToColor() },
                                    {ColorDepth.A200, 0x69F0AE.ToColor() },
                                    {ColorDepth.A400, 0x00E676.ToColor() },
                                    {ColorDepth.A700, 0x00C853.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Amber
                            {
                                MaterialColor.Amber,
                                new Dictionary<ColorDepth, Color>
                                {
                                    //nothing done
                                    {ColorDepth.C50, 0xFFF8E1.ToColor() },
                                    {ColorDepth.C100, 0xFFECB3.ToColor() },
                                    {ColorDepth.C200, 0xFFE082.ToColor() },
                                    {ColorDepth.C300, 0xFFD54F.ToColor() },
                                    {ColorDepth.C400, 0xFFCA28.ToColor() },
                                    {ColorDepth.C500, 0xFFC107.ToColor() },
                                    {ColorDepth.C600, 0xFFB300.ToColor() },
                                    {ColorDepth.C700, 0xFFA000.ToColor() },
                                    {ColorDepth.C800, 0xFF8F00.ToColor() },
                                    {ColorDepth.C900, 0xFF6F00.ToColor() },
                                    {ColorDepth.A100, 0xFFE57F.ToColor() },
                                    {ColorDepth.A200, 0xFFD740.ToColor() },
                                    {ColorDepth.A400, 0xFFC400.ToColor() },
                                    {ColorDepth.A700, 0xFFAB00.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Grey
                            {
                                MaterialColor.Grey,
                                new Dictionary<ColorDepth, Color>
                                {
                                    //nothing done
                                    {ColorDepth.C50, 0xFAFAFA.ToColor() },
                                    {ColorDepth.C100, 0xF5F5F5.ToColor() },
                                    {ColorDepth.C200, 0xEEEEEE.ToColor() },
                                    {ColorDepth.C300, 0xE0E0E0.ToColor() },
                                    {ColorDepth.C400, 0xBDBDBD.ToColor() },
                                    {ColorDepth.C500, 0x9E9E9E.ToColor() },
                                    {ColorDepth.C600, 0x757575.ToColor() },
                                    {ColorDepth.C700, 0x616161.ToColor() },
                                    {ColorDepth.C800, 0x424242.ToColor() },
                                    {ColorDepth.C900, 0x212121.ToColor() }
                                }.ToReadOnly()
                            }
                            #endregion
                        };

            _table = new ReadOnlyDictionary<MaterialColor, IReadOnlyDictionary<ColorDepth, Color>>(table);
        }

        public static Color Red(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Red, depth);
        }

        public static Color Pink(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Pink, depth);
        }

        public static Color Purple(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Purple, depth);
        }

        public static Color DeepPurple(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.DeepPurple, depth);
        }
        
        public static Color Indigo(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Indigo, depth);
        }

        public static Color Blue(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Blue, depth);
        }

        public static Color LightBlue(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.LightBlue, depth);
        }

        public static Color Cyan(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Cyan, depth);
        }

        public static Color Teal(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Teal, depth);
        }

        public static Color Green(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Green, depth);
        }

        public static Color LightGreen(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.LightGreen, depth);
        }

        public static Color Lime(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Lime, depth);
        }

        public static Color Yellow(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Yellow, depth);
        }

        public static Color Amber(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Amber, depth);
        }

        public static Color Orange(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Orange, depth);
        }

        public static Color DeepOrange(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.DeepOrange, depth);
        }

        public static Color Brown(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Brown, depth);
        }

        public static Color Grey(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.Grey, depth);
        }

        private static Color GetColorImpl(MaterialColor color, ColorDepth depth)
        {
            if (!_table.ContainsKey(color))
                return Default;

            var colorRange = _table[color];

            return colorRange.ContainsKey(depth)
                       ? colorRange[depth]
                       : colorRange[ColorDepth.Default];
        }
    }
}
