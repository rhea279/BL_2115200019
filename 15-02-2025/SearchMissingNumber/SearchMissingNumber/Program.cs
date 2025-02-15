using System;

namespace SearchAndMissingNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i+1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Find the first missing positive number
            int missingNumber = FindFirstMissingPositive(arr);
            Console.WriteLine($"First missing positive integer: {missingNumber}");

            // Sort the array for Binary Search
            Array.Sort(arr);
            Console.Write("Enter the target value to search: ");
            int target = Convert.ToInt32(Console.ReadLine());

            int targetIndex = BinarySearch(arr, target);
            if (targetIndex != -1)
                Console.WriteLine($"Target found at index: {targetIndex}");
            else
                Console.WriteLine("Target not found in the array.");
        }

        // Function to find the first missing positive integer using Linear Search
        public static int FindFirstMissingPositive(int[] arr)
        {
            int n = arr.Length;

            // Step 1: Place each number in its correct position
            for (int i = 0; i < n; i++)
            {
                while (arr[i] > 0 && arr[i] <= n && arr[arr[i] - 1] != arr[i])
                {
                    // Swap arr[i] and arr[arr[i] - 1]
                    int temp = arr[arr[i] - 1];
                    arr[arr[i] - 1] = arr[i];
                    arr[i] = temp;
                }
            }

            // Step 2: Find the first missing number
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != i + 1)
                    return i + 1;
            }

            // If all numbers are in place, return n+1
            return n + 1;
        }

        // Function to find the target index using Binary Search
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1; // Target not found
        }
    }
}
