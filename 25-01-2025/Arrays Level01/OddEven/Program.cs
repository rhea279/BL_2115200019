using System;

class Program
{
    static void Main()
    {
        // Get user input
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int number) || number <= 0)
        {
            Console.WriteLine("Error: Not a natural number.");
            return;
        }

        // Create arrays for even and odd numbers
        int[] evenNumbers = new int[number / 2 + 1];
        int[] oddNumbers = new int[number / 2 + 1];

        int evenIndex = 0;
        int oddIndex = 0;

        // Iterate from 1 to the entered number
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        // Print the odd numbers array
        Console.WriteLine("Odd Numbers: ");
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }
        Console.WriteLine();

        // Print the even numbers array
        Console.WriteLine("Even Numbers: ");
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
        Console.WriteLine();
    }
}
