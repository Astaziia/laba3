using System;

namespace laba_2
{
    public class RandomObjectFactory : IGraphicFactory
    {
        private static Random rnd = new Random();

        public GraphObject CreateGraphObject()
        {
            if (rnd.Next(2) == 0)
                return new Rectangle();
            else
                return new Ellipse();
        }
    }
}