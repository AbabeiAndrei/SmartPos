namespace SmartPos.Desktop.Controls.Form
{
    partial class ConfirmationForm
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
            this.pnlContent = new SmartPos.Ui.Controls.SpPanel();
            this.pnlActions = new SmartPos.Ui.Controls.SpPanel();
            this.btnNo = new SmartPos.Ui.Controls.Specific.SpCancelButton();
            this.btnYes = new SmartPos.Ui.Controls.Specific.SpConfirmButton();
            this.lblText = new SmartPos.Ui.Controls.SpLabel();
            this.lblMessageTitle = new SmartPos.Ui.Controls.SpLabel();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlActions);
            this.pnlContent.Controls.Add(this.lblText);
            this.pnlContent.Controls.Add(this.lblMessageTitle);
            this.pnlContent.Location = new System.Drawing.Point(0, 125);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 150);
            this.pnlContent.TabIndex = 4;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnNo);
            this.pnlActions.Controls.Add(this.btnYes);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 91);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(800, 59);
            this.pnlActions.TabIndex = 2;
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(687, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.SelectedBackColor = System.Drawing.Color.Empty;
            this.btnNo.SelectedForeColor = System.Drawing.Color.Empty;
            this.btnNo.Size = new System.Drawing.Size(110, 53);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "Nu";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(571, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.SelectedBackColor = System.Drawing.Color.Empty;
            this.btnYes.SelectedForeColor = System.Drawing.Color.Empty;
            this.btnYes.Size = new System.Drawing.Size(110, 53);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Da";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 58);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(80, 21);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Question?";
            // 
            // lblMessageTitle
            // 
            this.lblMessageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessageTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMessageTitle.Name = "lblMessageTitle";
            this.lblMessageTitle.Size = new System.Drawing.Size(800, 42);
            this.lblMessageTitle.TabIndex = 0;
            this.lblMessageTitle.Text = "Question";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.pnlContent);
            this.Name = "ConfirmationForm";
            this.Text = "ConfirmationForm";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Ui.Controls.SpPanel pnlContent;
        private Ui.Controls.SpLabel lblMessageTitle;
        private Ui.Controls.SpPanel pnlActions;
        private Ui.Controls.Specific.SpCancelButton  btnNo;
        private Ui.Controls.Specific.SpConfirmButton btnYes;
        private Ui.Controls.SpLabel lblText;
    }
}