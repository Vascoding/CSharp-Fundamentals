using System;

namespace EventImplementation
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var widht = (4 * n) + 1;
            var height = (2 * n) + 1;
            Console.WriteLine(new string('#', 4 * n + 1));
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', 1 + i), new string('#', (4 * n - 2) / 2 - 2 * i), new string(' ', 1 + 2 * i));
            }
            if (n % 2 != 0)
            {
                Console.WriteLine("{0}{1}{2}(@){2}{1}{0}", new string('.', n - 2), new string('#', n), new string(' ', 1));
                for (int k = 0; k < n / 2; k++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n - 1 + k), new string('#', n - 2 - k * 2), new string(' ', n + 2 + 2 * k));
                }
            }

            else
            {
                var points = n - 1;
                var hashtag = n - 1;
                var spaces = (n / 2)-1;
                Console.WriteLine("{0}{1}{2}(@){2}{1}{0}", new string('.', points), new string('#', hashtag), new string(' ', spaces));
                for (int l = 0; l < n / 2 - 1; l++)
                {
                    points++;
                    hashtag -=2 ;
                    spaces = (n * n + 1) - (points * 2) - hashtag;
                    Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', points), new string('#', hashtag), new string(' ', spaces));
                }
            }
            for (int m = 0; m < n; m++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', n + 1 + m), new string('#', 4 * n + 1 - 2 * n - 2 - 2 * m));
            }

        }
    }
}
