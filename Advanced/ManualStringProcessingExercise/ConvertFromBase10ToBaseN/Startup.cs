using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class ConvertFromBase10toBaseN
{
    static void Main(string[] args)
    {
        List<BigInteger> nums = new List<BigInteger>();

        nums = Console.ReadLine().Split().Select(BigInteger.Parse).ToList();
        int n = (int)nums[0];
        BigInteger num10 = nums[1];
        BigInteger remainder = 0;
        string result = string.Empty;
        if (n >= 2 && n <= num10)
        {
            while (num10 > 0)
            {
                remainder = num10 % n;
                num10 /= n;

                result = remainder.ToString() + result;
            }
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
