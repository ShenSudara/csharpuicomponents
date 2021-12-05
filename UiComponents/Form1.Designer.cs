
namespace UiComponents
{
    partial class Form1
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
            this.modernButton1 = new UiComponents.ModernButton();
            this.modernButton2 = new UiComponents.ModernButton();
            this.modernButton3 = new UiComponents.ModernButton();
            this.modernButton4 = new UiComponents.ModernButton();
            this.modernPanel1 = new UiComponents.ModernPanel();
            this.modernPanel2 = new UiComponents.ModernPanel();
            this.modernPictureBox1 = new UiComponents.ModernPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.modernPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // modernButton1
            // 
            this.modernButton1.BorderColor = System.Drawing.Color.Red;
            this.modernButton1.BorderRadius = 40F;
            this.modernButton1.BorderSize = 5;
            this.modernButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modernButton1.Location = new System.Drawing.Point(29, 12);
            this.modernButton1.Name = "modernButton1";
            this.modernButton1.RoundEnable = false;
            this.modernButton1.Size = new System.Drawing.Size(100, 50);
            this.modernButton1.TabIndex = 0;
            this.modernButton1.Text = "modernButton1";
            this.modernButton1.UseVisualStyleBackColor = true;
            // 
            // modernButton2
            // 
            this.modernButton2.BorderColor = System.Drawing.Color.Yellow;
            this.modernButton2.BorderRadius = 40F;
            this.modernButton2.BorderSize = 5;
            this.modernButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modernButton2.Location = new System.Drawing.Point(160, 12);
            this.modernButton2.Name = "modernButton2";
            this.modernButton2.RoundEnable = true;
            this.modernButton2.Size = new System.Drawing.Size(100, 50);
            this.modernButton2.TabIndex = 1;
            this.modernButton2.Text = "modernButton2";
            this.modernButton2.UseVisualStyleBackColor = true;
            // 
            // modernButton3
            // 
            this.modernButton3.BorderColor = System.Drawing.Color.Green;
            this.modernButton3.BorderRadius = 100F;
            this.modernButton3.BorderSize = 5;
            this.modernButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modernButton3.Location = new System.Drawing.Point(298, 12);
            this.modernButton3.Name = "modernButton3";
            this.modernButton3.RoundEnable = true;
            this.modernButton3.Size = new System.Drawing.Size(100, 100);
            this.modernButton3.TabIndex = 2;
            this.modernButton3.Text = "modernButton3";
            this.modernButton3.UseVisualStyleBackColor = true;
            // 
            // modernButton4
            // 
            this.modernButton4.BackColor = System.Drawing.Color.Lime;
            this.modernButton4.BorderColor = System.Drawing.Color.DarkRed;
            this.modernButton4.BorderRadius = 100F;
            this.modernButton4.BorderSize = 8;
            this.modernButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modernButton4.Location = new System.Drawing.Point(432, 12);
            this.modernButton4.Name = "modernButton4";
            this.modernButton4.RoundEnable = true;
            this.modernButton4.Size = new System.Drawing.Size(100, 100);
            this.modernButton4.TabIndex = 3;
            this.modernButton4.Text = "modernButton4";
            this.modernButton4.UseVisualStyleBackColor = false;
            // 
            // modernPanel1
            // 
            this.modernPanel1.BackColor1 = System.Drawing.Color.White;
            this.modernPanel1.BackColor2 = System.Drawing.Color.White;
            this.modernPanel1.BorderColor = System.Drawing.Color.Black;
            this.modernPanel1.BorderRadius = 80F;
            this.modernPanel1.BorderSize = 2;
            this.modernPanel1.GradientAngle = 0F;
            this.modernPanel1.Location = new System.Drawing.Point(29, 143);
            this.modernPanel1.Name = "modernPanel1";
            this.modernPanel1.Size = new System.Drawing.Size(200, 100);
            this.modernPanel1.TabIndex = 4;
            // 
            // modernPanel2
            // 
            this.modernPanel2.BackColor1 = System.Drawing.Color.Lime;
            this.modernPanel2.BackColor2 = System.Drawing.Color.Yellow;
            this.modernPanel2.BorderColor = System.Drawing.Color.Black;
            this.modernPanel2.BorderRadius = 80F;
            this.modernPanel2.BorderSize = 2;
            this.modernPanel2.GradientAngle = 18F;
            this.modernPanel2.Location = new System.Drawing.Point(284, 143);
            this.modernPanel2.Name = "modernPanel2";
            this.modernPanel2.Size = new System.Drawing.Size(200, 175);
            this.modernPanel2.TabIndex = 5;
            // 
            // modernPictureBox1
            // 
            this.modernPictureBox1.BorderColor = System.Drawing.Color.Black;
            this.modernPictureBox1.BorderRadius = 100F;
            this.modernPictureBox1.BorderSize = 5;
            this.modernPictureBox1.Location = new System.Drawing.Point(54, 366);
            this.modernPictureBox1.Name = "modernPictureBox1";
            this.modernPictureBox1.Size = new System.Drawing.Size(103, 101);
            this.modernPictureBox1.TabIndex = 6;
            this.modernPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.modernPictureBox1);
            this.Controls.Add(this.modernPanel2);
            this.Controls.Add(this.modernPanel1);
            this.Controls.Add(this.modernButton4);
            this.Controls.Add(this.modernButton3);
            this.Controls.Add(this.modernButton2);
            this.Controls.Add(this.modernButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modernPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ModernButton modernButton1;
        private ModernButton modernButton2;
        private ModernButton modernButton3;
        private ModernButton modernButton4;
        private ModernPanel modernPanel1;
        private ModernPanel modernPanel2;
        private ModernPictureBox modernPictureBox1;
    }
}