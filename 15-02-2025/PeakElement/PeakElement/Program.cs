using System;

namespace PeakElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input size of array
            Console.WriteLine("Enter number of elements:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            //Input the elements in array
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Enter {i + 1} element:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int peakElement = FindPeakElement(arr);
            //Display peak element in array
            Console.WriteLine("Peak Element in array is :"+peakElement);
        }
        //Method to find peak element in array
        public static int FindPeakElement(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < arr[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }
    }
}
