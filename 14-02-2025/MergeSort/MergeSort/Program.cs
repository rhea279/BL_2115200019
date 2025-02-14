using System;
using System.Collections.Specialized;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of books: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] prices = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter price for book {i + 1}: ");
                prices[i] = Convert.ToDouble(Console.ReadLine());
            }

            MergeSort(prices, 0, prices.Length - 1);

            Console.WriteLine("Sorted Book Prices:");
            foreach (double price in prices)
            {
                Console.WriteLine(price);

            }
        }
            public static void MergeSort(double[] arr, int start, int end)
            {
                if (start < end)
                {
                    int mid = (start + end) / 2;
                    MergeSort(arr, start, mid);
                    MergeSort(arr, mid + 1, end);

                    Merge(arr, start, mid, end);
                }

            }
            public static void Merge(double[] arr, int start, int mid, int end)
            {
                int n1 = mid - start + 1;
                int n2 = end - mid;

                double[] leftArr = new double[n1];
                double[] rightArr = new double[n2];

                for (int i = 0; i < n1; i++)
                    leftArr[i] = arr[start + i];
                for (int j = 0; j < n2; j++)
                    rightArr[j] = arr[mid + j + 1];

                int iIndex = 0, jIndex = 0, k = start;
                while (iIndex < n1 && jIndex < n2)
                {
                    if (leftArr[iIndex] <= rightArr[jIndex])
                    {
                        arr[k] = leftArr[iIndex];
                        iIndex++;
                    }
                    else
                    {
                        arr[k] = rightArr[jIndex];
                        jIndex++;
                    }
                    k++;
                }
                while (iIndex < n1)
                {
                    arr[k] = leftArr[iIndex];
                    iIndex++;
                    k++;
                }

                while (jIndex < n2)
                {
                    arr[k] = rightArr[jIndex];
                    jIndex++;
                    k++;
                }

            }
        }
    }

