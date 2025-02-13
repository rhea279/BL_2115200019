using System;
using System.Collections.Generic;

namespace SlidingWindowMaximum
{
    class SlidingWindowMaximum
    {
        
        public static int[] CalculateMaximum(int[] nums, int k)
        {
            if(nums == null || nums.Length == 0) return new int[0];
            int n = nums.Length;
            int[] result = new int[n - k + 1];
            LinkedList<int> dequeue = new LinkedList<int>(); //store indices

            for (int i = 0; i < n; i++)
            {
                // Remove elements that are out of this window (front of deque)
                if (dequeue.Count > 0 && dequeue.First.Value < i - k + 1)
                {
                    dequeue.RemoveFirst();
                }
                // Remove elements smaller than the current element (back of deque)
                while (dequeue.Count > 0 && nums[dequeue.Last.Value] < nums[i])
                {
                    dequeue.RemoveLast();
                }
                // Add current element index to deque
                dequeue.AddLast(i);
                // Store the maximum when the first window is completed
                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[dequeue.First.Value];
                }
            }
            return result;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter {i + 1} element of array:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter size of sliding window:");
            int k = Convert.ToInt32(Console.ReadLine());
            int[] max = CalculateMaximum(arr, k);
            Console.WriteLine("Sliding window maximum:" + string.Join(",", max));
        }

    }
}
