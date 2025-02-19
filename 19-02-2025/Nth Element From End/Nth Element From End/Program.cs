using System;
using System.Collections.Generic;


namespace Nth_Element_From_End
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enter the sizee of list
            Console.WriteLine("Enter size of list:");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of list:");
            LinkedList<char> linkedList = new LinkedList<char>();
            //Enter the elements of list
            while (size > 0)
            {
                linkedList.AddLast(Convert.ToChar(Console.ReadLine()));
                size--;
            }
            Console.WriteLine("Enter the value of N:");
            int n = int.Parse(Console.ReadLine());
            char result = FindNthFromEnd(linkedList, n);
            Console.WriteLine("Nth element from the end: " + result);
        }
        //Method to find the Nth Element from last
        public static char FindNthFromEnd(LinkedList<char> list,int n)
        {
            LinkedListNode<char> first = list.First;
            LinkedListNode<char> second = list.First;
            for (int i = 0; i < n; i++)
            {
                if (first == null)
                    throw new ArgumentException("N is larger than list size");
                first = first.Next;
            }
            while (first != null)
            {
                first = first.Next;
                second = second.Next;
            }
            return second.Value;
        }
    }
}
