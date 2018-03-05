using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace SmartPos.Desktop.Utils
{
    public static class GfxHelper
    {
        #region Fields

        private static readonly IDictionary<StringAlignment, IDictionary<StringAlignment, StringFormat>> _stringFormatTable;

        #endregion

        #region Constructors

        static GfxHelper()
        {
            _stringFormatTable = new Dictionary<StringAlignment, IDictionary<StringAlignment, StringFormat>>();
        }

        #endregion

        #region Public methods

        public static StringFormat CreateStringFormat(StringAlignment align, StringAlignment lineAlign = StringAlignment.Near)
        {
            if (_stringFormatTable.ContainsKey(align))
            {
                var location = _stringFormatTable[align];

                if (!location.ContainsKey(lineAlign))
                    location.Add(lineAlign, new StringFormat
                    {
                        Alignment = align,
                        LineAlignment = lineAlign
                    });

                return location[lineAlign];
            }

            _stringFormatTable.Add(align, new Dictionary<StringAlignment, StringFormat>
            {
                {
                    lineAlign,
                    new StringFormat
                    {
                        Alignment = align,
                        LineAlignment = lineAlign
                    }
                }
            });

            return _stringFormatTable[align][lineAlign];
        }
        
        public static void ApplyDisplaySettings(Graphics gfx)
        {
            gfx.CompositingMode = CompositingMode.SourceOver;
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        #endregion
    }
}
