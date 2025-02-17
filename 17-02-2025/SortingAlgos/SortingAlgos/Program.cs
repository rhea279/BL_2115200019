using System;
using System.Diagnostics;

namespace SortingAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Comparison of Sorting Algorithms\n");

            int[] datasetSizes = { 1000, 10000, 100000 };

            foreach (int size in datasetSizes)
                MeasurePerformance(size);
        }

        static void MeasurePerformance(int size)
        {
            Random random = new Random();
            int[] originalData = new int[size];

            for (int i = 0; i < size; i++)
            {
                originalData[i] = random.Next(1, size * 10);
            }

            // Copy original data for fair sorting tests
            int[] bubbleData = (int[])originalData.Clone();
            int[] mergeData = (int[])originalData.Clone();
            int[] quickData = (int[])originalData.Clone();

            // Measure Bubble Sort time
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(bubbleData);
            sw.Stop();
            long bubbleTime = sw.ElapsedTicks;

            // Measure Merge Sort time
            sw.Restart();
            MergeSort(mergeData, 0, mergeData.Length - 1);
            sw.Stop();
            long mergeTime = sw.ElapsedTicks;

            // Measure Quick Sort time
            sw.Restart();
            QuickSort(quickData, 0, quickData.Length - 1);
            sw.Stop();
            long quickTime = sw.ElapsedTicks;

            // Display results
            Console.WriteLine($"Dataset Size: {size}");
            Console.WriteLine($"Bubble Sort Time: {bubbleTime} ticks");
            Console.WriteLine($"Merge Sort Time: {mergeTime} ticks");
            Console.WriteLine($"Quick Sort Time: {quickTime} ticks");
            Console.WriteLine("--------------------------------------");
        }

        // Bubble Sort
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        // Merge Sort
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++) leftArr[i] = arr[left + i];
            for (int j = 0; j < n2; j++) rightArr[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, kIndex = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                    arr[kIndex++] = leftArr[iIndex++];
                else
                    arr[kIndex++] = rightArr[jIndex++];
            }

            while (iIndex < n1) arr[kIndex++] = leftArr[iIndex++];
            while (jIndex < n2) arr[kIndex++] = rightArr[jIndex++];
        }

        // Quick Sort
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
