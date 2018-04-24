using System;
using AFK;

namespace MaffeluDemo

{
    public class Program
    {
        const ConsoleColor HERO_COLOR = ConsoleColor.DarkBlue;

        const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Cyan;
        public static Coordinate Snake { get; set; } //Will represent our here that's moving around :P/>
        static void Main(string[] args)
        {
            InitGame();
            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Movement.MoveHero( 0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        Movement.MoveHero( 1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        Movement.MoveHero( 0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Movement.MoveHero(-1, 0);
                        break;
                }
            }
        }
        /// <summary>

        /// Paint the new hero

        /// </summary>

        
        
        /// <summary>
    
        /// Overpaint the old hero

        /// </summary>
        
        /// <summary>

        /// Make sure that the new coordinate is not placed outside the

        /// console window (since that will cause a runtime crash

        /// </summary>

        
        /// <summary>
        /// Paint a background color

        /// </summary>

        /// <remarks>

        /// It is very important that you run the Clear() method after

        /// changing the background color since this causes a repaint of the background

        /// </remarks>

        static void SetBackgroundColor()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.Clear(); //Important!
        }
        /// <summary>

        /// Initiates the game by painting the background

        /// and initiating the hero

        /// </summary>

        static void InitGame()
        {
            SetBackgroundColor();
            Snake = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            //MoveHero(0, 0);
        }
    }
    /// <summary>

    /// Represents a map coordinate

    /// </summary>

    
}
