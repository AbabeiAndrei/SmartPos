using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Security;
using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class BaseControlWrapper : BaseControl
    {
        #region Fields

        private readonly Control _control;

        #endregion

        #region Constructor

        public BaseControlWrapper(Control control)
        {
            _control = control;
        }

        #endregion

        #region Overrides

        public override bool AutoSize
        {
            get => _control?.AutoSize ?? base.AutoSize;
            set
            {
                if (_control != null)
                    _control.AutoSize = value;
                else
                    base.AutoSize = value;
            }
        }

        public override string Text
        {
            get => _control?.Text ?? base.Text;
            set
            {
                if (_control != null)
                    _control.Text = value;
                else
                    base.Text = value;
            }
        }

        public override Rectangle DisplayRectangle => _control?.DisplayRectangle ?? base.DisplayRectangle;

        public override void ResetBackColor()
        {
            if (_control != null)
                _control.ResetBackColor();
            else
                base.ResetBackColor();
        }

        public override void ResetCursor()
        {
            if (_control != null)
                _control.ResetCursor();
            else
                base.ResetCursor();
        }

        public override void ResetFont()
        {
            if (_control != null)
                _control.ResetFont();
            else
                base.ResetFont();
        }

        public override void ResetForeColor()
        {
            if (_control != null)
                _control.ResetForeColor();
            else
                base.ResetForeColor();
        }

        public override void ResetRightToLeft()
        {
            if (_control != null)
                _control.ResetRightToLeft();
            else
                base.ResetRightToLeft();
        }

        public override void Refresh()
        {
            if (_control != null)
                _control.Refresh();
            else
                base.Refresh();
        }

        public override void ResetText()
        {
            if (_control != null)
                _control.ResetText();
            else
                base.ResetText();
        }

        public override bool AllowDrop
        {
            get => _control?.AllowDrop ?? base.AllowDrop;
            set
            {
                if (_control != null)
                    _control.AllowDrop = value;
                else
                    base.AllowDrop = value;
            }
        }

        public override AnchorStyles Anchor
        {
            get => _control?.Anchor ?? base.Anchor;
            set
            {
                if (_control != null)
                    _control.Anchor = value;
                else
                    base.Anchor = value;
            }
        }

        public override Point AutoScrollOffset
        {
            get => _control?.AutoScrollOffset ?? base.AutoScrollOffset;
            set
            {
                if (_control != null)
                    _control.AutoScrollOffset = value;
                else
                    base.AutoScrollOffset = value;
            }
        }

        public override LayoutEngine LayoutEngine => _control?.LayoutEngine ?? base.LayoutEngine;

        public override Color BackColor
        {
            get => _control?.BackColor ?? base.BackColor;
            set
            {
                if (_control != null)
                    _control.BackColor = value;
                else
                    base.BackColor = value;
            }
        }

        public override Image BackgroundImage
        {
            get => _control != null 
                        ? _control.BackgroundImage 
                        : base.BackgroundImage;
            set
            {
                if (_control != null)
                    _control.BackgroundImage = value;
                else
                    base.BackgroundImage = value;
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get => _control?.BackgroundImageLayout ?? base.BackgroundImageLayout;
            set
            {
                if (_control != null)
                    _control.BackgroundImageLayout = value;
                else
                    base.BackgroundImageLayout = value;
            }
        }

        public override ContextMenu ContextMenu
        {
            get => _control != null 
                        ? _control?.ContextMenu 
                        : base.ContextMenu;
            set
            {
                if (_control != null)
                    _control.ContextMenu = value;
                else
                    base.ContextMenu = value;
            }
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get => _control != null 
                        ? _control.ContextMenuStrip 
                        : base.ContextMenuStrip;
            set
            {
                if (_control != null)
                    _control.ContextMenuStrip = value;
                else
                    base.ContextMenuStrip = value;
            }
        }

        public override Cursor Cursor
        {
            get => _control != null 
                       ? _control.Cursor
                       : base.Cursor;
            set
            {
                if (_control != null)
                    _control.Cursor = value;
                else
                    base.Cursor = value;
            }
        }
        
        public override DockStyle Dock
        {
            get => _control?.Dock ?? base.Dock;
            set
            {
                if (_control != null)
                    _control.Dock = value;
                else
                    base.Dock = value;
            }
        }

        public override bool Focused => _control?.Focused ?? base.Focused;

        public override Font Font
        {
            get => _control != null 
                       ? _control.Font
                       : base.Font;
            set
            {
                if (_control != null)
                    _control.Font = value;
                else
                    base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get => _control?.ForeColor ?? base.ForeColor;
            set
            {
                if (_control != null)
                    _control.ForeColor = value;
                else
                    base.ForeColor = value;
            }
        }

        public override Size MaximumSize
        {
            get => _control?.MaximumSize ?? base.MaximumSize;
            set
            {
                if (_control != null)
                    _control.MaximumSize = value;
                else
                    base.MaximumSize = value;
            }
        }

        public override Size MinimumSize
        {
            get => _control?.MinimumSize ?? base.MinimumSize;
            set
            {
                if (_control != null)
                    _control.MinimumSize = value;
                else
                    base.MinimumSize = value;
            }
        }

        public override ISite Site
        {
            get => _control != null 
                        ? _control.Site 
                        : base.Site;
            set
            {
                if (_control != null)
                    _control.Site = value;
                else
                    base.Site = value;
            }
        }

        public override string ToString()
        {
            return _control?.ToString() ?? base.ToString();
        }

        public override object InitializeLifetimeService()
        {
            return _control != null 
                       ? _control.InitializeLifetimeService() 
                       : base.InitializeLifetimeService();
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return _control?.CreateObjRef(requestedType) ?? base.CreateObjRef(requestedType);
        }

        public override bool Equals(object obj)
        {
            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            return _control?.Equals(obj) ?? base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return _control?.GetHashCode() ?? base.GetHashCode();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                _control?.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion
    }
}
