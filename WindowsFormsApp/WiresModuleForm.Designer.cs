
namespace WindowsFormsApp
{
    partial class WiresModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WiresModuleForm));
            this.wire0 = new System.Windows.Forms.PictureBox();
            this.wire1 = new System.Windows.Forms.PictureBox();
            this.wire2 = new System.Windows.Forms.PictureBox();
            this.wire3 = new System.Windows.Forms.PictureBox();
            this.wire4 = new System.Windows.Forms.PictureBox();
            this.wire5 = new System.Windows.Forms.PictureBox();
            this.wirepanel = new System.Windows.Forms.Panel();
            this.solveIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wire0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire5)).BeginInit();
            this.wirepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wire0
            // 
            this.wire0.Image = ((System.Drawing.Image)(resources.GetObject("wire0.Image")));
            this.wire0.Location = new System.Drawing.Point(0, 6);
            this.wire0.Name = "wire0";
            this.wire0.Size = new System.Drawing.Size(250, 52);
            this.wire0.TabIndex = 0;
            this.wire0.TabStop = false;
            this.wire0.Click += new System.EventHandler(this.wire0_Click);
            // 
            // wire1
            // 
            this.wire1.Image = ((System.Drawing.Image)(resources.GetObject("wire1.Image")));
            this.wire1.Location = new System.Drawing.Point(0, 64);
            this.wire1.Name = "wire1";
            this.wire1.Size = new System.Drawing.Size(250, 52);
            this.wire1.TabIndex = 1;
            this.wire1.TabStop = false;
            this.wire1.Click += new System.EventHandler(this.wire1_Click);
            // 
            // wire2
            // 
            this.wire2.Image = ((System.Drawing.Image)(resources.GetObject("wire2.Image")));
            this.wire2.Location = new System.Drawing.Point(0, 122);
            this.wire2.Name = "wire2";
            this.wire2.Size = new System.Drawing.Size(250, 52);
            this.wire2.TabIndex = 2;
            this.wire2.TabStop = false;
            this.wire2.Click += new System.EventHandler(this.wire2_Click);
            // 
            // wire3
            // 
            this.wire3.Image = ((System.Drawing.Image)(resources.GetObject("wire3.Image")));
            this.wire3.Location = new System.Drawing.Point(0, 180);
            this.wire3.Name = "wire3";
            this.wire3.Size = new System.Drawing.Size(250, 52);
            this.wire3.TabIndex = 3;
            this.wire3.TabStop = false;
            this.wire3.Click += new System.EventHandler(this.wire3_Click);
            // 
            // wire4
            // 
            this.wire4.Image = ((System.Drawing.Image)(resources.GetObject("wire4.Image")));
            this.wire4.Location = new System.Drawing.Point(0, 238);
            this.wire4.Name = "wire4";
            this.wire4.Size = new System.Drawing.Size(250, 52);
            this.wire4.TabIndex = 4;
            this.wire4.TabStop = false;
            this.wire4.Click += new System.EventHandler(this.wire4_Click);
            // 
            // wire5
            // 
            this.wire5.Image = ((System.Drawing.Image)(resources.GetObject("wire5.Image")));
            this.wire5.Location = new System.Drawing.Point(0, 296);
            this.wire5.Name = "wire5";
            this.wire5.Size = new System.Drawing.Size(250, 52);
            this.wire5.TabIndex = 5;
            this.wire5.TabStop = false;
            this.wire5.Click += new System.EventHandler(this.wire5_Click);
            // 
            // wirepanel
            // 
            this.wirepanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wirepanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.wirepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wirepanel.Controls.Add(this.wire5);
            this.wirepanel.Controls.Add(this.wire4);
            this.wirepanel.Controls.Add(this.wire3);
            this.wirepanel.Controls.Add(this.wire2);
            this.wirepanel.Controls.Add(this.wire1);
            this.wirepanel.Controls.Add(this.wire0);
            this.wirepanel.Location = new System.Drawing.Point(276, 27);
            this.wirepanel.Name = "wirepanel";
            this.wirepanel.Size = new System.Drawing.Size(252, 360);
            this.wirepanel.TabIndex = 6;
            // 
            // solveIndicator
            // 
            this.solveIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.solveIndicator.AutoSize = true;
            this.solveIndicator.Location = new System.Drawing.Point(675, 9);
            this.solveIndicator.Name = "solveIndicator";
            this.solveIndicator.Size = new System.Drawing.Size(113, 16);
            this.solveIndicator.TabIndex = 7;
            this.solveIndicator.Text = "Unsolved Module";
            this.solveIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WiresModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.solveIndicator);
            this.Controls.Add(this.wirepanel);
            this.Name = "WiresModuleForm";
            this.Text = "WiresModuleForm";
            ((System.ComponentModel.ISupportInitialize)(this.wire0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wire5)).EndInit();
            this.wirepanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox wire0;
        private System.Windows.Forms.PictureBox wire1;
        private System.Windows.Forms.PictureBox wire2;
        private System.Windows.Forms.PictureBox wire3;
        private System.Windows.Forms.PictureBox wire4;
        private System.Windows.Forms.PictureBox wire5;
        private System.Windows.Forms.Panel wirepanel;
        private System.Windows.Forms.Label solveIndicator;
    }
}
 