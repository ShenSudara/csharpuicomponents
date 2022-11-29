using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UiComponents
{
    public class ModernPanel : Panel
    {
        //attributes for the modern panel
        private bool roundedEnable = false;
        private int bordersize = 1;
        private float borderRadius = 1;
        private Color borderColor = Color.Black;
        private bool gradientEnable = false;
        private Color gradientColor1 = Color.White;
        private Color gradientColor2 = Color.White;
        private float gradientDirection = 0;


        //properties of the rounded shape
        [Category("RoundedControl")]
        public bool RoundedEnable
        {
            get
            {
                return roundedEnable;
            }
            set
            {
                if (value)
                {
                    if (BorderRadius <= 1)
                    {
                        BorderRadius = 1;
                    }
                }
                else
                {
                    if (BorderRadius <= 0)
                    {
                        BorderRadius = 0;
                    }
                }
                roundedEnable = value;
                this.Invalidate();
            }
        }

        [Category("RoundedControl")]
        public int BorderSize
        {
            get { return bordersize; }
            set { 
                bordersize = value;
                this.Invalidate();
            }

        }

        [Category("RoundedControl")]
        public float BorderRadius
        {
            get { return borderRadius; }
            set {
                if (roundedEnable)
                {
                    if (value <= 1)
                        borderRadius = 1;
                    else
                    {
                        //prevent the width and height went out wrong
                        if (value <= this.Height)
                            borderRadius = value;
                        else
                            borderRadius = this.Height;
                        if (value <= this.Width)
                            borderRadius = value;
                        else
                            borderRadius = this.Width;
                    }
                }
                else
                {
                    if (value <= 0)
                        borderRadius = 0;
                    else
                    {
                        //prevent the width and height went out wrong
                        if (value <= this.Height)
                            borderRadius = value;
                        else
                            borderRadius = this.Height;
                        if (value <= this.Width)
                            borderRadius = value;
                        else
                            borderRadius = this.Width;
                    }

                }
                this.Invalidate();
            }
        }

        [Category("RoundedControl")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { 
                borderColor = value;
                this.Invalidate();
            }
        }

        //properties of the rounded shape
        [Category("GradientControl")]
        public bool GradientEnable
        {
            get
            {
                return gradientEnable;
            }
            set
            {
                gradientEnable = value;
                this.Invalidate();
            }
        }

        [Category("GradientControl")]
        public Color GradientColor1
        {
            get { return gradientColor1; }
            set {
                gradientColor1 = value;
                this.Invalidate();
            }
        }

        [Category("GradientControl")]
        public Color GradientColor2
        {
            get { return gradientColor2; }
            set { 
                gradientColor2 = value;
                this.Invalidate();
            }
        }
        [Category("GradientControl")]
        public float GradientAngle
        {
            get { return gradientDirection; }
            set {
                gradientDirection = value;
                this.Invalidate();
            }
        }




        //constructor for the default apperancne
        public ModernPanel()
        {
            this.BorderStyle = BorderStyle.None;
            this.Size = new Size(200, 100);
        }

        //get the rounded path
        private GraphicsPath getPanelPath(RectangleF rect,float radius)
        {
            GraphicsPath buttonpath = new GraphicsPath();
            buttonpath.StartFigure();
            buttonpath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            buttonpath.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            buttonpath.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            buttonpath.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            buttonpath.CloseFigure();
            return buttonpath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //area rectangle of the button and border
            RectangleF surfacerect = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF borderrect = new RectangleF(0, 0, this.Width - 1, this.Height - 1);

            if (borderRadius >= 2) //rounded button
            {
                using (GraphicsPath surfacepath = getPanelPath(surfacerect, borderRadius))
                using (GraphicsPath borderpath = getPanelPath(borderrect, borderRadius))
                using (LinearGradientBrush surfacelgb = new LinearGradientBrush(surfacerect, gradientColor1, gradientColor2, gradientDirection))
                using (Pen borderpen = new Pen(borderColor, bordersize))
                using(Pen surfacePen = new Pen(this.BackColor))
                {
                    this.Region = new Region(surfacepath);
                    if (gradientEnable)
                        e.Graphics.FillPath(surfacelgb, surfacepath);
                    else
                        e.Graphics.DrawPath(surfacePen, surfacepath);
                    borderpen.Alignment = PenAlignment.Inset;
                    //draw the boreder
                    if (bordersize >= 1)
                        e.Graphics.DrawPath(borderpen, borderpath);

                }
            }
            else //normal bvutton
            {
                this.Region = new Region(surfacerect);
                //border
                using (LinearGradientBrush surfacelgb = new LinearGradientBrush(surfacerect, gradientColor1, gradientColor2, gradientDirection))
                using(SolidBrush sb = new SolidBrush(this.BackColor))
                using (Pen borderpen = new Pen(this.borderColor, bordersize))
                {
                    if (gradientEnable)
                        e.Graphics.FillRectangle(surfacelgb, surfacerect);
                    else
                        e.Graphics.FillRectangle(sb,surfacerect);
                    borderpen.Alignment = PenAlignment.Inset;
                    if (bordersize >= 1)
                        e.Graphics.DrawRectangle(borderpen, 0, 0, borderrect.Width, borderrect.Height);
                }

            }

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Resize += ModernPanel_Resize;
            this.BackColorChanged += ModernPanel_BackColorChanged;
        }

        private void ModernPanel_BackColorChanged(object sender, EventArgs e)
        {
                this.Invalidate();
        }

        private void ModernPanel_Resize(object sender, EventArgs e)
        {
            if (this.Height < borderRadius)
                borderRadius = this.Height;
            if (this.Width < borderRadius)
                borderRadius = this.Width;
        }
    }
}
