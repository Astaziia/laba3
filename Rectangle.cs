using System;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace laba_2
{
    public class Rectangle : GraphObject
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private int width = 30;
        private int height = 50;
=======
        private int width = 80;
        private int height = 80;
>>>>>>> e7777d65fed5849245664aed9dc52bb090600a88
=======
        private int width = 80;
        private int height = 80;
>>>>>>> e7777d65fed5849245664aed9dc52bb090600a88

        public Rectangle() : base()
        {
            width = r.Next(30, 80);
            height = r.Next(30, 80);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(Pens.Black, x, y, width, height);

            if (Selected)
            {
                g.DrawRectangle(selectedPen, x - 2, y - 2, width + 4, height + 4);
            }
        }

        public override bool ContainsPoint(Point p)
        {
            return p.X >= x && p.X <= x + width &&
                   p.Y >= y && p.Y <= y + height;
        }

        public override int GetWidth() => width;
        public override int GetHeight() => height;
    }
}