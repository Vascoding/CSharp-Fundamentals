using System;

namespace DrawingTool
{
    public abstract class Figure
    {
        protected int firstSide;
        protected int secondSide;

        public Figure(int firstSide)
        {
            this.firstSide = firstSide;
            this.secondSide = firstSide;
        }

        public void Draw()
        {
            string topAndBotRow = "|" + new string('-', this.firstSide) + "|";

            Console.WriteLine(topAndBotRow);
            for (int row = 0; row < this.secondSide - 2; row++)
            {
                Console.WriteLine("|" + new string(' ', this.firstSide) + "|");
            }

            Console.WriteLine(topAndBotRow);
        }
    }
}



