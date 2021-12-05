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
    public class ModernButton : Button
    {
        //this for the button properties
        private int bordersize = 2;
        private float borderradius = 40;
        private Color bordercolor = Color.Black;
        private bool roundedenable = false;

        //this for the properties
        [Category("Rounded Control")]
        public bool RoundEnable
        {
            get
            {
                return roundedenable;
            }

            set
            {
                roundedenable = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Control")]
        public float BorderRadius
        {
            get { return borderradius; }
            set
            {
                //this will prevent the width and height go ouut of the scope
                if (value <= this.Height)
                    borderradius = value;
                else
                    borderradius = this.Height;
                if (value <= this.Width)
                    borderradius = value;
                else
                    borderradius = this.Width;
                this.Invalidate();
            }
        }

        [Category("Rounded Control")]
        public int BorderSize
        {
            get { return bordersize; }
            set
            {
                bordersize = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Control")]
        public Color BorderColor
        {
            get { return bordercolor; }
            set {
                bordercolor = value;
                this.Invalidate();
            }
        }

        public ModernButton()
        {
            this.Size = new Size(100, 50);
            this.FlatStyle = FlatStyle.Flat;

        }

        //this will genrate the button path
        private GraphicsPath getButtonPath(RectangleF rect,float radius)
        {
            GraphicsPath buttonpath = new GraphicsPath();
            buttonpath.StartFigure();
            buttonpath.AddArc(rect.X,rect.Y,radius,radius,180,90);
            buttonpath.AddArc(rect.Width - borderradius,rect.Y,radius,radius,270,90);
            buttonpath.AddArc(rect.Width - radius,rect.Height - radius,radius,radius,0,90);
            buttonpath.AddArc(rect.X,rect.Height - radius,radius,radius,90,90);
            buttonpath.CloseFigure();
            return buttonpath;
        }

        //this will redraw the button border and others
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //for the best drawing
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //area rectangle of the button and border
            RectangleF surfacerect = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF borderrect = new RectangleF(0, 0, this.Width - 1, this.Height - 1);

            if(roundedenable) //rounded button
            {
                //paths and pens for the drawing
                using (GraphicsPath surfacepath = getButtonPath(surfacerect, borderradius))
                using (GraphicsPath borderpath = getButtonPath(borderrect, borderradius))
                using (Pen surfacepen = new Pen(this.BackColor, 2))
                using (Pen borderpen = new Pen(bordercolor, bordersize))
                {
                    //get new region and draw the surface
                    this.Region = new Region(surfacepath);
                    pevent.Graphics.DrawPath(surfacepen, surfacepath);

                    borderpen.Alignment = PenAlignment.Inset;

                    //draw the boreder
                    if (bordersize >= 1)
                        pevent.Graphics.DrawPath(borderpen, borderpath);

                }
            }
            else //normal bvutton
            {
                //for the new region
                this.Region = new Region(surfacerect);
               
                //border
                using(Pen borderpen = new Pen(this.bordercolor, bordersize))
                {
                    borderpen.Alignment = PenAlignment.Inset;
                    if (bordersize >= 1)
                        pevent.Graphics.DrawRectangle(borderpen,0,0,borderrect.Width,borderrect.Height);
                }

            }
        }

        //when even is popup if it is back color changed or resizing this will run thhose function
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.BackColorChanged += ModernButton_BackColorChanged;
            this.Resize += ModernButton_Resize;
        }

        //prevent the buutoon resizing go out of the scope
        private void ModernButton_Resize(object sender, EventArgs e)
        {
            if (this.Height < borderradius)
                borderradius = this.Height;
            if (this.Width < borderradius)
                borderradius = this.Width;

        }
        //when back color changing
        private void ModernButton_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

    }
}
