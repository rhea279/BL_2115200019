using System;

namespace SortStudentMarks
{
    class SortStudentMarks
    {
        static void Main(string[] args)
        {
            //Input the size of array from user
            Console.Write("Enter number of students:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                //Input the marks of students
                Console.WriteLine($"Enter {i + 1} Student marks:");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            SortMarks(arr);
            //Display Sorted list
            Console.WriteLine("Sorted Marks :");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static void SortMarks(int[] marks)
        {
            bool swapped;
            //Traverse through the array multiple times
            for (int i = 0; i < marks.Length-1; i++)
            {
                swapped = false;
                for (int j = 0; j < marks.Length - 1; j++)
                {
                    //Compare adjacent elements and swap them if needed.
                    if (marks[j] > marks[j + 1])
                    {
                        int temp = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = temp;
                        swapped = true;
                    }
                }
                //Repeat the process until no swaps are required.
                if (!swapped) 
                    break;
            }
            
        }
    }
}
