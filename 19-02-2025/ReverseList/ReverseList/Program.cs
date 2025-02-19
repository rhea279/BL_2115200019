using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace ReverseList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input ArrayList
            Console.WriteLine("Enter size of ArrayList:");
            int n = int.Parse(Console.ReadLine());
            ArrayList arrayList = new ArrayList();
            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                arrayList.Add(Console.ReadLine());
            }
            //Display original and Reversed ArrayList
            Console.WriteLine("Original ArrayList: " + string.Join(", ", arrayList.ToArray()));
            arrayList = ReverseArrayList(arrayList);
            Console.WriteLine("Reversed ArrayList: " + string.Join(", ", arrayList.ToArray()));

            //Input LinkedList 
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine("Enter size of LinkedList:");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter elements:");
            for (int i = 0; i < m; i++)
            {
                linkedList.AddLast(int.Parse(Console.ReadLine()));
            }
            //Display original and reversed LinkedList
            Console.WriteLine("Original LinkedList: " + string.Join(", ", linkedList));
            linkedList = ReverseLinkedList(linkedList);
            Console.WriteLine("Reversed LinkedList: " + string.Join(", ", linkedList));
        }
        //Method to reverse arrayList
        public static ArrayList ReverseArrayList(ArrayList list)
        {
            ArrayList result = new ArrayList();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                result.Add(list[i]);
            }
            return result;
        }
        //Method to reverse LinkedList
        public static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
        {
            LinkedList<int> result = new LinkedList<int>();
            foreach(int i in list)
                result.AddFirst(i);
            return result;
        }

    }
   
}
