

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Union_Intersection_Of_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the elements of Set 1 (space separated):");
            IEnumerable<int> set1 = Console.ReadLine().Split().Select(int.Parse);
            Console.WriteLine("Enter the elements of Set 2 (space separated):");
            IEnumerable<int> set2 = Console.ReadLine().Split().Select(int.Parse);
            IEnumerable<int> symmetricDifference = SymmetricDifference(set1,set2);
            Console.WriteLine("Symmetric Difference: { " + string.Join(", ", symmetricDifference) + " }");
        }
        public static IEnumerable<int> SymmetricDifference(IEnumerable<int> set1, IEnumerable<int> set2)
        {
            return set1.Except(set2).Concat(set2.Except(set1));
        }

    }
}
