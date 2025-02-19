using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_Are_Equal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the elements of Set 1 (space separated):");
            ISet<int> set1 = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine("Enter the elements of Set 2 (space separated):");
            ISet<int> set2 = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
            bool result = IsSame(set1, set2);
            Console.WriteLine($"Are Set1 And Set2 Equals? {result}");

        }
        public static bool IsSame(ISet<int> set1, ISet<int> set2)
        {
            if(set1 == null || set2 == null) return false;
            if (set1 == null && set2 == null) return true;

            return set1.Count == set2.Count && set1.All(set2.Contains);
        }
    }
}
