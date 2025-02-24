using System;
using System.Reflection;

//  Define the Custom Todo Attribute
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

//  Apply the Todo Attribute to Methods
public class ProjectTasks
{
    [Todo("Implement authentication", "Alice", "HIGH")]
    public void AuthenticationModule()
    {
        Console.WriteLine("Executing Authentication Module...");
    }

    [Todo("Optimize database queries", "Bob", "MEDIUM")]
    public void DatabaseOptimization()
    {
        Console.WriteLine("Executing Database Optimization...");
    }

    [Todo("Enhance UI/UX", "Charlie", "LOW")]
    public void ImproveUIUX()
    {
        Console.WriteLine("Executing UI/UX Improvements...");
    }
}
// Use Reflection to Retrieve and Print Pending Tasks
class Program
{
    static void Main()
    {
        Type type = typeof(ProjectTasks);
        MethodInfo[] methods = type.GetMethods();

        Console.WriteLine("Pending Tasks:");
        foreach (var method in methods)
        {
            var todoAttribute = method.GetCustomAttribute<TodoAttribute>();
            if (todoAttribute != null)
            {
                Console.WriteLine($"Method: {method.Name}, Task: {todoAttribute.Task}, Assigned To: {todoAttribute.AssignedTo}, Priority: {todoAttribute.Priority}");
            }
        }
    }
}