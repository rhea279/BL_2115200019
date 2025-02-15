using System;
using System.Text;


namespace ConcatenateString
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input length of string array
            Console.Write("Enter the length of array:");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] stringArray = new string[n];
            //input strings
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine($"Enter {i + 1} string:");
                stringArray[i] = Console.ReadLine();
            }
            //Display strings after concatenation
            Console.WriteLine("After Concatenation:"+Concatenate(stringArray));
        }
        //Method to display strings after concatenation
        public static string Concatenate(string[] stringArray)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < stringArray.Length; i++)
            {
                str.Append(stringArray[i]);
            }
            return str.ToString();
        }
    }
}
