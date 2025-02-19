
using System;
using System.Collections.Generic;
using System.Linq;

namespace Convert_Set_To_Sorted_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input unsorted hashSet
            Console.WriteLine("Enter the elements of the set:");
            HashSet<int> list = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
            //Sort the HashSet
            List<int> sortedList = ConvertToSortedList(list);
            //Display sorted HashSet
            foreach (int item in sortedList)
            {
                Console.Write(item+" ");
            }
        }
        //Method to covert a HashSet to Sorted List
        public static List<int> ConvertToSortedList(HashSet<int> list)
        {
            List<int> sorted = new List<int>(list);
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (sorted[j] > sorted[j + 1])
                    {
                        int temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            return sorted;
        }
    }
}
