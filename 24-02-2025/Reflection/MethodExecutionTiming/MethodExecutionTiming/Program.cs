using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodExecutionTiming
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
ausing System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MethodExecutionTiming
{
    public class SampleMethods
    {
        public void QuickMethod()
        {
            Thread.Sleep(100); // Simulating quick execution
            Console.WriteLine("QuickMethod executed.");
        }

        public void SlowMethod()
        {
            Thread.Sleep(1000); // Simulating slow execution
            Console.WriteLine("SlowMethod executed.");
        }

        public void ComputeMethod()
        {
            double result = 0;
            for (int i = 0; i < 1000000; i++)
            {
                result += Math.Sqrt(i);
            }
            Console.WriteLine("ComputeMethod executed.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(SampleMethods);
            object instance = Activator.CreateInstance(type);

            Console.WriteLine("Available Methods:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                       .Where(m => m.DeclaringType == type)
                                       .ToArray();

            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            Console.Write("\nSelect a method to execute (Enter the number): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= methods.Length)
            {
                MethodInfo selectedMethod = methods[choice - 1];

                Stopwatch stopwatch = Stopwatch.StartNew();
                selectedMethod.Invoke(instance, null);
                stopwatch.Stop();

                Console.WriteLine($"\nExecution Time: {stopwatch.ElapsedMilliseconds} ms");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
    }
}
