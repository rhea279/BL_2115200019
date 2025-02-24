using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Method_Invocation
{
    class MathOperations
    {
      public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;

        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperations mOpt = new MathOperations();
            Type type = typeof(MathOperations);
            Console.WriteLine("Available Methods: Add, Subtract,Multiply");
            Console.WriteLine("Enter method name:");
            string methodName = Console.ReadLine();
            MethodInfo method = type.GetMethod(methodName);
            if (method!= null)
            {
                Console.WriteLine("Enter first number:");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter second number:");
                int b = Convert.ToInt32(Console.ReadLine());

                object result = method.Invoke(mOpt, new Object[] { a, b });
                Console.WriteLine($"\nResult of {methodName}({a},{b})= {result}");
            }
            else
            {
                Console.WriteLine("\nError: Method not found");
            }
        }
    }
}
