using System;
using System.Text.RegularExpressions;

namespace CubicMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Over!"))
                {
                    break;
                }
                Regex regex = new Regex("^\\d+[a-zA-Z]+[^a-zA-Z]*$");
                var num = int.Parse(Console.ReadLine());
                var nums = "";
                var text = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        nums += input[i];
                    }
                    if (char.IsLetter(input[i]))
                    {
                        text += input[i];
                    }
                }
                var message = "";
                for (int i = 0; i < nums.Length; i++)
                {
                    var index = int.Parse(nums[i].ToString());
                    if (index >= text.Length)
                    {
                        message += " ";
                    }
                    else
                    {
                        message += text[index];
                    }
                }
                if (regex.IsMatch(input) && num == text.Length)
                {
                    Console.WriteLine($"{text} == {message}");
                }
            }
        }
    }
}
