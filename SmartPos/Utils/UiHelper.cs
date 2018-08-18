using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmartPos.Desktop.Controls;
using SmartPos.Ui;
using SmartPos.Ui.Handlers;
using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Controls.Form;
using SmartPos.Desktop.Controls.Order;
using SmartPos.Ui.Components;

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

            orderControl.OrderSent += (sender, args) =>
            {
                if (Application.MainForm is MainForm form)
                {
                    form.PresentMessage("Comanda trimisa", MessageType.Info);
                    form.SetOrderToTable(args.Order);
                }

                return Task.CompletedTask;
            };

            ShowControlInFormContainer(orderControl);
        }

        public static TControl ShowControlInFormContainer<TControl>(TControl control, MainForm form = null)
            where TControl : BaseControl
        {
            form = form ?? (MainForm)Application.MainForm;
            
            form.SetControlInContainer(control);
            
            return control;
        }

        public static async Task ShowTablesInMainForm(MainForm form = null)
        {
            form = form ?? (MainForm)Application.MainForm;

            await form.ShowTablesInContainer();
        }
        
        public static DialogResult ShowConfirmation(string message,  MessageType type, string title = null, BaseForm parent = null)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            if (string.IsNullOrEmpty(title))
                title = "Intrebare";

            parent = parent ?? Application.MainForm;

            var form = new ConfirmationForm(message)
            {
                Location = parent.Location,
                Size = parent.Size,
                Title = title
            };

            form.ApplyTheme(Application.UiTheme);
            form.MessageType = type;

            return form.ShowDialog(parent);
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
