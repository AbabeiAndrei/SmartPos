using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Desktop.Controls.Order;
using SmartPos.DomainModel.Entities;
using SmartPos.Ui;
using SmartPos.Ui.Handlers;

namespace SmartPos.Desktop.Utils
{
    public static class UiHelper
    {
        public static IFormBuilder<TControl> ShowForm<TControl>(string title = null, IWin32Window parent = null)
            where TControl : BaseControl, new()
        {
            return ShowForm(new TControl(), title, parent);
        }

        public static IFormBuilder<TControl> ShowForm<TControl>(TControl control, 
                                                      string title = null, 
                                                      IWin32Window parent = null)
            where TControl : BaseControl
        {
            var formBuilder = new FormBuilder<BaseForm, TControl>(control);

            if (string.IsNullOrEmpty(title))
                title = Application.ProductName;

            formBuilder.SetTitle(title);
            formBuilder.SetParent(parent);

            return formBuilder;
        }

        public static IFormBuilder<TForm, TControl> ShowForm<TControl, TForm>(string title = null, 
                                                                    IWin32Window parent = null)
            where TControl : BaseControl, new()
            where TForm : BaseForm, new()
        {
            return ShowForm<TControl, TForm>(new TControl(), title, parent);
        }

        public static IFormBuilder<TForm, TControl> ShowForm<TControl, TForm>(TControl control,
                                                                    string title = null, 
                                                                    IWin32Window parent = null)
            where TControl : BaseControl
            where TForm : BaseForm, new()
        {
            var formBuilder = new FormBuilder<TForm, TControl>(control);

            if (string.IsNullOrEmpty(title))
                title = Application.ProductName;

            formBuilder.SetTitle(title);
            formBuilder.SetParent(parent);

            return formBuilder;
        }

        public static void ShowOrder(Order order)
        {
            var orderControl = new CtrlOrder(order);

            ShowControlInFormContainer(orderControl);
        }

        public static TControl ShowControlInFormContainer<TControl>(TControl control, MainForm form = null)
            where TControl : BaseControl
        {
            form = form ?? (MainForm)Application.MainForm;
            
            form.SetControlInContainer(control);
            
            return control;
        }

        public static void ShowTablesInMainForm(MainForm form = null)
        {
            form = form ?? (MainForm)Application.MainForm;


            form.ShowTablesInContainer();
        }

        public static string CreateTitle(string baseTitle)
        {
            return $"{Application.ProductName} - {baseTitle}";
        }

        public static void RunOnUiThread(this Control control, UiInvokeRequiredHandler action)
        {
            if(control == null)
                throw new ArgumentNullException(nameof(control));

            if(!control.InvokeRequired)
                return;

            if(action == null)
                throw new ArgumentNullException(nameof(action));

            control.Invoke(action);
        }
    }
}
