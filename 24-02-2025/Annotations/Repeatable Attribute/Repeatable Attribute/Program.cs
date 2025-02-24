using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repeatable_Attribute
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; }
        public BugReportAttribute(string description)
        {
            Description = description;
        }
    }
    class SoftwareModule
    {
        [BugReport("Null Reference exception in edge cases.")]
        [BugReport("Performance issue when handling large datasets")]
        public void ProcessData()
        {
            Console.WriteLine("Processing Data..");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(SoftwareModule);
            foreach(MethodInfo method in type.GetMethods())
            {
                var bugReports = method.GetCustomAttributes<BugReportAttribute>();
                foreach(var bug in bugReports)
                {
                    Console.WriteLine($"Method:{method.Name}");
                    Console.WriteLine($"Bug Report:{bug.Description}");
                    Console.WriteLine();
                }
            }
            SoftwareModule module = new SoftwareModule();
            module.ProcessData();
        }
    }
}
