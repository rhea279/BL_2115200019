using System;
using System.Diagnostics;
using System.Text;

namespace CompareStringPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Comparison: `string` vs `StringBuilder`\n");

            int[] datasetSizes = { 1000, 10000, 1000000 };

            foreach (int size in datasetSizes)
                MeasurePerformance(size);
        }

        static void MeasurePerformance(int size)
        {
            Console.WriteLine($"Operations Count : {size}");

            // Measure `string` concatenation time (O(N²))
            Stopwatch sw = Stopwatch.StartNew();
            ConcatenateString(size);
            sw.Stop();
            Console.WriteLine($"String  Time: {sw.ElapsedMilliseconds} ms");

            // Restart stopwatch before measuring StringBuilder performance (O(N))
            sw.Restart();
            ConcatenateStringBuilder(size);
            sw.Stop();
            Console.WriteLine($"StringBuilder Time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("--------------------------------------");
        }

        // String concatenation (O(N²)) - Inefficient
        public static string ConcatenateString(int iterations)
        {
            string result = "";
            for (int i = 0; i < iterations; i++)
            {
                result += "A";  // Creates a new string in memory on each iteration
            }
            return result;
        }

        // StringBuilder concatenation (O(N)) - Efficient
        public static string ConcatenateStringBuilder(int iterations)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                str.Append("A"); // Appends to the existing buffer
            }
            return str.ToString();
        }
    }
}
