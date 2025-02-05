using System;

class Multiply6To9
{
    static void Main()
    {
        // Prompt the user to enter a number for multiplication
        Console.Write("Enter a number: ");

        // Read the user input and convert it to an integer
        int number = Convert.ToInt32(Console.ReadLine());

        // Initialize an array to store the results of the multiplication table
        int[] multiplicationResult = new int[4];

        // Call the method to display the multiplication table
        ShowMultiplication(number, multiplicationResult);
    }

    // Method to calculate and display the multiplication table
    static void ShowMultiplication(int number, int[] multiplicationResult)
    {
        // Loop through numbers from 6 to 9
        for (int i = 6; i <= 9; i++)
        {
            // Calculate the product and store it in the array
            multiplicationResult[i - 6] = number * i;

            // Display the multiplication result
            Console.WriteLine($"{number} x {i} = {multiplicationResult[i - 6]}");
        }
    }
}
