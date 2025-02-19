
using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the subset :");
            HashSet<int> subset = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine("Enter the superset :");
            HashSet<int> superset = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
            bool checkSubset = IsSubset(subset,superset);
            Console.WriteLine("Is subset?" + checkSubset);

        }
        public static bool IsSubset(HashSet<int> subset,HashSet<int> superset)
        {
            foreach (int i in subset) {
                if (!superset.Contains(i))
                    return false;
            }
            return true;
        }

    }
}
