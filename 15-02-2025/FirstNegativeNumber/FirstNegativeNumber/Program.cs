using System;
using System.Security.Cryptography;

namespace FirstNegativeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter {i + 1} element of array:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int result = FirstNegativeNumber(arr);
            if(result != int.MaxValue)
            {
                Console.WriteLine($"First Negative Integer:{result}");
            }
            else
            {
                Console.WriteLine("No negative integer found");
            }

        }
        public static int FirstNegativeNumber(int[] arr)
        {
            foreach (int i in arr)
            {
                if (i < 0)
                {
                    return i;
                }
            }
            return int.MaxValue;
        }
    }
}
