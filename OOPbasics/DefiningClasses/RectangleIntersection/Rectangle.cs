namespace RectangleIntersection
{
    class Rectangle
    {
        private double x = 0;
        private double y = 0;
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public bool Intersect(Rectangle rectangle)
        {
            if (this.X + this.Width < rectangle.X || rectangle.X + rectangle.Width < this.X || this.Y + this.Height < rectangle.Y || rectangle.Y + rectangle.Height < this.Y)
            {
                return false;
            }
            return true;
        }
    }
}
