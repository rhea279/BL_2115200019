using System;
namespace InsertionSort
{
    class SortEmployeeIDs
    {
        static void Main(string[] args)
        {
            //Input the size of array from user
            Console.Write("Enter number of employees:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                //Input the IDs of Employees
                Console.WriteLine($"Enter Employee {i + 1} ID:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            SortIDs(arr);
            //Display Sorted list
            Console.WriteLine("Sorted Marks :");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }
        public static void SortIDs(int[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                int curr = arr[i];
                int prev = i - 1;
                while(prev >= 0 && arr[prev] > curr)
                {
                    arr[prev + 1] = arr[prev];
                    prev--;
                }
                arr[prev + 1] = curr;
            }
        }
    }
}
