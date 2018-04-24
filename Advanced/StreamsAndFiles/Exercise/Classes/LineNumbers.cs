using System.IO;

namespace Exercise
{
    public class LineNumbers
    {
        public static void ReadAndWrite()
        {
            StreamReader reader = new StreamReader("../../Files/Odd.txt");
            StreamWriter writer = new StreamWriter("../../Files/WriteNum.txt");

            using (reader)
            {
                using (writer)
                {
                    for (int i = 1; i <= reader.Read(); i++)
                    {
                        string line = $"{i} {reader.ReadLine()}";
                        writer.WriteLine($"{line}");
                    }
                }
            }
        }
    }
}
