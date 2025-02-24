
using System;
using System.Diagnostics;
using System.Reflection;

namespace Logging_Method_Execution_Time
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LogExecutionTimeAttribute : Attribute { }
    public class ExecutionTimer
    {
        public static void MeasureTime(object obj, string methodName)
        {
            MethodInfo method = obj.GetType().GetMethod(methodName);
            if(method == null)
            {
                Console.WriteLine($"Method {methodName} not found");
                return;
            }
            if(method.GetCustomAttribute(typeof(LogExecutionTimeAttribute))==null)
            {
                Console.WriteLine($"Method {methodName} is not marked with [LogExecutionTime]");
                return;
            }
            Stopwatch sw = Stopwatch.StartNew();
            method.Invoke(obj, null);
            sw.Stop();
            Console.WriteLine($"Execution Time for {methodName} : {sw.ElapsedMilliseconds} ms");
        }
    }
    public class SampleClass
    {
        [LogExecutionTime]
        public void FastMethod()
        {
            for (int i = 0; i < 1000; i++) { }
        }
        [LogExecutionTime]
        public void SlowMethod()
        {
            for(int i = 0; i < 10000000; i++) { }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SampleClass obj = new SampleClass();
            ExecutionTimer.MeasureTime(obj, "FastMethod");
            ExecutionTimer.MeasureTime(obj, "SlowMethod");
        }
    }
}
