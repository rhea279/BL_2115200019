using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    public static int FindLongestConsecutiveSequence(int[] nums)
    {
        if (nums.Length == 0) return 0;

        HashSet<int> numSet = new HashSet<int>(nums);
        int maxLength = 0;

        foreach (int num in numSet)
        {
            // Check if it's the start of a sequence
            if (!numSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentLength = 1;

                while (numSet.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentLength++;
                }

                maxLength = Math.Max(maxLength, currentLength);
            }
        }

        return maxLength;
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

        int result = FindLongestConsecutiveSequence(arr);
        Console.WriteLine($"Length of the longest consecutive sequence: {result}");
    }
}
