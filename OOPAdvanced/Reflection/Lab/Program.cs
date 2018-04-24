using System;
using System.Globalization;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            var spy = new Spy();
            //var result = spy.StealFieldInfo("Hacker", "username", "password");
            //var result = spy.AnalyzeAcessModifiers("Hacker");
            //var result = spy.RevealPrivateMethods("Hacker");
            var result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
