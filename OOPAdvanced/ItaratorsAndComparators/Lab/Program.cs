
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

//public class Program
//{
//    public static void Main()
//    {
//        var priviteKey = Console.ReadLine();
//        var text = Console.ReadLine();
//        var structure = @"^TO: ([A-Z]+); MESSAGE: (.+);$";
//        var textToPrint = "";
//        var result = new Dictionary<string, List<string>>();

//        while (text != "END")
//        {
//            Regex r = new Regex(structure, RegexOptions.None);
//            Match m = r.Match(text);
//            if (r.IsMatch(text))
//            {
//                var addingText = TurningMessage(priviteKey, text, textToPrint);
//                var names = m.Groups[1].Value;
//                if (result.ContainsKey(names))
//                {
//                    result[names].Add(addingText);
//                }
//                else
//                {
//                    result.Add(names, new List<string>());
//                    result[names].Add(addingText);
//                }
//            };

//            textToPrint = "";

//            text = Console.ReadLine();
//        }
//        foreach (var message in result.OrderBy(a => a.Key))
//        {
//            foreach (var v in message.Value)
//            {
//                Console.WriteLine(v);
//            }
//        }
//    }
//    private static string TurningMessage(string priviteKey, string text, string textToPrint)
//    {
//        var j = 0;
//        for (int i = 0; i < text.Length; i++)
//        {
//            if (j == priviteKey.Length)
//            {
//                j = 0;
//            }
//            var symvol = priviteKey[j] - '0';
//            var newSymvol = (char)((char)text[i] + symvol);
//            textToPrint += newSymvol;
//            j++;
//        }
//        return textToPrint;
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

class Class
{
    private string clasName;
    private List<Method> methods;

    public Class(string className)
    {
        this.clasName = className;
    }

    public string ClassName
    {
        get { return clasName; }
        set { this.clasName = value; }
    }

    public List<Method> Methods
    {
        get { return methods; }
        set { this.methods = value; }
    }
}

class Method
{
    private string methodName;
    private List<string> tests;

    public Method(string methodName)
    {
        this.methodName = methodName;
    }

    public string MethodName
    {
        get { return methodName; }
        set { this.methodName = value; }
    }

    public List<string> Tests
    {
        get { return tests; }
        set { this.tests = value; }
    }
}

public class GUnit
{
    static string @class;
    static string method;
    static string test;

    static List<Class> classCollection = new List<Class>();

    public static void Main()
    {
        ReadNextLinesUntilTestingTimeFrom(Console.ReadLine());
        PrintAllClassesFromClassCollection();
    }

    static void PrintAllClassesFromClassCollection()
    {
        foreach (var item in classCollection
            .OrderByDescending(clas => clas.Methods.Sum(method => method.Tests.Count))
            .ThenBy(clas => clas.Methods.Count)
            .ThenBy(clas => clas.ClassName))
        {
            Console.WriteLine(item.ClassName + ":");

            foreach (var method in item.Methods
                .OrderByDescending(method => method.Tests.ToList().Count)
                .ThenBy(method => method.MethodName))
            {
                Console.WriteLine("##{0}", method.MethodName);

                foreach (var test in method.Tests
                    .OrderBy(test => test.Length)
                    .ThenBy(test => test))
                {
                    Console.WriteLine("####{0}", test);
                }
            }
        }
    }

    static void ReadNextLinesUntilTestingTimeFrom(string input)
    {
        if (input != "It's testing time!")
        {
            DivideAndRuleCurrent(input);
            ReadNextLinesUntilTestingTimeFrom(Console.ReadLine());
        }
        else return;
    }

    static void DivideAndRuleCurrent(string input)
    {
        var patern = new string[] { " | " };
        var splited = input.Split(patern, StringSplitOptions.RemoveEmptyEntries);
        if (isValidInput(splited))
        {
            @class = splited[0];
            method = splited[1];
            test = splited[2];

            AddOrUpdateToClassCollection();
        }
        else return;
    }

    static bool isValidInput(string[] splited)
    {
        var isValid = true;
        isValid = splited.Length == 3;
        if (!isValid)
        {
            return false;
        }
        foreach (var item in splited)
        {
            if (!isValid)
            {
                return false;
            }
            isValid = AreOnlyLetersAndDigits(item);
        }
        return isValid;
    }

    private static bool AreOnlyLetersAndDigits(string item)
    {
        return item.Length >= 2 &&
            (item[0] >= 'A' && item[0] <= 'Z') &&
            !item.Any(x => (x < 'a' || x > 'z') && (x < 'A' || x > 'Z') && (x < '0' || x > '9'));

    }

    static void AddOrUpdateToClassCollection()
    {
        if (!classCollection.Any(x => x.ClassName == @class))
        {
            var newMethod = new Method(method);
            newMethod.Tests = new List<string>();
            newMethod.Tests.Add(test);

            var newClass = new Class(@class);
            newClass.Methods = new List<Method>();
            newClass.Methods.Add(newMethod);

            classCollection.Add(newClass);
        }
        else UpdateCurrentClass();
    }

    static void UpdateCurrentClass()
    {
        var currentClass = classCollection.Where(x => x.ClassName == @class).FirstOrDefault();
        if (!currentClass.Methods.Any(x => x.MethodName == method))
        {
            var newMethod = new Method(method);
            newMethod.Tests = new List<string>();
            newMethod.Tests.Add(test);

            currentClass.Methods.Add(newMethod);
        }
        if (!currentClass.Methods.Where(x => x.MethodName == method).FirstOrDefault().Tests.Contains(test))
        {
            currentClass.Methods.Where(x => x.MethodName == method).FirstOrDefault().Tests.Add(test);
        }
        
    }
}