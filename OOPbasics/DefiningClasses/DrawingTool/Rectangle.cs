namespace DrawingTool
{
    public class Rectangle : Figure
    {
        public Rectangle(int firstSide, int secondSide) :
            base(firstSide)
        {
            this.secondSide = secondSide;
        }
    }
}
