using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : IBrowseable, ICallable
    {
        public string Call(string phoneNumber)
        {

            if (phoneNumber.Any(ch => char.IsLetter(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string website)
        {
            if (website.Any(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}!";
        }
    }
}