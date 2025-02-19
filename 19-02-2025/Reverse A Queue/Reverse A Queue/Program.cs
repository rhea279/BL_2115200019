
using System;
using System.Collections.Generic;

namespace Reverse_A_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Enter the items of queue (space-separated):");
            string[] input = Console.ReadLine().Split();
            foreach (string s in input)
            {
                queue.Enqueue(int.Parse(s));
            }
            Console.WriteLine("Original Queue:"+string.Join(",", queue));
            queue = ReverseQueue(queue);
            Console.WriteLine("Reversed Queue:"+string.Join(",", queue));
        }
        static Queue<int> ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }
    }
}
