using System;

namespace SearchTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows in matrix:");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns in matrix:");
            int cols = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"Enter [{i},{j}] element of matrix:");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            // Input target value
            Console.Write("Enter the target value to search: ");
            int target = Convert.ToInt32(Console.ReadLine());

            // Search for the target value
            (int, int) result = SearchTargetValue(arr, rows, cols, target);

            if (result.Item1 != -1)
                Console.WriteLine($"Target value found at index ({result.Item1}, {result.Item2}).");
            else
                Console.WriteLine("Target value not found in the matrix.");

        }
        public static (int, int) SearchTargetValue(int[,] arr, int rows, int cols, int target)
        {
            int left = 0, right = rows * cols - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midValue = arr[mid / cols, mid % cols];
                if (midValue == target)
                    return (mid / cols, mid % cols);
                else if (midValue < target)
                    left = mid + 1;
                else
                    right = mid - 1;

            }
            return (-1, -1);
        }
    }
}
