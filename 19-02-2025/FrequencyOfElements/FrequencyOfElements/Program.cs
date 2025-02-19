using System;
using System.Collections.Generic;

namespace FrequencyOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input size of list
            Console.WriteLine("Enter size of list:");
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> list = new List<string>();
            //Input the strings in list
            while (n != 0)
            {
                Console.WriteLine("Enter list item:");
                list.Add(Console.ReadLine());
                n--;
            }
            //Find countof each element in the list
            Dictionary<string, int> result = FrequencyCount(list);
            Console.WriteLine("\nFrequency of each element:");
            //Display the count of each element in the list
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }
        //Method to count the frequency of each element in the list
        public static Dictionary<string,int> FrequencyCount(List<string> list) {
          
            Dictionary<string,int> count = new Dictionary<string,int>();
            foreach (string s in list)
            {

                if (count.ContainsKey(s))
                {
                    count[s]++;
                }
                else
                {
                    count.Add(s, 1);
                }
            }
            return count;
        }
    }
}
