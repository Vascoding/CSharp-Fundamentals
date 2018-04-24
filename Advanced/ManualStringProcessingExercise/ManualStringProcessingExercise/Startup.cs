using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStringProcessingExercise
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Problem 1. Reverse String
            //ReverseString();

            // Problem 2. String Length
            //StringLength();


        }

        private static void StringLength()
        {
            var input = Console.ReadLine();
            if (input.Length < 20)
            {
                var result = input.PadRight(20, '*');
                Console.WriteLine(result);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(input);
                sb.Length = 20;
                Console.WriteLine(sb.ToString());
            }
        }

        private static void ReverseString()
        {
            var input = Console.ReadLine().ToCharArray();
            Array.Reverse(input);
            Console.WriteLine(input);
        }
    }
}
