namespace SmartPos.Desktop.Controls
{
    partial class ctrlToolBar
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
            this.btnLogout = new SmartPos.Ui.Controls.SpButton();
            this.btnOptions = new SmartPos.Ui.Controls.SpButton();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Location = new System.Drawing.Point(4, 5);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.BackgroundImage = global::SmartPos.Desktop.Properties.Resources.gear;
            this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOptions.Location = new System.Drawing.Point(1176, 6);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(40, 39);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.Text = "\r\n";
            this.btnOptions.UseVisualStyleBackColor = true;
            // 
            // ctrlToolBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlToolBar";
            this.Size = new System.Drawing.Size(1220, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private Ui.Controls.SpButton btnLogout;
        private Ui.Controls.SpButton btnOptions;
    }
}
