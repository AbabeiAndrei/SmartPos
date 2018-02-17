namespace SmartPos.Desktop.Controls
{
    partial class ctrlNumericKeyboard
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
            this.txtDisplay = new SmartPos.Ui.Controls.SpTextbox();
            this.btn1 = new SmartPos.Ui.Controls.SpButton();
            this.btn2 = new SmartPos.Ui.Controls.SpButton();
            this.btn3 = new SmartPos.Ui.Controls.SpButton();
            this.btn4 = new SmartPos.Ui.Controls.SpButton();
            this.btn5 = new SmartPos.Ui.Controls.SpButton();
            this.btn6 = new SmartPos.Ui.Controls.SpButton();
            this.btn9 = new SmartPos.Ui.Controls.SpButton();
            this.btn8 = new SmartPos.Ui.Controls.SpButton();
            this.btn7 = new SmartPos.Ui.Controls.SpButton();
            this.btn0 = new SmartPos.Ui.Controls.SpButton();
            this.btnDecimal = new SmartPos.Ui.Controls.SpButton();
            this.btnConfirm = new SmartPos.Ui.Controls.Specific.SpConfirmButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplay.ClearButtonFont = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.ClearButtonText = "<";
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI Semilight", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(3, 3);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Placeholder = "";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.ShowClear = true;
            this.txtDisplay.Size = new System.Drawing.Size(339, 70);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.ClearButtonPressed += new System.ComponentModel.HandledEventHandler(this.txtDisplay_ClearButtonPressed);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(3, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(107, 102);
            this.btn1.TabIndex = 1;
            this.btn1.Tag = "1";
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(116, 2);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(107, 102);
            this.btn2.TabIndex = 2;
            this.btn2.Tag = "2";
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(229, 3);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(107, 102);
            this.btn3.TabIndex = 3;
            this.btn3.Tag = "3";
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(3, 111);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(107, 102);
            this.btn4.TabIndex = 4;
            this.btn4.Tag = "4";
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(116, 110);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(107, 102);
            this.btn5.TabIndex = 5;
            this.btn5.Tag = "5";
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(229, 110);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(107, 102);
            this.btn6.TabIndex = 6;
            this.btn6.Tag = "6";
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(229, 219);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(107, 102);
            this.btn9.TabIndex = 9;
            this.btn9.Tag = "9";
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(116, 218);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(107, 102);
            this.btn8.TabIndex = 8;
            this.btn8.Tag = "8";
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(3, 219);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(107, 102);
            this.btn7.TabIndex = 7;
            this.btn7.Tag = "7";
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(3, 327);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(107, 102);
            this.btn0.TabIndex = 10;
            this.btn0.Tag = "0";
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btnDecimal
            // 
            this.btnDecimal.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecimal.Location = new System.Drawing.Point(116, 327);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(107, 102);
            this.btnDecimal.TabIndex = 11;
            this.btnDecimal.Tag = ".";
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = true;
            this.btnDecimal.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(229, 327);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(107, 102);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMain.Controls.Add(this.btnConfirm);
            this.pnlMain.Controls.Add(this.btnDecimal);
            this.pnlMain.Controls.Add(this.btn0);
            this.pnlMain.Controls.Add(this.btn9);
            this.pnlMain.Controls.Add(this.btn8);
            this.pnlMain.Controls.Add(this.btn7);
            this.pnlMain.Controls.Add(this.btn6);
            this.pnlMain.Controls.Add(this.btn5);
            this.pnlMain.Controls.Add(this.btn4);
            this.pnlMain.Controls.Add(this.btn3);
            this.pnlMain.Controls.Add(this.btn2);
            this.pnlMain.Controls.Add(this.btn1);
            this.pnlMain.Location = new System.Drawing.Point(3, 73);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(339, 434);
            this.pnlMain.TabIndex = 13;
            // 
            // ctrlNumericKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.txtDisplay);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "ctrlNumericKeyboard";
            this.Size = new System.Drawing.Size(345, 512);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ui.Controls.SpTextbox txtDisplay;
        private Ui.Controls.SpButton btn1;
        private Ui.Controls.SpButton btn2;
        private Ui.Controls.SpButton btn3;
        private Ui.Controls.SpButton btn4;
        private Ui.Controls.SpButton btn5;
        private Ui.Controls.SpButton btn6;
        private Ui.Controls.SpButton btn9;
        private Ui.Controls.SpButton btn8;
        private Ui.Controls.SpButton btn7;
        private Ui.Controls.SpButton btn0;
        private Ui.Controls.SpButton btnDecimal;
        private Ui.Controls.Specific.SpConfirmButton btnConfirm;
        private System.Windows.Forms.Panel pnlMain;
    }
}
