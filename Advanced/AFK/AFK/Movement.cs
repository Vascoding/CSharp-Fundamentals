using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFK
{
    public class Movement
    {
        const ConsoleColor HERO_COLOR = ConsoleColor.DarkBlue;
        public static Coordinate Snake { get; set; }
        const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Cyan;
        public static void MoveHero(int x, int y)
        {
            
            Coordinate newSnake = new Coordinate()
            {
                X = Snake.X + x,
                Y = Snake.Y + y
            };

            if (CanMove(newSnake))
            {
                RemoveHero(Snake);
                Console.BackgroundColor = HERO_COLOR;
                Console.SetCursorPosition(newSnake.X, newSnake.Y);
                Console.Write(" ");
                Snake = newSnake;
            }
        }
        public static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;
            if (c.Y < 0 || c.Y >= Console.WindowHeight)
                return false;

            return true;
        }
        public static void RemoveHero(Coordinate Snake)
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.SetCursorPosition(Snake.X, Snake.Y);
            Console.Write(" ");
        }
    }
}
