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

        //for the gradient
        private Color color1;
        private Color color2;
        private bool enablegradient = false;
        private float angle = 0.0f;

        //for the hover colors
        private Color hovercolor1 = Color.White;
        private Color hovercolor2 = Color.White;
        private bool hoverenable;
        private float hoverangle = 0.0f;


        //keep default values
        private Color defaultcolor1;
        private Color defaultcolor2;
        private float defaultangle;



        //for the hover color
        [Category("Hover Control")]
        public Color HoverColor1 { get => hovercolor1; set => hovercolor1 = value; }

        [Category("Hover Control")]
        public Color HoverColor2 { get => hovercolor2; set => hovercolor2 = value; }

        [Category("Hover Control")]
        public bool HoverEnable { get => hoverenable; set => hoverenable = value; }

        [Category("Hover Control")]
        public float HoverAngle { get => hoverangle; set => hoverangle = value; }



        //enable the gradient
        [Category("Gradient Control")]
        public bool GradientEnable
        {
            get {
                return enablegradient;
            }
            set {
                enablegradient = value;
                this.Invalidate();
            }
        }


        //gradient color - I'll remove the color changes because of it will reduce more cpu time
        [Category("Gradient Control")]
        public Color Color1 {
            get {
                return color1;
            }
            set
            {
                this.color1 = value;
            }
        }

        [Category("Gradient Control")]
        public Color Color2
        {
            get {
                return color2;
            }
            set {
                this.color2 = value;
            }
        }
        [Category("Gradient Control")]
        public float Angle
        {
            get {
                return angle;
            }

            set {
                this.angle = value;
            }
        }



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
            Color1 = this.BackColor;
            Color2 = this.BackColor;

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
                using(Pen surfacepen = new Pen(this.BackColor,2))
                using (LinearGradientBrush lgb = new LinearGradientBrush(surfacerect, Color1, Color2, Angle))
                using (Pen borderpen = new Pen(bordercolor, bordersize))
                {
                    //get new region and draw the surface
                    this.Region = new Region(surfacepath);
                    if (GradientEnable || HoverEnable)
                        pevent.Graphics.FillPath(lgb, surfacepath);
                    else
                        pevent.Graphics.DrawPath(surfacepen, surfacepath);

                    borderpen.Alignment = PenAlignment.Inset;
                    //draw the border
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
                    using (LinearGradientBrush lgb = new LinearGradientBrush(surfacerect, Color1, Color2, Angle)) 
                    using(SolidBrush sb = new SolidBrush(this.BackColor))
                    {

                        //if border size more than 1 draw the border
                        if (bordersize >= 1)
                        {
                            pevent.Graphics.DrawRectangle(borderpen, 0, 0, borderrect.Width, borderrect.Height);
                            if (GradientEnable || HoverEnable)
                                pevent.Graphics.FillRectangle(lgb, surfacerect);
                            else
                                pevent.Graphics.FillRectangle(sb,surfacerect);
                        }
                        else {
                            if (GradientEnable)
                                pevent.Graphics.FillRectangle(lgb, surfacerect);
                            else
                                pevent.Graphics.FillRectangle(sb, surfacerect);
                        }
                            
                    }

                }

            }

            //draw string
            using(SolidBrush drawbrush = new SolidBrush(this.ForeColor))
            using(StringFormat drawformat = new StringFormat())
            {
                SizeF fontsize = new SizeF();
                fontsize = pevent.Graphics.MeasureString(this.Text, this.Font);
                pevent.Graphics.DrawString(this.Text, this.Font, drawbrush,(this.Width/2) - (fontsize.Width/2), (this.Height / 2) - (fontsize.Height / 2), drawformat); 
            }
        }


        //when even is popup if it is back color changed or resizing this will run thhose function
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.BackColorChanged += ModernButton_BackColorChanged;
            this.Resize += ModernButton_Resize;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (HoverEnable) {
                Color1 = defaultcolor1;
                Color2 = defaultcolor2;
                Angle = defaultangle;
                GradientEnable = true;

            }
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (HoverEnable) {
                defaultcolor1 = Color1;
                defaultcolor2 = Color2;
                defaultangle = Angle;

                Color1 = HoverColor1;
                Color2 = HoverColor2;
                Angle = HoverAngle;
                GradientEnable = true;
            }
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
