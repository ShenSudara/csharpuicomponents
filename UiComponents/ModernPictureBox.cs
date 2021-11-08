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
    public class ModernPictureBox : PictureBox
    {
        private float borderradius = 0;
        private int bordersize = 0;
        private Color bordercolor = Color.Black;

        //constructor for the default appearaance
        public ModernPictureBox()
        {
            this.BorderStyle = BorderStyle.None;
            this.Size = new Size(50, 50);
        }

        //properties of the picture box
        [Category("RoundedControl")]
        public float BorderRadius
        {
            get { return borderradius; }
            set
            {
                if (value <= this.Height)
                    borderradius = value;
                else
                    borderradius = this.Height;
                if (value <= this.Width)
                    borderradius = value;
                else
                    borderradius = this.Height;
                borderradius = value;
                this.Invalidate();
            }
        }

        [Category("RoundedControl")]
        public int BorderSize
        {
            get { return bordersize; }
            set
            {
                bordersize = value;
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

        //get the pictuure box path
        private GraphicsPath getPictureBoxPath(RectangleF rect,float radius)
        {
            GraphicsPath newpath = new GraphicsPath();
            newpath.StartFigure();
            newpath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            newpath.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            newpath.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            newpath.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            newpath.CloseFigure();
            return newpath;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //this rectangle for the picture box surface and radius
            RectangleF rectsurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectborder = new RectangleF(0, 0, this.Width - 1, this.Height - 1);

            //drawing the border
            if(borderradius >= 2) 
            {
                //get the graphic paths object and pensfor this
                using(GraphicsPath surfacepath = getPictureBoxPath(rectsurface, borderradius))
                using (GraphicsPath borderpath = getPictureBoxPath(rectborder, borderradius))
                using(Pen surfacepen = new Pen(this.BackColor,2))
                using(Pen borderpen = new Pen(BorderColor,bordersize))
                {

                    //set the new region
                    this.Region = new Region(surfacepath);
                    pe.Graphics.DrawPath(surfacepen, surfacepath);

                    borderpen.Alignment = PenAlignment.Inset;
                    
                    //this will draw the border
                    if (bordersize > 0)
                        pe.Graphics.DrawPath(borderpen, borderpath);
                }
            }
            else // this for the normal button
            {
                this.Region = new Region(rectsurface);
                using (Pen borderpen = new Pen(BorderColor, bordersize)) {

                    if (bordersize > 0)
                        pe.Graphics.DrawRectangle(borderpen,0, 0, rectborder.Width, rectborder.Height);
                }

            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Resize += ModernPictureBox_Resize;
            this.BackColorChanged += ModernPictureBox_BackColorChanged;
        }

        private void ModernPictureBox_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void ModernPictureBox_Resize(object sender, EventArgs e)
        {
            if (this.Height < borderradius)
                borderradius = this.Height;
            if (this.Width < borderradius)
                borderradius = this.Width;
        }
    }
}
