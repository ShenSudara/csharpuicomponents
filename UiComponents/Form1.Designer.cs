
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
            this.SuspendLayout();
            // 
            // modernButton1
            // 
            this.modernButton1.Angle = 0F;
            this.modernButton1.BorderColor = System.Drawing.Color.Black;
            this.modernButton1.BorderRadius = 40F;
            this.modernButton1.BorderSize = 2;
            this.modernButton1.Color1 = System.Drawing.Color.White;
            this.modernButton1.Color2 = System.Drawing.SystemColors.Control;
            this.modernButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modernButton1.GradientEnable = false;
            this.modernButton1.HoverAngle = 0F;
            this.modernButton1.HoverColor1 = System.Drawing.Color.Yellow;
            this.modernButton1.HoverColor2 = System.Drawing.Color.Lime;
            this.modernButton1.HoverEnable = true;
            this.modernButton1.Location = new System.Drawing.Point(232, 102);
            this.modernButton1.Name = "modernButton1";
            this.modernButton1.RoundEnable = false;
            this.modernButton1.Size = new System.Drawing.Size(100, 50);
            this.modernButton1.TabIndex = 0;
            this.modernButton1.Text = "modernButton1";
            this.modernButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.modernButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ModernButton modernButton1;
    }
}