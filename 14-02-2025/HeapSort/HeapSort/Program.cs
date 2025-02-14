using System;

namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of job applicants: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] salaries = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter expected salary for applicant {i + 1}: ");
                salaries[i] = Convert.ToInt32(Console.ReadLine());
            }

            HeapSort(salaries);

            Console.WriteLine("Sorted salaries in ascending order:");
            foreach (int salary in salaries)
            {
                Console.WriteLine(salary);
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0);
            }
        }
        public static void Heapify(int[] arr, int heapSize, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // If left child is larger than root
            if (left < heapSize && arr[left] > arr[largest])
                largest = left;

            // If right child is larger than largest so far
            if (right < heapSize && arr[right] > arr[largest])
                largest = right;

            // If largest is not root
            if (largest != root)
            {
                Swap(ref arr[root], ref arr[largest]);

                // Recursively heapify the affected subtree
                Heapify(arr, heapSize, largest);
            }
        }
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a=b; 
            b=temp;
        }
    }
    
}
