using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of list:");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of list:");
            List<int> list = new List<int>();
            while (size > 0)
            {
                list.Add(Convert.ToInt32(Console.ReadLine()));
                size--;
            }
            List<int> result = RemoveDuplicate(list);
            Console.WriteLine("\nList after removing duplicates:");
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static List<int> RemoveDuplicate(List<int> list)
        {
            List<int> result = new List<int>();
            foreach(int item in list)
            {
                if(!result.Contains(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
