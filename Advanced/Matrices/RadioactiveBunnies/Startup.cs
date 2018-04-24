using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunnies
{
    class Startup
    {
        static int[] playerPosition = new int[2];
        static bool gameOverWon = false;
        static bool gameOverDead = false;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowIndex = input[0];
            int colIndex = input[1];
            char[][] matrix = new char[rowIndex][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
            var commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'U')
                {
                    Move(matrix, 'U');
                    if (gameOverWon || gameOverDead)
                    {
                        break;
                    }
                }
                if (commands[i] == 'R')
                {
                    Move(matrix, 'R');
                    if (gameOverWon || gameOverDead)
                    {
                        break;
                    }
                }
                if (commands[i] == 'L')
                {
                    Move(matrix, 'L');
                    if (gameOverWon || gameOverDead)
                    {
                        break;
                    }
                }
                if (commands[i] == 'D')
                {
                    Move(matrix, 'D');
                    if (gameOverWon || gameOverDead)
                    {
                        break;
                    }
                }
            }
            if (gameOverWon)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.WriteLine(string.Join("", matrix[row]));
                }
                Console.WriteLine($"won: {string.Join(" ", playerPosition)}");
            }
            if (gameOverDead)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.WriteLine(string.Join("", matrix[row]));
                }
                Console.WriteLine($"dead: {string.Join(" ", playerPosition)}");
            }
        }

        private static void Move(char[][] matrix, char direction)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        for (int r = Math.Max(0, row - 1); r <= Math.Min(row + 1, matrix.Length - 1); r++)
                        {
                            for (int c = Math.Max(0, col - 1); c <= Math.Min(col + 1, matrix[0].Length - 1); c++)
                            {
                                double distanceToBunny = Math.Sqrt(Math.Pow(row - r, 2) + Math.Pow(col - c, 2));
                                if (distanceToBunny == 1)
                                {
                                    if (matrix[r][c] == 'P')
                                    {
                                        gameOverDead = true;
                                        playerPosition = new int[2] { r, c };
                                        matrix[r][c] = 'b';
                                    }
                                    else if (matrix[r][c] == '.')
                                    {
                                        matrix[r][c] = 'b';
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int row = 0; row < matrix.Length; row++)
                for (int col = 0; col < matrix[0].Length; col++)
                    if (matrix[row][col] == 'b')
                        matrix[row][col] = 'B';

            if (direction == 'U')
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            var playerIndex = row - 1;
                            if (playerIndex < 0)
                            {
                                gameOverWon = true;
                                //playerPosition = new int[2] { row, col };
                                break;
                            }

                            matrix[row][col] = '.';
                            matrix[playerIndex][col] = 'P';
                            break;
                        }
                    }
                }
            }

            if (direction == 'R')
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            var playerIndex = col + 1;
                            if (playerIndex > matrix[row].Length)
                            {
                                gameOverWon = true;
                                //playerPosition = new int[2] { row, col };
                                break;
                            }

                            matrix[row][col] = '.';
                            matrix[playerIndex][col] = 'P';
                            break;
                        }
                    }
                }
            }

            if (direction == 'L')
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            var playerIndex = col - 1;
                            if (playerIndex < 0)
                            {
                                gameOverWon = true;
                                //playerPosition = new int[2] { row, col };
                                break;
                            }

                            matrix[row][col] = '.';
                            matrix[playerIndex][col] = 'P';
                            break;
                        }
                    }
                }
            }

            if (direction == 'D')
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            var playerIndex = row + 1;
                            if (playerIndex > matrix.Length)
                            {
                                gameOverWon = true;
                                //playerPosition = new int[2] { row, col };
                                break;
                            }

                            matrix[row][col] = '.';
                            matrix[playerIndex][col] = 'P';
                            break;
                        }
                    }
                }
            }
        }
    }
}
