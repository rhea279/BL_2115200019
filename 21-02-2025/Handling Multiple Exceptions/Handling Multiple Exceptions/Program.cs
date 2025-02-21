
using System;

namespace Handling_Multiple_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
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

                //Retrieve and print the value at that index
                Console.WriteLine($"Value at index {index} = {array[index - 1]}");
            }
            //IndexOutOfRangeException if the index is out of range
            catch (IndexOutOfRangeException)
            {
                //If the index is out of bounds, display "Invalid index!"
                Console.WriteLine("Invalid index!");
            }
            //NullReferenceException if the array is null
            catch (NullReferenceException)
            {
                //f the array is null, display "Array is not initialized!"
                Console.WriteLine("Array is not initialized!");
            }
        }
    }
}
