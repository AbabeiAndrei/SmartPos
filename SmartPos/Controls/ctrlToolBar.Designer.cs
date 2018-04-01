namespace SmartPos.Desktop.Controls
{
    partial class CtrlToolBar
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
            this.pnlContainer = new SmartPos.Ui.Controls.SpPanel();
            this.pnlLogout = new SmartPos.Ui.Controls.SpPanel();
            this.pnlOptions = new SmartPos.Ui.Controls.SpPanel();
            this.flowLeft = new SmartPos.Ui.Controls.SpFlowPanel();
            this.flowRight = new SmartPos.Ui.Controls.SpFlowPanel();
            this.pnlContainer.SuspendLayout();
            this.pnlLogout.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Location = new System.Drawing.Point(5, 3);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 44);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.BackgroundImage = global::SmartPos.Desktop.Properties.Resources.gear;
            this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOptions.Location = new System.Drawing.Point(8, 6);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(40, 39);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.Text = "\r\n";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.flowRight);
            this.pnlContainer.Controls.Add(this.flowLeft);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(119, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1049, 49);
            this.pnlContainer.TabIndex = 2;
            // 
            // pnlLogout
            // 
            this.pnlLogout.AutoSize = true;
            this.pnlLogout.Controls.Add(this.btnLogout);
            this.pnlLogout.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogout.Location = new System.Drawing.Point(0, 0);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(119, 49);
            this.pnlLogout.TabIndex = 3;
            // 
            // pnlOptions
            // 
            this.pnlOptions.AutoSize = true;
            this.pnlOptions.Controls.Add(this.btnOptions);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOptions.Location = new System.Drawing.Point(1168, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(52, 49);
            this.pnlOptions.TabIndex = 4;
            // 
            // flowLeft
            // 
            this.flowLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLeft.Name = "flowLeft";
            this.flowLeft.Size = new System.Drawing.Size(543, 49);
            this.flowLeft.TabIndex = 0;
            // 
            // flowRight
            // 
            this.flowRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowRight.Location = new System.Drawing.Point(543, 0);
            this.flowRight.Name = "flowRight";
            this.flowRight.Size = new System.Drawing.Size(506, 49);
            this.flowRight.TabIndex = 1;
            // 
            // CtrlToolBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlLogout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CtrlToolBar";
            this.Size = new System.Drawing.Size(1220, 49);
            this.pnlContainer.ResumeLayout(false);
            this.pnlLogout.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ui.Controls.SpButton btnLogout;
        private Ui.Controls.SpButton btnOptions;
        private Ui.Controls.SpPanel pnlContainer;
        private Ui.Controls.SpPanel pnlLogout;
        private Ui.Controls.SpPanel pnlOptions;
        private Ui.Controls.SpFlowPanel flowRight;
        private Ui.Controls.SpFlowPanel flowLeft;
    }
}
