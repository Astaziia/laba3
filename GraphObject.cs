using System;
using System.Drawing;

namespace laba_2
{
    public abstract class GraphObject
    {
        protected static Random r = new Random();
        public static Size MaxSize { get; set; }

        protected int x, y;
        protected Color color;
        protected Brush brush;
        protected Pen selectedPen = new Pen(Color.Black, 2);

        public bool Selected { get; set; }

        protected GraphObject()
        {
            Color[] cols = { Color.Pink, Color.DeepPink, Color.Violet, color.HotPink};
            color = cols[r.Next(cols.Length)];
            brush = new SolidBrush(color);

            // Случайные координаты
            x = r.Next(50, 400);
            y = r.Next(50, 250);
        }

        public int X
        {
            get { return x; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("x < 0!");
                if (MaxSize.Width > 0 && value + GetWidth() > MaxSize.Width)
                    throw new ArgumentException("x выходит за границы!");
                x = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("y < 0!");
                if (MaxSize.Height > 0 && value + GetHeight() > MaxSize.Height)
                    throw new ArgumentException("y выходит за границы!");
                y = value;
            }
        }

        public abstract void Draw(Graphics g);
        public abstract bool ContainsPoint(Point p);
        public abstract int GetWidth();
        public abstract int GetHeight();
    }
}