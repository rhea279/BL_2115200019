
using System;
using System.Reflection;

namespace Invoke_Private_Method
{
    class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Type type = typeof(Calculator);
            MethodInfo multiplyMethod = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
            if (multiplyMethod != null)
            {
                Console.WriteLine("Enter first integer:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second integer:");
                int b = Convert.ToInt32(Console.ReadLine());
                object result = multiplyMethod.Invoke(calculator, new object[] { a, b });
                Console.WriteLine($"Private Method Multiply: {result}" );
            }
            else
            {
                Console.WriteLine("Cannot Access Private Method");
            }
        }
    }
}
