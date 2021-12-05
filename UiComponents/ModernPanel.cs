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
        private int bordersize = 0;
        private float borderradius = 40;
        private Color bordercolor = Color.Black;
        private Color backcolor1 = Color.White;
        private Color backcolor2 = Color.White;
        private float gradientdirection = 0;

        //properties of the variable
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
            get { return borderradius; }
            set {
                if (value <= this.Height)
                    borderradius = value;
                else
                    borderradius = this.Height;
                this.Invalidate();
            }
        }

        [Category("RoundedControl")]
        public Color BorderColor
        {
            get { return bordercolor; }
            set { 
                bordercolor = value;
                this.Invalidate();
            }
        }

        [Category("GradientControl")]
        public Color BackColor1
        {
            get { return backcolor1; }
            set { 
                backcolor1 = value;
                this.Invalidate();
            }
        }

        [Category("GradientControl")]
        public Color BackColor2
        {
            get { return backcolor2; }
            set { 
                backcolor2 = value;
                this.Invalidate();
            }
        }
        [Category("GradientControl")]
        public float GradientAngle
        {
            get { return gradientdirection; }
            set {
                gradientdirection = value;
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
            //for the best drawing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //area rectangle of the button and border
            RectangleF surfacerect = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF borderrect = new RectangleF(0, 0, this.Width - 1, this.Height - 1);

            if (borderradius >= 2) //rounded button
            {
                //paths and pens for the drawing
                using (GraphicsPath surfacepath = getPanelPath(surfacerect, borderradius))
                using (GraphicsPath borderpath = getPanelPath(borderrect, borderradius))
                using (LinearGradientBrush surfacelgb = new LinearGradientBrush(surfacerect,backcolor1,backcolor2, gradientdirection))
                using (Pen borderpen = new Pen(bordercolor, bordersize))
                {
                    //get new region and draw the surface
                    this.Region = new Region(surfacepath);
                    e.Graphics.FillPath(surfacelgb, surfacepath);

                    borderpen.Alignment = PenAlignment.Inset;

                    //draw the boreder
                    if (bordersize >= 1)
                        e.Graphics.DrawPath(borderpen, borderpath);

                }
            }
            else //normal bvutton
            {
                //for the new region
                this.Region = new Region(surfacerect);

                //border
                using (LinearGradientBrush surfacelgb = new LinearGradientBrush(surfacerect, backcolor1, backcolor2, gradientdirection))
                using (Pen borderpen = new Pen(this.bordercolor, bordersize))
                {
                    e.Graphics.FillRectangle(surfacelgb,surfacerect);
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
            if (this.Height < borderradius)
                borderradius = this.Height;
            if (this.Width < borderradius)
                borderradius = this.Width;
        }
    }
}
