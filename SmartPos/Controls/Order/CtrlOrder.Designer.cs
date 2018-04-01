namespace SmartPos.Desktop.Controls.Order
{
    partial class CtrlOrder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOrder = new SmartPos.Ui.Controls.SpPanel();
            this.lvItems = new SmartPos.Ui.Controls.SpListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlOrderActions = new SmartPos.Ui.Controls.SpPanel();
            this.pnlInfo = new SmartPos.Ui.Controls.SpPanel();
            this.lblItems = new SmartPos.Ui.Controls.SpLabel();
            this.lblTotal = new SmartPos.Ui.Controls.SpLabel();
            this.btnProfoma = new SmartPos.Ui.Controls.SpButton();
            this.btnInvoice = new SmartPos.Ui.Controls.SpButton();
            this.btnPay = new SmartPos.Ui.Controls.SpButton();
            this.btnEdit = new SmartPos.Ui.Controls.SpButton();
            this.btnRemove = new SmartPos.Ui.Controls.SpButton();
            this.btnMinus = new SmartPos.Ui.Controls.SpButton();
            this.btnPlus = new SmartPos.Ui.Controls.SpButton();
            this.ctrlMenu = new SmartPos.Desktop.Controls.Menu.CtrlMenu();
            this.pnlOrder.SuspendLayout();
            this.pnlOrderActions.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.lvItems);
            this.pnlOrder.Controls.Add(this.pnlOrderActions);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(939, 418);
            this.pnlOrder.TabIndex = 0;
            // 
            // lvItems
            // 
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chQuantity,
            this.chPrice});
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItems.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(0, 0);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(713, 418);
            this.lvItems.TabIndex = 1;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Produs";
            this.chName.Width = 408;
            // 
            // chQuantity
            // 
            this.chQuantity.Text = "Cantitate";
            this.chQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chQuantity.Width = 152;
            // 
            // chPrice
            // 
            this.chPrice.Text = "Pret";
            this.chPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chPrice.Width = 140;
            // 
            // pnlOrderActions
            // 
            this.pnlOrderActions.Controls.Add(this.pnlInfo);
            this.pnlOrderActions.Controls.Add(this.btnProfoma);
            this.pnlOrderActions.Controls.Add(this.btnInvoice);
            this.pnlOrderActions.Controls.Add(this.btnPay);
            this.pnlOrderActions.Controls.Add(this.btnEdit);
            this.pnlOrderActions.Controls.Add(this.btnRemove);
            this.pnlOrderActions.Controls.Add(this.btnMinus);
            this.pnlOrderActions.Controls.Add(this.btnPlus);
            this.pnlOrderActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOrderActions.Location = new System.Drawing.Point(713, 0);
            this.pnlOrderActions.Name = "pnlOrderActions";
            this.pnlOrderActions.Size = new System.Drawing.Size(226, 418);
            this.pnlOrderActions.TabIndex = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblItems);
            this.pnlInfo.Controls.Add(this.lblTotal);
            this.pnlInfo.Location = new System.Drawing.Point(3, 4);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(218, 137);
            this.pnlInfo.TabIndex = 8;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(4, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(100, 28);
            this.lblItems.TabIndex = 8;
            this.lblItems.Text = "2 produse";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(2, 97);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(205, 38);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total : 50.00 LEI";
            // 
            // btnProfoma
            // 
            this.btnProfoma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfoma.Location = new System.Drawing.Point(114, 355);
            this.btnProfoma.Name = "btnProfoma";
            this.btnProfoma.Size = new System.Drawing.Size(107, 55);
            this.btnProfoma.TabIndex = 6;
            this.btnProfoma.Text = "Nota info";
            this.btnProfoma.UseVisualStyleBackColor = true;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoice.Location = new System.Drawing.Point(3, 355);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(105, 55);
            this.btnInvoice.TabIndex = 5;
            this.btnInvoice.Text = "Factura";
            this.btnInvoice.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.Location = new System.Drawing.Point(3, 282);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(218, 67);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "Plateste";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(114, 214);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 61);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Spec";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(114, 147);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(107, 61);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Sterge";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.Location = new System.Drawing.Point(3, 214);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(105, 61);
            this.btnMinus.TabIndex = 1;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.Location = new System.Drawing.Point(3, 147);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(105, 61);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            // 
            // ctrlMenu
            // 
            this.ctrlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMenu.Location = new System.Drawing.Point(0, 418);
            this.ctrlMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlMenu.Name = "ctrlMenu";
            this.ctrlMenu.Size = new System.Drawing.Size(939, 196);
            this.ctrlMenu.TabIndex = 1;
            // 
            // CtrlOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.ctrlMenu);
            this.Name = "CtrlOrder";
            this.Size = new System.Drawing.Size(939, 614);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrderActions.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ui.Controls.SpPanel pnlOrder;
        private Menu.CtrlMenu ctrlMenu;
        private Ui.Controls.SpPanel pnlOrderActions;
        private Ui.Controls.SpButton btnPlus;
        private Ui.Controls.SpButton btnRemove;
        private Ui.Controls.SpButton btnMinus;
        private Ui.Controls.SpButton btnPay;
        private Ui.Controls.SpButton btnEdit;
        private Ui.Controls.SpButton btnProfoma;
        private Ui.Controls.SpButton btnInvoice;
        private Ui.Controls.SpListView lvItems;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.ColumnHeader chQuantity;
        private Ui.Controls.SpPanel pnlInfo;
        private Ui.Controls.SpLabel lblTotal;
        private Ui.Controls.SpLabel lblItems;
    }
}
