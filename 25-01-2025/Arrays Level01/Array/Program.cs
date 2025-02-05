using System;

class ArraySum
{
    static void Main()
    {
        // Initialize an array to store up to 10 elements of type double
        double[] numbers = new double[10];

        // Initialize a variable to store the total sum
        double total = 0.0;

        // Initialize the index variable to 0
        int index = 0;

        Console.WriteLine("Enter up to 10 numbers. Enter 0 or a negative number to stop:");

        // Infinite loop to take user input
        while (true)
        {
            // Prompt the user to enter a number
            Console.Write($"Enter number {index + 1}: ");

            // Read and parse the user input
            if (double.TryParse(Console.ReadLine(), out double input))
            {
                // Break the loop if the input is 0 or negative
                if (input <= 0)
                {
                    break;
                }

                // Store the input in the array and increment the index
                numbers[index] = input;
                index++;

                // Break the loop if the array is full
                if (index == 10)
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Calculate the total sum of the numbers
        for (int i = 0; i < index; i++)
        {
            total += numbers[i];
        }

        // Display the entered numbers
        Console.WriteLine("\nYou entered the following numbers:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        // Display the total sum
        Console.WriteLine($"\nThe total sum of the numbers is: {total}");
    }
}
