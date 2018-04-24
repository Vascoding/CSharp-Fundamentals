using System;
using System.IO;

namespace Exercise
{
    public class OddLines
    {
        public static void PrintOddLines()
        {
            StreamReader reader = new StreamReader("../../Files/Odd.txt");

            using (reader)
            {
                for (int i = 0; i < reader.Read(); i++)
                {
                    string line = reader.ReadLine();
                    if (i % 2 != 0)
                    {
                        Console.WriteLine($"{line}");
                    }
                }
            }
        }
    }
}
