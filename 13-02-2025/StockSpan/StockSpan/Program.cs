using System;
using System.Collections.Generic;

namespace StockSpan
{
    class Program
    {
        public static int[] CalculateStockSpan(int[] prices)
        {
            int n = prices.Length;
            int[] span = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }
                span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());
                stack.Push(i);
            }
            return span;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length of array:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0;i < n; i++)
            {
                Console.WriteLine($"Enter {i + 1} element of array:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] span = CalculateStockSpan(arr);
            Console.WriteLine("Stock prices : "+string.Join(",", arr));
            Console.WriteLine("Stock span : "+string.Join (",", span));
        }
    }
}
