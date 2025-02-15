using System;

namespace RotationPointSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input array size
            Console.Write("Enter the number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            // Input rotated sorted array
            Console.WriteLine("Enter the elements of the rotated sorted array:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Find the rotation point (index of smallest element)
            int rotationIndex = FindRotationPoint(arr);

            Console.WriteLine("The index of the smallest element (rotation point) is: " + rotationIndex);
        }

        // Binary Search to find the index of the smallest element
        public static int FindRotationPoint(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                // If mid element is greater than the last element, search in the right half
                if (arr[mid] > arr[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid; // Search in the left half
                }
            }
            return left; // Left index is the smallest element
        }
    }
}
