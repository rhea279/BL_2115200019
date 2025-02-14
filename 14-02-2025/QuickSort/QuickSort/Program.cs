using System;
using System.Collections.Concurrent;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter quantity of product:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the price of Product {i + 1}:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            QuickSort(arr, 0, n-1);
            Console.WriteLine("Sorted list of product prices in ascending order:");
            foreach (int price in arr)
            {
                Console.WriteLine(price);
            }
        }
        public static void QuickSort(int[] arr, int low,int high)
        {
            if (low < high)
            {
                {
                    int j = Partition(arr, low, high);
                    QuickSort(arr, low, j);
                    QuickSort(arr, j + 1, high);
                }
            }
        }
        public static int Partition(int[] arr,int low, int high)
        {
            int pivot = arr[low];
            int i = low -1 , j = high+1;
            while (true)
            {
                do { 
                    i++;
                } while (arr[i]<pivot && i <= high);
                do
                {
                    j--;
                } while (arr[j]>pivot && j >= low);
                if (i >= j)
                    return j;
                Swap(ref arr[i], ref arr[j]);
            }
          

        }
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
