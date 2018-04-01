using SmartPos.Desktop.Controls;

namespace SmartPos.Desktop
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlStatusBar = new SmartPos.Desktop.Controls.CtrlStatusBar();
            this.ctrlToolBar = new SmartPos.Desktop.Controls.CtrlToolBar();
            this.ctrlWorkspace = new SmartPos.Desktop.Controls.Workspace.CtrlWorkspace();
            this.pnlMain = new SmartPos.Ui.Controls.SpPanel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlStatusBar
            // 
            this.ctrlStatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlStatusBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStatusBar.Location = new System.Drawing.Point(0, 49);
            this.ctrlStatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStatusBar.Name = "ctrlStatusBar";
            this.ctrlStatusBar.Size = new System.Drawing.Size(1166, 31);
            this.ctrlStatusBar.TabIndex = 0;
            // 
            // ctrlToolBar
            // 
            this.ctrlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlToolBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlToolBar.Location = new System.Drawing.Point(0, 610);
            this.ctrlToolBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlToolBar.Name = "ctrlToolBar";
            this.ctrlToolBar.Size = new System.Drawing.Size(1166, 49);
            this.ctrlToolBar.TabIndex = 0;
            // 
            // ctrlWorkspace
            // 
            this.ctrlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkspace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlWorkspace.Location = new System.Drawing.Point(0, 0);
            this.ctrlWorkspace.Name = "ctrlWorkspace";
            this.ctrlWorkspace.Size = new System.Drawing.Size(1166, 530);
            this.ctrlWorkspace.TabIndex = 3;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ctrlWorkspace);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1166, 530);
            this.pnlMain.TabIndex = 4;
            this.pnlMain.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PnlMain_ControlsChanged);
            this.pnlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PnlMain_ControlsChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 659);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ctrlStatusBar);
            this.Controls.Add(this.ctrlToolBar);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartPos";
            this.Controls.SetChildIndex(this.ctrlToolBar, 0);
            this.Controls.SetChildIndex(this.ctrlStatusBar, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlToolBar ctrlToolBar;
        private CtrlStatusBar ctrlStatusBar;
        private Controls.Workspace.CtrlWorkspace ctrlWorkspace;
        private Ui.Controls.SpPanel pnlMain;
    }
}

