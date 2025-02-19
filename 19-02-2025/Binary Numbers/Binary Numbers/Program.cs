using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            List<string> result = GenerateBinaryNumbers(n);
            Console.WriteLine("Binary Numbers: { " + string.Join(", ", result) + " }");
        }
        static List<string> GenerateBinaryNumbers(int n)
        {
            Queue<string> queue = new Queue<string>();
            List<string> result = new List<string>();
            queue.Enqueue("1");
            for (int i = 0; i < n; i++)
            {
                String current = queue.Dequeue();
                result.Add(current);

                queue.Enqueue(current + "0");
                queue.Enqueue(current + "1");
            }
            return result;
        }
    }
}
