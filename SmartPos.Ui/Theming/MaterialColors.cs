using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        #region Enums

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
            Grey = 17,
            BlueGray = 18
        }

        #endregion

        #region Fields

        private static readonly IReadOnlyDictionary<MaterialColor, IReadOnlyDictionary<ColorDepth, Color>> _table;

        #endregion

        #region Properties

        public static Color Black => Color.Black;
        public static Color White => Color.White;
        public static Color Transparent => Color.Transparent;

        private static Color Default => Black;

        #endregion

        #region Constructors

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
                            #region DeepPurple
                            {
                                MaterialColor.DeepPurple,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xEDE7F6.ToColor() },
                                    {ColorDepth.C100, 0xD1C4E9.ToColor() },
                                    {ColorDepth.C200, 0xB39DDB.ToColor() },
                                    {ColorDepth.C300, 0x9575CD.ToColor() },
                                    {ColorDepth.C400, 0x7E57C2.ToColor() },
                                    {ColorDepth.C500, 0x673AB7.ToColor() },
                                    {ColorDepth.C600, 0x5E35B1.ToColor() },
                                    {ColorDepth.C700, 0x512DA8.ToColor() },
                                    {ColorDepth.C800, 0x4527A0.ToColor() },
                                    {ColorDepth.C900, 0x311B92.ToColor() },
                                    {ColorDepth.A100, 0xB388FF.ToColor() },
                                    {ColorDepth.A200, 0x7C4DFF.ToColor() },
                                    {ColorDepth.A400, 0x651FFF.ToColor() },
                                    {ColorDepth.A700, 0x6200EA.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Indigo
                            {
                                MaterialColor.Indigo,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE8EAF6.ToColor() },
                                    {ColorDepth.C100, 0xC5CAE9.ToColor() },
                                    {ColorDepth.C200, 0x9FA8DA.ToColor() },
                                    {ColorDepth.C300, 0x7986CB.ToColor() },
                                    {ColorDepth.C400, 0x5C6BC0.ToColor() },
                                    {ColorDepth.C500, 0x3F51B5.ToColor() },
                                    {ColorDepth.C600, 0x3949AB.ToColor() },
                                    {ColorDepth.C700, 0x303F9F.ToColor() },
                                    {ColorDepth.C800, 0x283593.ToColor() },
                                    {ColorDepth.C900, 0x1A237E.ToColor() },
                                    {ColorDepth.A100, 0x8C9EFF.ToColor() },
                                    {ColorDepth.A200, 0x536DFE.ToColor() },
                                    {ColorDepth.A400, 0x3D5AFE.ToColor() },
                                    {ColorDepth.A700, 0x304FFE.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Blue
                            {
                                MaterialColor.Blue,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE3F2FD.ToColor() },
                                    {ColorDepth.C100, 0xBBDEFB.ToColor() },
                                    {ColorDepth.C200, 0x90CAF9.ToColor() },
                                    {ColorDepth.C300, 0x64B5F6.ToColor() },
                                    {ColorDepth.C400, 0x42A5F5.ToColor() },
                                    {ColorDepth.C500, 0x2196F3.ToColor() },
                                    {ColorDepth.C600, 0x1E88E5.ToColor() },
                                    {ColorDepth.C700, 0x1976D2.ToColor() },
                                    {ColorDepth.C800, 0x1565C0.ToColor() },
                                    {ColorDepth.C900, 0x0D47A1.ToColor() },
                                    {ColorDepth.A100, 0x82B1FF.ToColor() },
                                    {ColorDepth.A200, 0x448AFF.ToColor() },
                                    {ColorDepth.A400, 0x2979FF.ToColor() },
                                    {ColorDepth.A700, 0x2962FF.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region LightBlue
                            {
                                MaterialColor.LightBlue,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE1F5FE.ToColor() },
                                    {ColorDepth.C100, 0xB3E5FC.ToColor() },
                                    {ColorDepth.C200, 0x81D4FA.ToColor() },
                                    {ColorDepth.C300, 0x4FC3F7.ToColor() },
                                    {ColorDepth.C400, 0x29B6F6.ToColor() },
                                    {ColorDepth.C500, 0x03A9F4.ToColor() },
                                    {ColorDepth.C600, 0x039BE5.ToColor() },
                                    {ColorDepth.C700, 0x0288D1.ToColor() },
                                    {ColorDepth.C800, 0x0277BD.ToColor() },
                                    {ColorDepth.C900, 0x01579B.ToColor() },
                                    {ColorDepth.A100, 0x80D8FF.ToColor() },
                                    {ColorDepth.A200, 0x40C4FF.ToColor() },
                                    {ColorDepth.A400, 0x00B0FF.ToColor() },
                                    {ColorDepth.A700, 0x0091EA.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Cyan
                            {
                                MaterialColor.Cyan,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE0F7FA.ToColor() },
                                    {ColorDepth.C100, 0xB2EBF2.ToColor() },
                                    {ColorDepth.C200, 0x80DEEA.ToColor() },
                                    {ColorDepth.C300, 0x4DD0E1.ToColor() },
                                    {ColorDepth.C400, 0x26C6DA.ToColor() },
                                    {ColorDepth.C500, 0x00BCD4.ToColor() },
                                    {ColorDepth.C600, 0x00ACC1.ToColor() },
                                    {ColorDepth.C700, 0x0097A7.ToColor() },
                                    {ColorDepth.C800, 0x00838F.ToColor() },
                                    {ColorDepth.C900, 0x006064.ToColor() },
                                    {ColorDepth.A100, 0x84FFFF.ToColor() },
                                    {ColorDepth.A200, 0x18FFFF.ToColor() },
                                    {ColorDepth.A400, 0x00E5FF.ToColor() },
                                    {ColorDepth.A700, 0x00B8D4.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Teal
                            {
                                MaterialColor.Teal,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xE0F2F1.ToColor() },
                                    {ColorDepth.C100, 0xB2DFDB.ToColor() },
                                    {ColorDepth.C200, 0x80CBC4.ToColor() },
                                    {ColorDepth.C300, 0x4DB6AC.ToColor() },
                                    {ColorDepth.C400, 0x26A69A.ToColor() },
                                    {ColorDepth.C500, 0x009688.ToColor() },
                                    {ColorDepth.C600, 0x00897B.ToColor() },
                                    {ColorDepth.C700, 0x00796B.ToColor() },
                                    {ColorDepth.C800, 0x00695C.ToColor() },
                                    {ColorDepth.C900, 0x004D40.ToColor() },
                                    {ColorDepth.A100, 0xA7FFEB.ToColor() },
                                    {ColorDepth.A200, 0x64FFDA.ToColor() },
                                    {ColorDepth.A400, 0x1DE9B6.ToColor() },
                                    {ColorDepth.A700, 0x00BFA5.ToColor() }
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
                            #region LightGreen
                            {
                                MaterialColor.LightGreen,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xF1F8E9.ToColor() },
                                    {ColorDepth.C100, 0xDCEDC8.ToColor() },
                                    {ColorDepth.C200, 0xC5E1A5.ToColor() },
                                    {ColorDepth.C300, 0xAED581.ToColor() },
                                    {ColorDepth.C400, 0x9CCC65.ToColor() },
                                    {ColorDepth.C500, 0x8BC34A.ToColor() },
                                    {ColorDepth.C600, 0x7CB342.ToColor() },
                                    {ColorDepth.C700, 0x689F38.ToColor() },
                                    {ColorDepth.C800, 0x558B2F.ToColor() },
                                    {ColorDepth.C900, 0x33691E.ToColor() },
                                    {ColorDepth.A100, 0xCCFF90.ToColor() },
                                    {ColorDepth.A200, 0xB2FF59.ToColor() },
                                    {ColorDepth.A400, 0x76FF03.ToColor() },
                                    {ColorDepth.A700, 0x64DD17.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Lime
                            {
                                MaterialColor.Lime,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xF9FBE7.ToColor() },
                                    {ColorDepth.C100, 0xF0F4C3.ToColor() },
                                    {ColorDepth.C200, 0xE6EE9C.ToColor() },
                                    {ColorDepth.C300, 0xDCE775.ToColor() },
                                    {ColorDepth.C400, 0xD4E157.ToColor() },
                                    {ColorDepth.C500, 0xCDDC39.ToColor() },
                                    {ColorDepth.C600, 0xC0CA33.ToColor() },
                                    {ColorDepth.C700, 0xAFB42B.ToColor() },
                                    {ColorDepth.C800, 0x9E9D24.ToColor() },
                                    {ColorDepth.C900, 0x827717.ToColor() },
                                    {ColorDepth.A100, 0xF4FF81.ToColor() },
                                    {ColorDepth.A200, 0xEEFF41.ToColor() },
                                    {ColorDepth.A400, 0xC6FF00.ToColor() },
                                    {ColorDepth.A700, 0xAEEA00.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Yellow
                            {
                                MaterialColor.Yellow,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xFFFDE7.ToColor() },
                                    {ColorDepth.C100, 0xFFF9C4.ToColor() },
                                    {ColorDepth.C200, 0xFFF59D.ToColor() },
                                    {ColorDepth.C300, 0xFFF176.ToColor() },
                                    {ColorDepth.C400, 0xFFEE58.ToColor() },
                                    {ColorDepth.C500, 0xFFEB3B.ToColor() },
                                    {ColorDepth.C600, 0xFDD835.ToColor() },
                                    {ColorDepth.C700, 0xFBC02D.ToColor() },
                                    {ColorDepth.C800, 0xF9A825.ToColor() },
                                    {ColorDepth.C900, 0xF57F17.ToColor() },
                                    {ColorDepth.A100, 0xFFFF8D.ToColor() },
                                    {ColorDepth.A200, 0xFFFF00.ToColor() },
                                    {ColorDepth.A400, 0xFFEA00.ToColor() },
                                    {ColorDepth.A700, 0xFFD600.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Amber
                            {
                                MaterialColor.Amber,
                                new Dictionary<ColorDepth, Color>
                                {
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
                            #region Orange
                            {
                                MaterialColor.Orange,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xFFF3E0.ToColor() },
                                    {ColorDepth.C100, 0xFFE0B2.ToColor() },
                                    {ColorDepth.C200, 0xFFCC80.ToColor() },
                                    {ColorDepth.C300, 0xFFB74D.ToColor() },
                                    {ColorDepth.C400, 0xFFA726.ToColor() },
                                    {ColorDepth.C500, 0xFF9800.ToColor() },
                                    {ColorDepth.C600, 0xFB8C00.ToColor() },
                                    {ColorDepth.C700, 0xF57C00.ToColor() },
                                    {ColorDepth.C800, 0xEF6C00.ToColor() },
                                    {ColorDepth.C900, 0xE65100.ToColor() },
                                    {ColorDepth.A100, 0xFFD180.ToColor() },
                                    {ColorDepth.A200, 0xFFAB40.ToColor() },
                                    {ColorDepth.A400, 0xFF9100.ToColor() },
                                    {ColorDepth.A700, 0xFF6D00.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region DeepOrange
                            {
                                MaterialColor.DeepOrange,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xFBE9E7.ToColor() },
                                    {ColorDepth.C100, 0xFFCCBC.ToColor() },
                                    {ColorDepth.C200, 0xFFAB91.ToColor() },
                                    {ColorDepth.C300, 0xFF8A65.ToColor() },
                                    {ColorDepth.C400, 0xFF7043.ToColor() },
                                    {ColorDepth.C500, 0xFF5722.ToColor() },
                                    {ColorDepth.C600, 0xF4511E.ToColor() },
                                    {ColorDepth.C700, 0xE64A19.ToColor() },
                                    {ColorDepth.C800, 0xD84315.ToColor() },
                                    {ColorDepth.C900, 0xBF360C.ToColor() },
                                    {ColorDepth.A100, 0xFF9E80.ToColor() },
                                    {ColorDepth.A200, 0xFF6E40.ToColor() },
                                    {ColorDepth.A400, 0xFF3D00.ToColor() },
                                    {ColorDepth.A700, 0xDD2C00.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Brown
                            {
                                MaterialColor.Brown,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xEFEBE9.ToColor() },
                                    {ColorDepth.C100, 0xD7CCC8.ToColor() },
                                    {ColorDepth.C200, 0xBCAAA4.ToColor() },
                                    {ColorDepth.C300, 0xA1887F.ToColor() },
                                    {ColorDepth.C400, 0x8D6E63.ToColor() },
                                    {ColorDepth.C500, 0x795548.ToColor() },
                                    {ColorDepth.C600, 0x6D4C41.ToColor() },
                                    {ColorDepth.C700, 0x5D4037.ToColor() },
                                    {ColorDepth.C800, 0x4E342E.ToColor() },
                                    {ColorDepth.C900, 0x3E2723.ToColor() }
                                }.ToReadOnly()
                            },
                            #endregion
                            #region Grey
                            {
                                MaterialColor.Grey,
                                new Dictionary<ColorDepth, Color>
                                {
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
                            },
                            #endregion
                            #region BlueGray
                            {
                                MaterialColor.BlueGray,
                                new Dictionary<ColorDepth, Color>
                                {
                                    {ColorDepth.C50, 0xECEFF1.ToColor() },
                                    {ColorDepth.C100, 0xCFD8DC.ToColor() },
                                    {ColorDepth.C200, 0xB0BEC5.ToColor() },
                                    {ColorDepth.C300, 0x90A4AE.ToColor() },
                                    {ColorDepth.C400, 0x78909C.ToColor() },
                                    {ColorDepth.C500, 0x607D8B.ToColor() },
                                    {ColorDepth.C600, 0x546E7A.ToColor() },
                                    {ColorDepth.C700, 0x455A64.ToColor() },
                                    {ColorDepth.C800, 0x37474F.ToColor() },
                                    {ColorDepth.C900, 0x263238.ToColor() }
                                }.ToReadOnly()
                            }
                            #endregion
                        };

            _table = new ReadOnlyDictionary<MaterialColor, IReadOnlyDictionary<ColorDepth, Color>>(table);
        }

        #endregion

        #region Public methods

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

        public static Color BlueGray(ColorDepth depth = ColorDepth.Default)
        {
            return GetColorImpl(MaterialColor.BlueGray, depth);
        }

        #endregion

        #region Private methods

        private static Color GetColorImpl(MaterialColor color, ColorDepth depth)
        {
            if (!_table.ContainsKey(color))
                return Default;

            var colorRange = _table[color];

            return colorRange.ContainsKey(depth)
                       ? colorRange[depth]
                       : colorRange[ColorDepth.Default];
        }

        #endregion
    }
}
