using System;

namespace FirstLastOccurrence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter the sorted elements of the array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Enter the target value to search: ");
            int target = Convert.ToInt32(Console.ReadLine());

            // Find first and last occurrence
            int first = FindFirstOccurrence(arr, target);
            int last = FindLastOccurrence(arr, target);

            if (first != -1)
                Console.WriteLine($"First occurrence: {first}, Last occurrence: {last}");
            else
                Console.WriteLine("Target not found in the array.");
        }
        public static int FindFirstOccurrence(int[] arr, int target) {
            int left = 0,right = arr.Length - 1;
            int result = -1;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    result = mid;
                    right = mid - 1; // Move left to find earlier occurrences
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
        public static int FindLastOccurrence(int[] arr, int target) {
            int left = 0, right = arr.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    result = mid;
                    left = mid + 1; // Move right to find later occurrences
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
