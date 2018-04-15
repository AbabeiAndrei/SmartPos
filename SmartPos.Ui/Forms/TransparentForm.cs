using System.Drawing;
using System.Windows.Forms;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Forms
{
    public class TransparentForm : BaseForm
    {
        #region Properties

        protected virtual Brush BackgroundBrush { get; set; }

        #endregion

        #region Overrides of BaseForm

        /// <inheritdoc />
        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            
            var color = Color.FromArgb(100, theme.FormTransparentBackColor);
            BackgroundBrush = new SolidBrush(color);
        }

        #endregion

        #region Overrides of ScrollableControl

        /// <inheritdoc />
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if(BackgroundBrush != null)
                e.Graphics.FillRectangle(BackgroundBrush, DisplayRectangle);
            else
                base.OnPaintBackground(e);
        }

        #endregion

        #region Overrides of BaseForm

        /// <inheritdoc />
        protected override void DisposeComponents()
        {
            base.DisposeComponents();
            BackgroundBrush?.Dispose();

        }

        #endregion
    }
}
