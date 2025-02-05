using System;

class Multiplication
{
    static void Main()
    {
        // Prompt the user to enter a number for multiplication
        Console.Write("Enter a number: ");

        // Read the user input and convert it to an integer
        int number = Convert.ToInt32(Console.ReadLine());

        // Initialize an array to store the results of the multiplication table
        int[] integer = new int[10];

        // Call the method to display the multiplication table
        ShowMultiplication(number, integer);
    }

    // Method to calculate and display the multiplication table
    static void ShowMultiplication(int number, int[] integer)
    {
        // Loop through numbers 1 to 10
        for (int i = 0; i < 10; i++)
        {
            // Calculate the product and store it in the array
            integer[i] = number * (i + 1);

            // Display the multiplication result
            Console.WriteLine($"{number} x {i + 1} = {integer[i]}");
        }
    }
}
