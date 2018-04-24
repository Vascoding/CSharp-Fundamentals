using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
    {
        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] {});

        sb.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (FieldInfo fieldInfo in fields.Where(f => namesOfFields.Contains(f.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }
        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public); 
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        ew5/
        foreach (var fieldInfo in fieldsInfo)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }
        foreach (var nonPublicMethod in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
        }
        foreach (var publicMethod in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var methodInfo in methodsInfo)
        {
            sb.AppendLine($"{methodInfo.Name}");
        }
        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();
        foreach (var m in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{m.Name} will return {m.ReturnType}");
        }
        foreach (var m in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{m.Name} will set field of {m.GetParameters().FirstOrDefault().ParameterType}");
        }
        return sb.ToString().Trim();
    }
}
