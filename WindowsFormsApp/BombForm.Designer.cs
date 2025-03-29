
namespace WindowsFormsApp
{
    partial class BombForm
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
            this.serialDisplay = new System.Windows.Forms.Label();
            this.serialLabel = new System.Windows.Forms.Label();
            this.serialPanel1 = new System.Windows.Forms.Panel();
            this.serialPanel2 = new System.Windows.Forms.Panel();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerPanel = new System.Windows.Forms.Panel();
            this.strikeOne = new System.Windows.Forms.Label();
            this.strikeTwo = new System.Windows.Forms.Label();
            this.strikePanel = new System.Windows.Forms.Panel();
            this.timerModule = new System.Windows.Forms.Panel();
            this.module1 = new System.Windows.Forms.Button();
            this.module2 = new System.Windows.Forms.Button();
            this.module3 = new System.Windows.Forms.Button();
            this.module4 = new System.Windows.Forms.Button();
            this.serialPanel1.SuspendLayout();
            this.serialPanel2.SuspendLayout();
            this.timerPanel.SuspendLayout();
            this.strikePanel.SuspendLayout();
            this.timerModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialDisplay
            // 
            this.serialDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serialDisplay.AutoSize = true;
            this.serialDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.serialDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serialDisplay.Location = new System.Drawing.Point(3, 2);
            this.serialDisplay.Name = "serialDisplay";
            this.serialDisplay.Size = new System.Drawing.Size(157, 39);
            this.serialDisplay.TabIndex = 1;
            this.serialDisplay.Text = "ABCDEF";
            this.serialDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialLabel
            // 
            this.serialLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serialLabel.AutoSize = true;
            this.serialLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.serialLabel.Location = new System.Drawing.Point(23, 3);
            this.serialLabel.Name = "serialLabel";
            this.serialLabel.Size = new System.Drawing.Size(64, 16);
            this.serialLabel.TabIndex = 2;
            this.serialLabel.Text = "SERIAL #";
            this.serialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPanel1
            // 
            this.serialPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serialPanel1.BackColor = System.Drawing.Color.Brown;
            this.serialPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialPanel1.Controls.Add(this.serialLabel);
            this.serialPanel1.Location = new System.Drawing.Point(742, 12);
            this.serialPanel1.Name = "serialPanel1";
            this.serialPanel1.Size = new System.Drawing.Size(126, 26);
            this.serialPanel1.TabIndex = 3;
            // 
            // serialPanel2
            // 
            this.serialPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serialPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.serialPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialPanel2.Controls.Add(this.serialDisplay);
            this.serialPanel2.Location = new System.Drawing.Point(742, 34);
            this.serialPanel2.Name = "serialPanel2";
            this.serialPanel2.Size = new System.Drawing.Size(126, 49);
            this.serialPanel2.TabIndex = 4;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Red;
            this.timerLabel.Location = new System.Drawing.Point(4, 8);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(158, 61);
            this.timerLabel.TabIndex = 5;
            this.timerLabel.Text = "00:00";
            // 
            // timerPanel
            // 
            this.timerPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timerPanel.Controls.Add(this.timerLabel);
            this.timerPanel.Location = new System.Drawing.Point(29, 73);
            this.timerPanel.Name = "timerPanel";
            this.timerPanel.Size = new System.Drawing.Size(169, 73);
            this.timerPanel.TabIndex = 6;
            // 
            // strikeOne
            // 
            this.strikeOne.AutoSize = true;
            this.strikeOne.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.strikeOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strikeOne.ForeColor = System.Drawing.Color.Red;
            this.strikeOne.Location = new System.Drawing.Point(3, -3);
            this.strikeOne.Name = "strikeOne";
            this.strikeOne.Size = new System.Drawing.Size(0, 46);
            this.strikeOne.TabIndex = 7;
            // 
            // strikeTwo
            // 
            this.strikeTwo.AutoSize = true;
            this.strikeTwo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.strikeTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strikeTwo.ForeColor = System.Drawing.Color.Red;
            this.strikeTwo.Location = new System.Drawing.Point(56, -2);
            this.strikeTwo.Name = "strikeTwo";
            this.strikeTwo.Size = new System.Drawing.Size(0, 46);
            this.strikeTwo.TabIndex = 8;
            // 
            // strikePanel
            // 
            this.strikePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.strikePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.strikePanel.Controls.Add(this.strikeTwo);
            this.strikePanel.Controls.Add(this.strikeOne);
            this.strikePanel.Location = new System.Drawing.Point(58, 15);
            this.strikePanel.Name = "strikePanel";
            this.strikePanel.Size = new System.Drawing.Size(105, 47);
            this.strikePanel.TabIndex = 9;
            // 
            // timerModule
            // 
            this.timerModule.BackColor = System.Drawing.SystemColors.ControlDark;
            this.timerModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timerModule.Controls.Add(this.strikePanel);
            this.timerModule.Controls.Add(this.timerPanel);
            this.timerModule.Location = new System.Drawing.Point(12, 16);
            this.timerModule.Name = "timerModule";
            this.timerModule.Size = new System.Drawing.Size(229, 175);
            this.timerModule.TabIndex = 10;
            // 
            // module1
            // 
            this.module1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.module1.Location = new System.Drawing.Point(335, 20);
            this.module1.Name = "module1";
            this.module1.Size = new System.Drawing.Size(123, 25);
            this.module1.TabIndex = 11;
            this.module1.Text = "Module 1";
            this.module1.UseVisualStyleBackColor = true;
            this.module1.Click += new System.EventHandler(this.module1_Click);
            // 
            // module2
            // 
            this.module2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.module2.Location = new System.Drawing.Point(464, 20);
            this.module2.Name = "module2";
            this.module2.Size = new System.Drawing.Size(123, 25);
            this.module2.TabIndex = 12;
            this.module2.Text = "Module 2";
            this.module2.UseVisualStyleBackColor = true;
            this.module2.Click += new System.EventHandler(this.module2_Click);
            // 
            // module3
            // 
            this.module3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.module3.Location = new System.Drawing.Point(335, 51);
            this.module3.Name = "module3";
            this.module3.Size = new System.Drawing.Size(123, 25);
            this.module3.TabIndex = 13;
            this.module3.Text = "Module 3";
            this.module3.UseVisualStyleBackColor = true;
            this.module3.Click += new System.EventHandler(this.module3_Click);
            // 
            // module4
            // 
            this.module4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.module4.Location = new System.Drawing.Point(464, 51);
            this.module4.Name = "module4";
            this.module4.Size = new System.Drawing.Size(123, 25);
            this.module4.TabIndex = 14;
            this.module4.Text = "Module 4";
            this.module4.UseVisualStyleBackColor = true;
            this.module4.Click += new System.EventHandler(this.module4_Click);
            // 
            // BombForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(897, 543);
            this.Controls.Add(this.module4);
            this.Controls.Add(this.module3);
            this.Controls.Add(this.module2);
            this.Controls.Add(this.module1);
            this.Controls.Add(this.timerModule);
            this.Controls.Add(this.serialPanel2);
            this.Controls.Add(this.serialPanel1);
            this.Name = "BombForm";
            this.Text = "Keep Talking";
            this.serialPanel1.ResumeLayout(false);
            this.serialPanel1.PerformLayout();
            this.serialPanel2.ResumeLayout(false);
            this.serialPanel2.PerformLayout();
            this.timerPanel.ResumeLayout(false);
            this.timerPanel.PerformLayout();
            this.strikePanel.ResumeLayout(false);
            this.strikePanel.PerformLayout();
            this.timerModule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label serialDisplay;
        private System.Windows.Forms.Label serialLabel;
        private System.Windows.Forms.Panel serialPanel1;
        private System.Windows.Forms.Panel serialPanel2;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Panel timerPanel;
        private System.Windows.Forms.Label strikeOne;
        private System.Windows.Forms.Label strikeTwo;
        private System.Windows.Forms.Panel strikePanel;
        private System.Windows.Forms.Panel timerModule;
        private System.Windows.Forms.Button module1;
        private System.Windows.Forms.Button module2;
        private System.Windows.Forms.Button module3;
        private System.Windows.Forms.Button module4;
    }
}
