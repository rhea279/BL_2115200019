using System;

namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of students:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the exam score of Student {i + 1}:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            SelectionSort(arr, n);
            Console.WriteLine("Sorted list of exam score of students in ascending order:");
            foreach(int score in arr)
                Console.WriteLine(score);
            
        }
        public static void SelectionSort(int[] arr,int n)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                int smallestIndx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[smallestIndx] > arr[j])
                        smallestIndx = j;
                }
                Swap(ref arr[i],ref  arr[smallestIndx]);
            }
        }
        public static void Swap(ref int a,  ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
