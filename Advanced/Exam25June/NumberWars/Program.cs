using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var second = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool milionTurns = false;
            List<string> firstChar = new List<string>();
            List<string> secondChar = new List<string>();
            List<string> allCards = new List<string>();
            Queue<string> firstPlayer = new Queue<string>(first);
            Queue<string> secondPlayer = new Queue<string>(second);
            var turn = 0;
            while (true)
            {

                if (firstPlayer.Count == 0 || secondPlayer.Count == 0)
                {
                    break;
                }
                turn++;
                
                if (turn > 100000)
                {
                    milionTurns = true;
                    break;
                }
                var firstCard = firstPlayer.Dequeue();
                var secondCard = secondPlayer.Dequeue();
                Regex regex = new Regex("\\d+");
                var num = regex.Match(firstCard).ToString();
                var parseFirst = int.Parse(num);
                num = regex.Match(secondCard).ToString();
                var parseSecond = int.Parse(num);
                if (parseSecond > parseFirst)
                {
                    secondPlayer.Enqueue(secondCard);
                    secondPlayer.Enqueue(firstCard);
                    

                }
                if (parseFirst > parseSecond)
                {
                    firstPlayer.Enqueue(firstCard);
                    firstPlayer.Enqueue(secondCard);
                   
                    
                }
                if (parseSecond == parseFirst)
                {
                    while (true)
                    {
                        // turn++;
                        if (firstPlayer.Count == 0 || secondPlayer.Count == 0)
                        {
                            break;
                        }
                        if (firstPlayer.Count < 3 && secondPlayer.Count < 3)
                        {
                            Console.WriteLine($"Draw after {turn} turns");
                            return;
                        }
                        if (firstPlayer.Count < 3)
                        {
                            Console.WriteLine($"Second player wins after {turn} turns");
                            return;
                        }
                        if (secondPlayer.Count < 3)
                        {
                            Console.WriteLine($"First player wins after {turn} turns");
                            return;
                        }
                        
                        firstChar.Add(firstPlayer.Dequeue());
                        firstChar.Add(firstPlayer.Dequeue());
                        firstChar.Add(firstPlayer.Dequeue());
                        secondChar.Add(secondPlayer.Dequeue());
                        secondChar.Add(secondPlayer.Dequeue());
                        secondChar.Add(secondPlayer.Dequeue());

                        for (int i = 0; i < 3; i++)
                        {
                            allCards.Add(firstChar[i]);
                            allCards.Add(secondChar[i]);
                        }
                        var firstSum = 0;
                        var secondSum = 0;
                        foreach (var f in firstChar)
                        {
                            firstSum += f.ToLower()[f.Length - 1] - 96;
                        }
                        foreach (var s in secondChar)
                        {
                            secondSum += s.ToLower()[s.Length - 1] - 96;
                        }
                        var allSix = allCards.OrderByDescending(x => x, new SemiNumericComparer()).ThenByDescending(a => a).ToList();
                        if (firstSum > secondSum)
                        {
                            for (int i = 0; i < allSix.Count; i++)
                            {
                                firstPlayer.Enqueue(allSix[i]);
                            }
                            break;
                        }
                        if (firstSum < secondSum)
                        {
                            for (int i = 0; i < allSix.Count; i++)
                            {
                                secondPlayer.Enqueue(allSix[i]);
                            }
                            break;
                        }
                    }

                }
            }
            if (firstPlayer.Count == secondPlayer.Count)
            {
                Console.WriteLine($"Draw after {turn} turns");
                return;
            }

            if (firstPlayer.Count == 0)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
            }
            if (secondPlayer.Count == 0)
            {
                Console.WriteLine($"First player wins after {turn} turns");
            }
            if (milionTurns)
            {
                if (secondPlayer.Count > firstPlayer.Count)
                {
                    Console.WriteLine($"Second player wins after {turn - 1} turns");
                }
                else
                {
                    Console.WriteLine($"First player wins after {turn - 1} turns");
                }
            }
        }
    }

    public class SemiNumericComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if (IsNumeric(s1) && IsNumeric(s2))
            {
                if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
                if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
                if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
            }

            if (IsNumeric(s1) && !IsNumeric(s2))
                return -1;

            if (!IsNumeric(s1) && IsNumeric(s2))
                return 1;

            return string.Compare(s1, s2, true);
        }

        public static bool IsNumeric(object value)
        {
            try
            {
                int i = Convert.ToInt32(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
