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
            this.ctrlToolBar = new SmartPos.Desktop.Controls.CtrlToolBar();
            this.ctrlStatusBar = new SmartPos.Desktop.Controls.CtrlStatusBar();
            this.SuspendLayout();
            // 
            // ctrlToolBar
            // 
            this.ctrlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlToolBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlToolBar.Location = new System.Drawing.Point(0, 650);
            this.ctrlToolBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlToolBar.Name = "ctrlToolBar";
            this.ctrlToolBar.Size = new System.Drawing.Size(1166, 49);
            this.ctrlToolBar.TabIndex = 0;
            // 
            // ctrlStatusBar
            // 
            this.ctrlStatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlStatusBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStatusBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlStatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStatusBar.Name = "ctrlStatusBar";
            this.ctrlStatusBar.Size = new System.Drawing.Size(1166, 31);
            this.ctrlStatusBar.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 699);
            this.Controls.Add(this.ctrlStatusBar);
            this.Controls.Add(this.ctrlToolBar);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartPos";
            this.Controls.SetChildIndex(this.ctrlToolBar, 0);
            this.Controls.SetChildIndex(this.ctrlStatusBar, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlToolBar ctrlToolBar;
        private CtrlStatusBar ctrlStatusBar;
    }
}

