using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}


public class SampleClass
{
    [ImportantMethod("HIGH")]
    public void CriticalOperation()
    {
        Console.WriteLine("Executing Critical Operation...");
    }

    [ImportantMethod("MEDIUM")]
    public void ImportantTask()
    {
        Console.WriteLine("Executing Important Task...");
    }

    public void RegularTask()
    {
        Console.WriteLine("Executing Regular Task...");
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(SampleClass);
        MethodInfo[] methods = type.GetMethods();

        Console.WriteLine("Important Methods:");
        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<ImportantMethodAttribute>();
            if (attribute != null)
            {
                Console.WriteLine($"Method: {method.Name}, Level: {attribute.Level}");
            }
        }
    }
}
