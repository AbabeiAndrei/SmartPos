using System;
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
        private static readonly IDictionary<int, Brush> _brushTable;
        private static readonly IDictionary<Tuple<int, float>, Pen> _penTable;

        #endregion

        #region Constructors

        static GfxHelper()
        {
            _stringFormatTable = new Dictionary<StringAlignment, IDictionary<StringAlignment, StringFormat>>();
            _brushTable = new Dictionary<int, Brush>();
            _penTable = new Dictionary<Tuple<int, float>, Pen>();
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

        public static Brush AsBrush(this Color color, bool fromCache = true)
        {
            if(!fromCache)
                return new SolidBrush(color);

            var argb = color.ToArgb();

            if (!_brushTable.ContainsKey(argb))
                _brushTable.Add(argb, new SolidBrush(color));

            return _brushTable[argb];
        }

        public static Pen AsPen(this Color color, float width = 1f, bool fromCache = true)
        {
            if(!fromCache)
                return new Pen(color, width);
            
            var tuple = new Tuple<int, float>(color.ToArgb(), width);

            if (!_penTable.ContainsKey(tuple))
                _penTable.Add(tuple, new Pen(color, width));

            return _penTable[tuple];
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
