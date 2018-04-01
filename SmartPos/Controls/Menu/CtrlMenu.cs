using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

using SmartPos.Ui;
using SmartPos.Ui.Controls;
using SmartPos.Desktop.Data;
using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.GeneralLibrary.Interfaces;

namespace SmartPos.Desktop.Controls.Menu
{
    public partial class CtrlMenu : BaseControl
    {
        public CtrlMenu()
        {
            InitializeComponent();
        }

        public async Task LoadMenu()
        {
            try
            {
                flowTop.SuspendLayout();
                flowItems.SuspendLayout();

                lblPath.Text = "Menu > ";

                flowTop.Controls.Clear();
                flowItems.Controls.Clear();

                IEnumerable<MenuCategory> result;
                try
                {
                    result = await Application.Api(LoadingState).Menu.GetMenu();
                }
                catch (Exception mex)
                {
                    GlobalHandler.Catch(mex, ParentForm);
                    return;
                }

                var tree = result.ToTree(mc => mc.Id, mc => mc.ParentId);

                flowTop.Controls.AddRange(tree.Select(CreateMenuButon).Cast<Control>().ToArray());
            }
            finally
            {
                flowTop.ResumeLayout();
                flowItems.ResumeLayout();
            }
        }

        private SpButton CreateMenuButon(ITree<MenuCategory> arg)
        {
            var button = new SpButton
            {
                Text = arg.Value.Name,
                Tag = arg,
                Size = new Size(100, 21)
            };

            button.ApplyTheme(Theme);

            return button;
        }
    }
}
