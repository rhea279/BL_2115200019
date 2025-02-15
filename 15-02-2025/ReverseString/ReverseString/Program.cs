using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input original string
            Console.WriteLine("Enter string to be reversed:");
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            //Display reversed string
            Console.WriteLine("Reversed String:"+ReverseString(sb));
        }
        //Method to reverse a string
        public static StringBuilder ReverseString(StringBuilder str) {
           int length = str.Length;
            for (int i= 0; i < length/2; i++){
                char temp = str[i];
                str[i] = str[length-i-1];
                str[length-i-1] = temp;
            }
            return str;
                
        }
    }
}
