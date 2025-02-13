using System;
using System.Collections.Generic;

namespace FindPairWithSum
{
    class FindPairWithSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter element {i + 1}:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter the target sum:");
            int target = Convert.ToInt32(Console.ReadLine());

            if (!PairWithSum(arr, target))
            {
                Console.WriteLine("No pair found with the given sum.");
            }
        }
        public static bool PairWithSum(int[] nums, int target)
        {
            HashSet<int> seenNumbers = new HashSet<int>();

            foreach (int number in nums)
            {
                int complement = target - number;
                if (seenNumbers.Contains(complement))
                {
                    Console.WriteLine($"Pair found: ({complement}, {number})");
                    return true;
                }
                seenNumbers.Add(number);
            }
            return false;
        }
    }
}
