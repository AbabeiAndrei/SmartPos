namespace SmartPos.Desktop.Controls.Menu
{
    partial class CtrlMenu
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
            this.lblPath = new SmartPos.Ui.Controls.SpLabel();
            this.flowTop = new SmartPos.Ui.Controls.SpFlowPanel();
            this.flowItems = new SmartPos.Ui.Controls.SpFlowPanel();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPath.Location = new System.Drawing.Point(0, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(861, 28);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Menu > ";
            // 
            // flowTop
            // 
            this.flowTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTop.Location = new System.Drawing.Point(0, 28);
            this.flowTop.Name = "flowTop";
            this.flowTop.Size = new System.Drawing.Size(861, 65);
            this.flowTop.TabIndex = 1;
            // 
            // flowItems
            // 
            this.flowItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowItems.Location = new System.Drawing.Point(0, 93);
            this.flowItems.Name = "flowItems";
            this.flowItems.Size = new System.Drawing.Size(861, 190);
            this.flowItems.TabIndex = 2;
            // 
            // CtrlMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowItems);
            this.Controls.Add(this.flowTop);
            this.Controls.Add(this.lblPath);
            this.Name = "CtrlMenu";
            this.Size = new System.Drawing.Size(861, 283);
            this.ResumeLayout(false);

        }

        #endregion

        private Ui.Controls.SpLabel lblPath;
        private Ui.Controls.SpFlowPanel flowTop;
        private Ui.Controls.SpFlowPanel flowItems;
    }
}
