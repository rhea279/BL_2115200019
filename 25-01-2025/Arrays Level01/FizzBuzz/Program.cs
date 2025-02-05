using System;

class Program
{
    static void Main()
    {
        // Input the number
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is a positive integer
        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return; // Exit if not a positive integer
        }

        // Create a String array to store the results
        string[] results = new string[number + 1]; // array size is number + 1 to include 0

        // Loop through the numbers from 0 to the entered number
        for (int i = 0; i <= number; i++)
        {
            // Check for multiples of both 3 and 5
            if (i % 3 == 0 && i % 5 == 0)
            {
                results[i] = "FizzBuzz";
            }
            // Check for multiples of 3
            else if (i % 3 == 0)
            {
                results[i] = "Fizz";
            }
            // Check for multiples of 5
            else if (i % 5 == 0)
            {
                results[i] = "Buzz";
            }
            else
            {
                // For other numbers, store the number itself
                results[i] = i.ToString();
            }
        }

        // Display the results with the index positions
        for (int i = 0; i <= number; i++)
        {
            Console.WriteLine($"Position {i} = {results[i]}");
        }
    }
}
