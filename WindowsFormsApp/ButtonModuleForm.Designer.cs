 
namespace WindowsFormsApp
{
    partial class ButtonModuleForm
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
            this.button = new System.Windows.Forms.Button();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.solveIndicator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button.Location = new System.Drawing.Point(274, 133);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(227, 173);
            this.button.TabIndex = 9;
            this.button.Text = "button1";
            this.button.UseVisualStyleBackColor = false;
            this.button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_Up);
            this.button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_Click);
            this.button.MouseLeave += new System.EventHandler(this.button_Up);
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sidePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sidePanel.Location = new System.Drawing.Point(553, 159);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(50, 110);
            this.sidePanel.TabIndex = 10;
            // 
            // solveIndicator
            // 
            this.solveIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.solveIndicator.AutoSize = true;
            this.solveIndicator.Location = new System.Drawing.Point(675, 9);
            this.solveIndicator.Name = "solveIndicator";
            this.solveIndicator.Size = new System.Drawing.Size(113, 16);
            this.solveIndicator.TabIndex = 11;
            this.solveIndicator.Text = "Unsolved Module";
            this.solveIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.solveIndicator);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.button);
            this.Name = "ButtonModuleForm";
            this.Text = "ButtonModuleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label solveIndicator;
    }
}
 