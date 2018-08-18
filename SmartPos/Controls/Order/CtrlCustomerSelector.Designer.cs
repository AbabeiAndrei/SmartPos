namespace SmartPos.Desktop.Controls.Order
{
    partial class CtrlCustomerSelector
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
            this.txtClient = new SmartPos.Ui.Controls.SpTextbox();
            this.lblClient = new SmartPos.Ui.Controls.SpLabel();
            this.btnSearch = new SmartPos.Ui.Controls.SpButton();
            this.lblAddress = new SmartPos.Ui.Controls.SpLabel();
            this.txtAddress = new SmartPos.Ui.Controls.SpTextbox();
            this.btnOk = new SmartPos.Ui.Controls.Specific.SpConfirmButton();
            this.btnCancel = new SmartPos.Ui.Controls.Specific.SpCancelButton();
            this.SuspendLayout();
            // 
            // txtClient
            // 
            this.txtClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClient.ClearButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.EnableBackspace = true;
            this.txtClient.Location = new System.Drawing.Point(7, 37);
            this.txtClient.Name = "txtClient";
            this.txtClient.Placeholder = null;
            this.txtClient.ShowClear = true;
            this.txtClient.Size = new System.Drawing.Size(334, 29);
            this.txtClient.TabIndex = 0;
            this.txtClient.ClearButtonPressed += new System.ComponentModel.HandledEventHandler(this.txtClient_ClearButtonPressed);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(3, 13);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(50, 21);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(348, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.SelectedBackColor = System.Drawing.Color.Empty;
            this.btnSearch.SelectedForeColor = System.Drawing.Color.Empty;
            this.btnSearch.Size = new System.Drawing.Size(73, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Cauta";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 74);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 21);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Date";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.ClearButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.EnableBackspace = true;
            this.txtAddress.Location = new System.Drawing.Point(7, 98);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Placeholder = null;
            this.txtAddress.Size = new System.Drawing.Size(414, 133);
            this.txtAddress.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(321, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.SelectedBackColor = System.Drawing.Color.Empty;
            this.btnOk.SelectedForeColor = System.Drawing.Color.Empty;
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(7, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SelectedBackColor = System.Drawing.Color.Empty;
            this.btnCancel.SelectedForeColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuleaza";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CtrlCustomerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.txtClient);
            this.Name = "CtrlCustomerSelector";
            this.Size = new System.Drawing.Size(424, 283);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ui.Controls.SpTextbox txtClient;
        private Ui.Controls.SpLabel lblClient;
        private Ui.Controls.SpButton btnSearch;
        private Ui.Controls.SpLabel lblAddress;
        private Ui.Controls.SpTextbox txtAddress;
        private Ui.Controls.Specific.SpConfirmButton btnOk;
        private Ui.Controls.Specific.SpCancelButton btnCancel;
    }
}
