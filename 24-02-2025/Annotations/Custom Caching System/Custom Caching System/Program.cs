using System;
using System.Collections.Generic;
using System.Reflection;

namespace Custom_Caching_System
{
    // Define the Custom Attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute { }

    // Create a CacheManager
    public static class CacheManager
    {
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        public static object GetOrAddCache(string key, Func<object> computeFunc)
        {
            if (cache.ContainsKey(key))
            {
                Console.WriteLine($"Returning cached result for: {key}");
                return cache[key];
            }

            Console.WriteLine($"Computing result for: {key}");
            object result = computeFunc();
            cache[key] = result;
            return result;
        }
    }

    // Implement Expensive Computation Class
    public class ExpensiveComputation
    {
        [CacheResult]
        public int ComputeFactorial(int n)
        {
            return (int)CacheManager.GetOrAddCache($"Factorial({n})", () => Factorial(n));
        }

        private int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }

    // Test the Caching System
    class Program
    {
        static void Main(string[] args)
        {
            ExpensiveComputation computation = new ExpensiveComputation();

            Console.WriteLine("\nFirst Computation:");
            Console.WriteLine($"Factorial(5) = {computation.ComputeFactorial(5)}");

            Console.WriteLine("\nSecond Computation (Should Use Cache):");
            Console.WriteLine($"Factorial(5) = {computation.ComputeFactorial(5)}");

            Console.WriteLine("\nComputing a New Value:");
            Console.WriteLine($"Factorial(6) = {computation.ComputeFactorial(6)}");
        }
    }
}
