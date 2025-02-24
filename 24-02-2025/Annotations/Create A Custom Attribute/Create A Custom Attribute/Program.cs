
using System;
using System.Reflection;

namespace Create_A_Custom_Attribute
{
    [AttributeUsage(AttributeTargets.Method,Inherited =false)]
    public class TaskInfoAttribute : Attribute
    {
        public int Priority { get; }
        public string AssignedTo { get; }
        public TaskInfoAttribute(int priority, string assignedTo)
        {
            Priority = priority;
            AssignedTo = assignedTo;
        }
    }
    
    class TaskManager
    {
        [TaskInfo(1,"Rhea Lather")]
        public void CompleteTask()
        {
            Console.WriteLine("Task Completed Successfully!");
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TaskManager);
            foreach(MethodInfo method in type.GetMethods())
            {
                if(method.GetCustomAttribute(typeof(TaskInfoAttribute)) is TaskInfoAttribute taskInfo)
                {
                    Console.WriteLine($"Method: {method.Name}");
                    Console.WriteLine($"Priority: {taskInfo.Priority}");
                    Console.WriteLine($"Assigned To: {taskInfo.AssignedTo}");
                    Console.WriteLine();
                }
            }
            TaskManager manager = new TaskManager();
            manager.CompleteTask();
        }
    }
        
}
