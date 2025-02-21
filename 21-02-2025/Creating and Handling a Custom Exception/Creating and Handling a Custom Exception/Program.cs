
using System;

namespace Creating_and_Handling_a_Custom_Exception
{
    //Create a custom exception called InvalidAgeException
    class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //take user input 
                Console.WriteLine("Enter Age of Candidate:");
                int age = Convert.ToInt32(Console.ReadLine());
                //call ValidateAge()
                ValidateAge(age);
                Console.WriteLine("Access Granted");
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        //Write a method ValidateAge(int age) that throws InvalidAgeException if the age is below 18
        static void ValidateAge(int age)
        {
            //If an exception occurs, display "Age must be 18 or above"
            if (age < 18)
                throw new InvalidAgeException("Age must be 18 or above");
        }
    }
}
