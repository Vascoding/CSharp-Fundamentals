using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            Type classType = typeof(BlackBoxInt);
            ConstructorInfo constructor = classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(int) }, null);
            BlackBoxInt boxInt = (BlackBoxInt)constructor.Invoke(new object[] { 0 });
            while (true)
            {
                var inputCommands = Console.ReadLine().Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                switch (inputCommands[0])
                {
                    case "Add":
                    case "Subtract":
                    case "Divide":
                    case "Multiply":
                    case "RightShift":
                    case "LeftShift":
                        Console.WriteLine(ExecuteMethod(boxInt, inputCommands[0], int.Parse(inputCommands[1])));
                        break;
                    case "END":
                        return;
                }
            }
        }
        private static int ExecuteMethod(BlackBoxInt boxInt, string inputCommand, int num)
        {
            MethodInfo method = boxInt.GetType().GetMethod(inputCommand, BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(boxInt, new object[] { num });
            FieldInfo value = boxInt.GetType().GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            return (int)value.GetValue(boxInt);
        }
    }
}
