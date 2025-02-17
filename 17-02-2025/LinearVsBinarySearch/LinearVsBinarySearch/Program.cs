using System;
using System.Diagnostics;

namespace LinearVsBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Comparison of Linear Search vs Binary Search\n");

            int[] datasetSizes = { 1000, 10000, 1000000 };

            foreach (int size in datasetSizes)
                MeasurePerformance(size);

        }
        static void MeasurePerformance(int size)
        {
            Random random = new Random();
            int[] data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(1, size * 10);
            }
            int target = data[size / 2];

            //Start stopwatch before linear searching
            Stopwatch sw = Stopwatch.StartNew();
            LinearSearch(data, target);
            //Stop stopwatch after linear searching is done
            sw.Stop();
            //Display time taken by linear searching in ticks
            long linearTime = sw.ElapsedTicks;

            Array.Sort(data);

            //Restart stopwatch before binary searching
            sw.Restart();
            BinarySearch(data, target);
            //Stop stopwatch after binary searching is done
            sw.Stop();
            //Display time taken by binary searching in ticks
            long binaryTime = sw.ElapsedTicks;

            // Display results
            Console.WriteLine($"Dataset Size: {size}");
            Console.WriteLine($"Linear Search Time: {linearTime} ticks");
            Console.WriteLine($"Binary Search Time: {binaryTime} ticks");
            Console.WriteLine("--------------------------------------");

        }
        //Method for linear search
        public static int  LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    Console.WriteLine("Target found");
                    return i;
                }
            }
            return -1;
        }
        //Method for binary search
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                   
                    return mid;
                }
                else if (arr[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    
    }
}
