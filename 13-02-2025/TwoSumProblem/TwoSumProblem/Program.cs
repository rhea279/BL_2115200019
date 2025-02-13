using System;
using System.Collections.Generic;

class TwoSumProblem
{
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i }; // Return indices
            }

            if (!map.ContainsKey(nums[i])) // Avoid overwriting duplicate keys
            {
                map[nums[i]] = i;
            }
        }

        return new int[] { -1, -1 }; // No solution found
    }

    public static void Main()
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

        int[] result = TwoSum(arr, target);
        if (result[0] != -1)
            Console.WriteLine($"Indices found: {result[0]}, {result[1]}");
        else
            Console.WriteLine("No valid pair found.");
    }
}
