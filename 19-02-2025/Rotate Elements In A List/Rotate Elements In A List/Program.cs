using System;
using System.Collections.Generic;

namespace Rotate_Elements_In_A_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input the size of list
            Console.WriteLine("Enter the size of the list:");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> list = new List<int>();
            //Input the list
            Console.WriteLine($"Enter {n} elements of list");
            while (n > 0)
            {
                list.Add(Convert.ToInt32(Console.ReadLine()));
                n--;
            }
            //Input the position at which you want to rotate
            Console.WriteLine("Enter position at which you want to rotate:");
            int t= Convert.ToInt32(Console.ReadLine());
            //Rotate the list at the given position
            List<int> result = RotateList(list, t);
            foreach (int i in result)
                Console.WriteLine(i);

        }
        public static List<int> RotateList(List<int> list, int r)
        {
            List<int> result = new List<int>();
            for (int i = r ; i < list.Count; i++)
            {
                result.Add(list[i]);
            }
            for (int i = 0; i <= r-1; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
