using System;
using System.Collections.Generic;


namespace ZeroSumSubarrays
{
    class ZeroSumSubarrays
    {
        public static void FindZeroSumSubarray(int[] arr)
        {
            Dictionary  <int,List<int>> map = new Dictionary<int,List<int>>();
            int cumulativeSum = 0;

            map[0] = new List<int> { -1 };
            for (int i = 0; i < arr.Length; i++)
            {
                cumulativeSum += arr[i];
                if (map.ContainsKey(cumulativeSum))
                {
                    foreach (int startIndx in map[cumulativeSum])
                    {
                        Console.WriteLine($"Subarray found from index {startIndx +1} to{i}");
                    }
                }
                if (!map.ContainsKey(cumulativeSum))
                {
                    map[cumulativeSum] = new List<int>();
                }
                map[cumulativeSum].Add(i);
            }
        }
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

            Console.WriteLine("Zero sum subarrays:");
            FindZeroSumSubarray(arr);
        }
    }
}
