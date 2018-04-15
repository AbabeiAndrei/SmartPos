using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using SmartPos.Ui;
using SmartPos.Ui.Utils;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Controls;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Handlers;
using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.GeneralLibrary.Interfaces;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop.Controls.Menu
{
    [DefaultEvent(nameof(ProductClick))]
    public partial class CtrlMenu : BaseControl
    {
        #region Events

        [Category("Action")]
        public event ProductItemHandler ProductClick;

        #endregion

        #region Constructors

        public CtrlMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        public async Task LoadMenu()
        {
            try
            {
                flowTop.SuspendLayout();
                flowItems.SuspendLayout();

                lblPath.Text = "/";

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
        

        #endregion

        #region Protected methods

        protected virtual async Task OnProductClickAsync(IProductItemArgs args)
        {
            if(ProductClick != null)
                await ProductClick(this, args);
        }

        #endregion

        #region Event handlers

        private void MainCategoryClick(object sender, EventArgs e)
        {
            if(!(sender is SpButton button))
                return;

            flowTop.Controls.OfType<SpButton>().ForEach(btn => btn.Selected = false);
            
            button.Selected = true;

            if (!(button.Tag is ITree<MenuCategory> category))
            {
                ParentForm.ShowMessage("Categorie invalida. Redeschideti masa", MessageType.Error);
                return;
            }

            ShowCategory(category);
        }

        private void SubMenuCategoryClick(object sender, EventArgs e)
        {
            if(!(sender is SpButton button))
                return;

            if (!(button.Tag is ITree<MenuCategory> category))
            {
                ParentForm.ShowMessage("Categorie invalida. Redeschideti masa", MessageType.Error);
                return;
            }

            ShowCategory(category);
        }

        private async void ProductMenuClick(object sender, EventArgs e)
        {
            if(!(sender is SpButton button))
                return;

            if (!(button.Tag is Product product))
            {
                ParentForm.ShowMessage("Produs invalid. Redeschideti masa", MessageType.Error);
                return;
            }

            await AddProductInOrder(product);
        }

        #endregion

        #region Private methods

        private void ShowCategory(ITree<MenuCategory> category)
        {
            try
            {
                flowItems.SuspendLayout();
                
                flowItems.Controls.RemoveAll();

                flowItems.Controls.AddRange(category.Childrens.Select(CreateSubMenuItem).Cast<Control>().ToArray());
                flowItems.Controls.AddRange(category.Value.Products.Select(CreateProductButton).Cast<Control>().ToArray());

                lblPath.Text = string.Join("/", category.Path.Select(mc => mc.Name));
            }
            finally
            {
                flowItems.ResumeLayout();
            }
        }

        private SpButton CreateMenuButon(ITree<MenuCategory> arg)
        {
            var button = new SpButton
                         {
                                 Text = arg.Value.Name,
                                 Tag = arg,
                                 Size = new Size(100, flowTop.Height - 5),
                                 Selectable = true
                         };

            button.ApplyTheme(Theme);

            button.Click += MainCategoryClick;

            return button;
        }

        private SpButton CreateSubMenuItem(ITree<MenuCategory> arg)
        {
            var button = new SpButton
            {
                Text = arg.Value.Name,
                Tag = arg,
                Size = new Size(100, 45),
                Font = new Font(Font.FontFamily, 10f)
            };

            button.ApplyTheme(Theme);

            button.Click += SubMenuCategoryClick;

            return button;
        }

        private SpButton CreateProductButton(Product arg)
        {
            var button = new SpButton
            {
                Text = arg.Name,
                Tag = arg,
                Size = new Size(100, 45),
                Font = new Font(Font.FontFamily, 10f)
            };

            button.ApplyTheme(Theme);
            button.BackColor = MaterialColors.BlueGray();

            button.Click += ProductMenuClick;

            return button;
        }

        private async Task AddProductInOrder(Product product)
        {
            await OnProductClickAsync(new ProductItemArgs(product));
        }

        #endregion
    }
}
