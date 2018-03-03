namespace SmartPos.Ui
{
    partial class BaseForm
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
                DisposeComponents();
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
            this.components = new System.ComponentModel.Container();
            this.tmrAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTitle = new SmartPos.Ui.Controls.SpLabel();
            this.lblMessage = new SmartPos.Ui.Controls.SpLabel();
            this.tmrLoader = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrAnimationTimer
            // 
            this.tmrAnimationTimer.Interval = 10;
            this.tmrAnimationTimer.Tick += new System.EventHandler(this.tmrAnimationTimer_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Visible = false;
            this.lblTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoading_Paint);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Location = new System.Drawing.Point(0, 40);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(382, 0);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Click += new System.EventHandler(this.lblErrors_Click);
            this.lblMessage.MouseEnter += new System.EventHandler(this.lblErrors_MouseEnter);
            this.lblMessage.MouseLeave += new System.EventHandler(this.lblErrors_MouseLeave);
            // 
            // tmrLoader
            // 
            this.tmrLoader.Tick += new System.EventHandler(this.tmrLoader_Tick);
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoading_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrAnimationTimer;
        private Controls.SpLabel lblTitle;
        private Controls.SpLabel lblMessage;
        private System.Windows.Forms.Timer tmrLoader;
    }
}