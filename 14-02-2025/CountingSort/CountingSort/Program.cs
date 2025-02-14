using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ages = new int[n];

            Console.WriteLine("Enter student ages (between 10 and 18):");
            for (int i = 0; i < n; i++)
            {
                int age;
                do
                {
                    Console.Write($"Age of student {i + 1}: ");
                    age = Convert.ToInt32(Console.ReadLine());

                    if (age < 10 || age > 18)
                        Console.WriteLine("Invalid age! Please enter an age between 10 and 18.");

                } while (age < 10 || age > 18);

                ages[i] = age;
            }

            CountSort(ages,n);

            Console.WriteLine("Sorted student ages:");
            foreach (int age in ages)
            {
                Console.WriteLine(age);
            }
        }

        public static void CountSort(int[] arr, int n)
        {
            int minAge = 10, maxAge = 18;
            int range = maxAge - minAge + 1;

            int[] count = new int[range];
            int[] output = new int[arr.Length];

            // Count occurrences of each age
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - minAge]++;
            }

            //Compute cumulative counts
            for (int i = 1; i < range; i++)
            {
                count[i] += count[i - 1];
            }

            //Place elements in the correct position
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - minAge] - 1] = arr[i];
                count[arr[i] - minAge]--;
            }

            // Copy sorted output back to original array
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }


        }
    }
}
