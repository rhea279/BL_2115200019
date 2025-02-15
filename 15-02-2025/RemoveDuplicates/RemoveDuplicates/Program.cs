using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //input original string
            Console.Write("Enter original string:");
            StringBuilder stringBuilder = new StringBuilder(Console.ReadLine());
            //Display string after removing duplicates
            Console.WriteLine("String after removing duplicates:" + RemoveDuplicates(stringBuilder));
        }
        //Method to remove duplicates
        public static StringBuilder RemoveDuplicates(StringBuilder str)
        {
           HashSet<char> seen = new HashSet<char>();
           StringBuilder result = new StringBuilder();
            foreach (char c in str.ToString())
            {
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    result.Append(c);
                }
            }
            return result;

        }
    }
}
