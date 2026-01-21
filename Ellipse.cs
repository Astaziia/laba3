using System;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace laba_2
{
    public class Ellipse : GraphObject
    {
        private int width = 60;
        private int height = 60;

        public Ellipse() : base()
        {
            width = r.Next(30, 80);
            height = r.Next(30, 80);
        }


        public override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, width, height);
            g.DrawEllipse(Pens.Blue, x, y, width, height);

            if (Selected)
            {
                g.DrawEllipse(selectedPen, x - 2, y - 2, width + 4, height + 4);
            }
        }

        public override bool ContainsPoint(Point p)
        {
            double cx = x + width / 2.0;
            double cy = y + height / 2.0;
            double a = width / 2.0;
            double b = height / 2.0;

            double dx = p.X - cx;
            double dy = p.Y - cy;

            return (dx * dx) / (a * a) + (dy * dy) / (b * b) <= 1;
        }

        public override int GetWidth() => width;
        public override int GetHeight() => height;
    }
}