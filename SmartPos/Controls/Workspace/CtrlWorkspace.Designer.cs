namespace SmartPos.Desktop.Controls.Workspace
{
    partial class CtrlWorkspace
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
            this.pnlZones = new SmartPos.Ui.Controls.SpFlowPanel();
            this.pnlTables = new SmartPos.Ui.Controls.SpPanel();
            this.SuspendLayout();
            // 
            // pnlZones
            // 
            this.pnlZones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlZones.Location = new System.Drawing.Point(0, 0);
            this.pnlZones.Name = "pnlZones";
            this.pnlZones.Size = new System.Drawing.Size(802, 73);
            this.pnlZones.TabIndex = 0;
            // 
            // pnlTables
            // 
            this.pnlTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTables.Location = new System.Drawing.Point(0, 73);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(802, 385);
            this.pnlTables.TabIndex = 1;
            // 
            // CtrlWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTables);
            this.Controls.Add(this.pnlZones);
            this.Name = "CtrlWorkspace";
            this.Size = new System.Drawing.Size(802, 458);
            this.ResumeLayout(false);

        }

        #endregion

        private Ui.Controls.SpFlowPanel pnlZones;
        private Ui.Controls.SpPanel pnlTables;
    }
}
