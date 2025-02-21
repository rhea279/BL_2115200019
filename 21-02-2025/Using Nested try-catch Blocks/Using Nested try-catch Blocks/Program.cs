
using System;

namespace Using_Nested_try_catch_Blocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];

            //Accept an integer array and an index number.
            Console.WriteLine("Enter the elements of array:");
            for (int i = 0; i < array.Length; i++)
                array[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the index to access:");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter divisor:");
            int divisor = Convert.ToInt32(Console.ReadLine());
            try
            {
                int value = array[index];
                try
                {
                    int result = value / divisor;
                    Console.WriteLine($"Result: {result}");

                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }
        }
    }
}
