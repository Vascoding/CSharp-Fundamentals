using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
    using System;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var inputCommand = Console.ReadLine();
                switch (inputCommand)
                {
                    case "private":
                        Console.WriteLine(PrintPrivateFields());
                        break;
                    case "protected":
                        Console.WriteLine(PrintProtectedFields());
                        break;
                    case "public":
                        Console.WriteLine(PrintPublicFields());
                        break;
                    case "all":
                        Console.WriteLine(PrintAllFields());
                        break;
                    case "HARVEST":
                        return;
                }
            }
        }

        private static string PrintAllFields()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] privateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo privateField in privateFields)
            {
                if (privateField.IsPrivate)
                {
                    sb.AppendLine($"private {privateField.FieldType.Name} {privateField.Name}");
                }
                if (privateField.IsFamily)
                {
                    sb.AppendLine($"protected {privateField.FieldType.Name} {privateField.Name}");
                }
                if (privateField.IsPublic)
                {
                    sb.AppendLine($"public {privateField.FieldType.Name} {privateField.Name}");
                }
                
            }
            return sb.ToString().Trim();
        }

        private static string PrintPublicFields()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] privateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo privateField in privateFields.Where(f => f.IsPublic))
            {
                sb.AppendLine($"public {privateField.FieldType.Name} {privateField.Name}");
            }
            return sb.ToString().Trim();
        }

        private static string PrintProtectedFields()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] privateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo privateField in privateFields.Where(f => f.IsFamily))
            {
                sb.AppendLine($"protected {privateField.FieldType.Name} {privateField.Name}");
            }
            return sb.ToString().Trim();
        }

        private static string PrintPrivateFields()
        {
            Type classType = typeof(HarvestingFields);
            
            FieldInfo[] privateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo privateField in privateFields.Where(f => f.IsPrivate))
            {
                sb.AppendLine($"private {privateField.FieldType.Name} {privateField.Name}");
            }
            return sb.ToString().Trim();
        }
    }
}
