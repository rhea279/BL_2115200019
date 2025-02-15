using System;
using System.Diagnostics;
using System.Text;

namespace ComparePerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 100000;

            // Measure string concatenation time
            Stopwatch sw1 = Stopwatch.StartNew();
            string result1 = ConcatenateString(iterations);
            sw1.Stop();
            Console.WriteLine("String Concatenation Time:"+sw1.ElapsedMilliseconds+"ms");

            // Measure StringBuilder concatenation time
            Stopwatch sw2 = Stopwatch.StartNew();
            string result2 = ConcatenateStringBuilder(iterations);
            sw2.Stop();
            Console.WriteLine("String Builder Concatenation Time:" + sw2.ElapsedMilliseconds + "ms");

        }
        // Method to concatenate using string 
        public static string ConcatenateString(int iterations)
        {
            string result = "";
            for (int i = 0; i < iterations; i++)
            {
                result += "String";
            }
            return result;
        }
        // Method to concatenate using StringBuilder
        public static string ConcatenateStringBuilder(int iterations)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < iterations; i++)
                str.Append("String");
            return str.ToString();
        }
    }
}
