using System;
using System.Diagnostics;

namespace RecursiveVsIterative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Comparison of Recursion and Iteration\n");

            int[] datasetSizes = { 10, 30, 50 };

            foreach (int size in datasetSizes)
                MeasurePerformance(size);
        }

        static void MeasurePerformance(int n)
        {
    
            // Measure Recursive Fibonacci time
            Stopwatch sw = Stopwatch.StartNew();
            RecursiveFibonacci(n);
            sw.Stop();
            long recursiveTime = sw.ElapsedMilliseconds;

            // Measure Iterative Fibonacci time
            sw.Restart();
            IterativeFibonacci(n);
            sw.Stop();
            long iterativeTime = sw.ElapsedMilliseconds;

            // Display results
            Console.WriteLine($"Dataset Size: {n}");
            Console.WriteLine($"Recursive Fibonacci Time: {recursiveTime} ms");
            Console.WriteLine($"Iterative Fibonacci Time: {iterativeTime} ms");
            Console.WriteLine("--------------------------------------");
        }

        public static int RecursiveFibonacci(int n)
        {
            if (n <= 1) return n;
            return RecursiveFibonacci(n-1)+RecursiveFibonacci(n-2);
        }
        public static int IterativeFibonacci(int n)
        {
            int a = 0, b = 1, sum;
            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }
    }
}
