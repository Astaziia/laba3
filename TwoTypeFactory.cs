namespace laba_2
{
    public class TwoTypeFactory : IGraphicFactory
    {
        private bool nextIsRectangle = true;

        public GraphObject CreateGraphObject()
        {
            GraphObject obj;
            if (nextIsRectangle)
                obj = new Rectangle();
            else
                obj = new Ellipse();

            nextIsRectangle = !nextIsRectangle;
            return obj;
        }
    }
}