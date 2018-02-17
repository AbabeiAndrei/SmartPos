using System;
using System.Windows.Forms;

namespace SmartPos.Ui
{
    public interface IFormBuilder
    {
        void Show(CloseFormResult result = null);
    }

    public interface IFormBuilder<out TControl> : IFormBuilder
        where TControl : BaseControl
    {
        IFormBuilder<TControl> OnConfirm(ConfirmFormHandler action);
        IFormBuilder<TControl> OnClose(CloseFormHandler action);
        IFormBuilder<TControl> Configure(Action<TControl> control);
    }

    public interface IFormBuilder<out TForm, out TControl> : IFormBuilder<TControl>
        where TForm : BaseForm
        where TControl : BaseControl
    {
        IFormBuilder<TForm, TControl> OnConfirm(ConfirmFormHandler action);
        IFormBuilder<TForm, TControl> OnClose(CloseFormHandler action);
        IFormBuilder<TForm, TControl> ConfigureForm(Action<TForm> form);
    }

    public class FormBuilder<TForm, TControl> : IFormBuilder<TForm, TControl>
        where TForm : BaseForm, new()
        where TControl : BaseControl
    {
        private readonly TControl _control;

        #region Fields

        private readonly TForm _form;
        private IWin32Window _parent;

        #endregion

        #region Constructors

        public FormBuilder(TControl control)
        {
            _control = control;
            if(control == null)
                throw new ArgumentNullException(nameof(control));

            _form = new TForm
                    {
                        Size = control.Size
                    };

            AddControl(control);
        }

        public FormBuilder(TForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            _form = form;
        }

        #endregion

        #region Implementation of IFormBuilder<> 

        public IFormBuilder<TControl> OnConfirm(ConfirmFormHandler action)
        {
            _form.OnConfirm += action;

            return this;
        }

        public IFormBuilder<TControl> OnClose(CloseFormHandler action)
        {
            _form.OnClose += action;

            return this;
        }

        IFormBuilder<TForm, TControl> IFormBuilder<TForm, TControl>.OnClose(CloseFormHandler action)
        {
            _form.OnClose += action;

            return this;
        }

        IFormBuilder<TForm, TControl> IFormBuilder<TForm, TControl>.OnConfirm(ConfirmFormHandler action)
        {
            _form.OnConfirm += action;

            return this;
        }

        public IFormBuilder<TControl> Configure(Action<TControl> control)
        {
            control(_control);

            return this;
        }

        public IFormBuilder<TForm, TControl> ConfigureForm(Action<TForm> form)
        {
            form(_form);

            return this;
        }

        public void Show(CloseFormResult result = null)
        {
            if (result != null)
            {
                var dresult = _form.ShowDialog(_parent);
                result(dresult);
            }
            else
                _form.Show(_parent);
        }

        #endregion

        #region Private methods

        private void AddControl(Control control)
        {
            control.Dock = DockStyle.Fill;
            _form.Controls.Add(control);
        }

        #endregion

        #region Public methods

        public void SetTitle(string title)
        {
            _form.Text = title;
        }

        public void SetParent(IWin32Window parent)
        {
            _parent = parent;
        }

        #endregion
    }

    public class FormBuilder : FormBuilder<BaseForm, BaseControl>, IFormBuilder
    {
        #region Constructors

        public FormBuilder(BaseControl control)
            : base(control)
        {
        }

        public FormBuilder(BaseForm form)
            : base(form)
        {
        }

        #endregion
    }
}
