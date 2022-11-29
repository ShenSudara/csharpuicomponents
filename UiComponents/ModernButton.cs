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
        //button rounded properties
        private int borderSize;
        private float borderRadius = 1;
        private Color borderColor = Color.Black;
        private bool roundedEnable = false;

        //gradient properties
        private Color gradientColor1;
        private Color gradientColor2;
        private bool gradientEnable = false;
        private float angle = 0.0f;

        //hover properties
        private Color hoverColor1 = Color.White;
        private Color hoverColor2 = Color.White;
        private bool hoverEnable;
        private float hoverAngle = 0.0f;

        //default properties for the hover
        private Color defaultColor1;
        private Color defaultColor2;
        private float defaultAngle;


        //for the hover color
        [Category("Hover Control")]
        public Color HoverColor1 { get => hoverColor1; set => hoverColor1 = value; }

        [Category("Hover Control")]
        public Color HoverColor2 { get => hoverColor2; set => hoverColor2 = value; }

        [Category("Hover Control")]
        public bool HoverEnable { get => hoverEnable; set => hoverEnable = value; }

        [Category("Hover Control")]
        public float HoverAngle { get => hoverAngle; set => hoverAngle = value; }


        //enable the gradient
        [Category("Gradient Control")]
        public bool GradientEnable
        {
            get {
                return gradientEnable;
            }
            set {
                gradientEnable = value;
                this.Invalidate();
            }
        }


        //gradient color 1
        [Category("Gradient Control")]
        public Color GradientColor1 {
            get {
                return gradientColor1;
            }
            set
            {
                this.gradientColor1 = value;
                this.Invalidate();
            }
        }

        [Category("Gradient Control")]
        public Color GradientColor2
        {
            get {
                return gradientColor2;
            }
            set {
                this.gradientColor2 = value;
                this.Invalidate();
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
                this.Invalidate();
            }
        }


        //this for the properties
        [Category("Rounded Control")]
        public bool RoundEnable
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
                else {
                    if (BorderRadius <= 0) {
                        BorderRadius = 0;
                    }
                }
                roundedEnable = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Control")]
        public float BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (roundedEnable)
                {
                    if (value <= 1)
                        borderRadius = 1;
                    else {
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
                    else {
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

        [Category("Rounded Control")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Control")]
        public Color BorderColor
        {
            get { return borderColor; }
            set {
                borderColor = value;
                this.Invalidate();
            }
        }



        public ModernButton()
        {
            this.Size = new Size(100, 50);
            this.FlatStyle = FlatStyle.Flat;
            BorderSize = 1;
            GradientColor1 = this.BackColor;
            GradientColor2 = this.BackColor;
        }
        //draw text after the painting
        public void redrawString(PaintEventArgs pevent) {
            using (SolidBrush drawbrush = new SolidBrush(this.ForeColor))
            using (StringFormat drawformat = new StringFormat())
            {
                SizeF fontsize = new SizeF();
                fontsize = pevent.Graphics.MeasureString(this.Text, this.Font);
                pevent.Graphics.DrawString(this.Text, this.Font, drawbrush, (this.Width / 2) - (fontsize.Width / 2), (this.Height / 2) - (fontsize.Height / 2), drawformat);
            }
        }

        //get the button path according to the dimentions
        private GraphicsPath getButtonPath(RectangleF rect,float radius)
        {
            GraphicsPath buttonpath = new GraphicsPath();
            buttonpath.StartFigure();
            buttonpath.AddArc(rect.X,rect.Y,radius,radius,180,90);
            buttonpath.AddArc(rect.Width - borderRadius,rect.Y,radius,radius,270,90);
            buttonpath.AddArc(rect.Width - radius,rect.Height - radius,radius,radius,0,90);
            buttonpath.AddArc(rect.X,rect.Height - radius,radius,radius,90,90);
            buttonpath.CloseFigure();
            return buttonpath;
        }

        //redraw the button border
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF surfacerect = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF borderrect = new RectangleF(0, 0, this.Width - 1, this.Height - 1);
            //when button rounded is enable
            if(roundedEnable)
            {
                using (GraphicsPath surfacepath = getButtonPath(surfacerect, borderRadius))
                using (GraphicsPath borderpath = getButtonPath(borderrect, borderRadius))
                using(Pen surfacepen = new Pen(this.BackColor,2))
                using (LinearGradientBrush lgb = new LinearGradientBrush(surfacerect, gradientColor1, gradientColor2, angle))
                using (Pen borderpen = new Pen(borderColor, borderSize))
                {
                    //get new region and draw the surface
                    this.Region = new Region(surfacepath);
                    if (gradientEnable) {
                        pevent.Graphics.FillPath(lgb, surfacepath);
                        redrawString(pevent);
                    }
                    else
                        pevent.Graphics.DrawPath(surfacepen, surfacepath);
                    borderpen.Alignment = PenAlignment.Inset;
                    //draw the border
                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(borderpen, borderpath);
                }
            }
            else //normal bvutton
            {
                this.Region = new Region(surfacerect);
                using(Pen borderpen = new Pen(this.borderColor, borderSize))
                {
                    borderpen.Alignment = PenAlignment.Inset;
                    using (LinearGradientBrush lgb = new LinearGradientBrush(surfacerect, GradientColor1, GradientColor2, Angle)) 
                    using(SolidBrush sb = new SolidBrush(this.BackColor))
                    {

                        if (GradientEnable)
                            pevent.Graphics.FillRectangle(lgb, surfacerect);
                        else
                            pevent.Graphics.FillRectangle(sb,surfacerect);
                        pevent.Graphics.DrawRectangle(borderpen, 0, 0, borderrect.Width, borderrect.Height);
                        if (borderSize >= 1)
                            pevent.Graphics.DrawRectangle(borderpen, 0, 0, surfacerect.Width, surfacerect.Height);
                        redrawString(pevent);
                    }

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

        protected override void OnMouseLeave(EventArgs e)
        {
            if (HoverEnable) {
                GradientColor1 = defaultColor1;
                GradientColor2 = defaultColor2;
                Angle = defaultAngle;
                GradientEnable = true;

            }
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (HoverEnable) {
                defaultColor1 = GradientColor1;
                defaultColor2 = GradientColor2;
                defaultAngle = Angle;

                GradientColor1 = HoverColor1;
                GradientColor2 = HoverColor2;
                Angle = HoverAngle;
                GradientEnable = true;
            }
        }

        //prevent the buutoon resizing go out of the scope
        private void ModernButton_Resize(object sender, EventArgs e)
        {
            if (this.Height < borderRadius)
                borderRadius = this.Height;
            if (this.Width < borderRadius)
                borderRadius = this.Width;

        }
        //when back color changing
        private void ModernButton_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

    }
}
