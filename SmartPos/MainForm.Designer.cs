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
            this.SuspendLayout();
            // 
            // ctrlToolBar
            // 
            this.ctrlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlToolBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlToolBar.Location = new System.Drawing.Point(0, 690);
            this.ctrlToolBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlToolBar.Name = "ctrlToolBar";
            this.ctrlToolBar.Size = new System.Drawing.Size(1166, 49);
            this.ctrlToolBar.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 739);
            this.Controls.Add(this.ctrlToolBar);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartPos";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlToolBar ctrlToolBar;
    }
}

