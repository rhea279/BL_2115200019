using System;

class Program
{
    static void Main()
    {
        // Take input for the number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to find and display the factors
        FindAndDisplayFactors(number);
    }

    // Method to find and display factors
    static void FindAndDisplayFactors(int number)
    {
        // Initialize variables
        int maxFactor = 10;
        int[] factors = new int[maxFactor];
        int index = 0;

        // Loop through 1 to the number to find the factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                // If the array is full, double the size
                if (index == maxFactor)
                {
                    maxFactor *= 2; // Double the size
                    int[] temp = new int[maxFactor];

                    // Copy existing factors to the new array
                    for (int j = 0; j < factors.Length; j++)
                    {
                        temp[j] = factors[j];
                    }

                    factors = temp; // Assign the new array to factors
                }

                // Add the factor to the array
                factors[index] = i;
                index++;
            }
        }

        // Display the factors
        Console.WriteLine("Factors of " + number + ":");
        for (int i = 0; i < index; i++)
        {
            Console.Write(factors[i] + " ");
        }
        Console.WriteLine();
    }
}
