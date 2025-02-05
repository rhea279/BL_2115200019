using System;

class MeanHt
{
    static void Main()
    {
        // Initialize an array to store the heights of 11 football players
        double[] ht = new double[11];

        // Variable to store the sum of heights
        double sum = 0.0;

        // Prompt the user to input heights for each player
        Console.WriteLine("Enter the heights of 11 football players:");

        for (int i = 0; i < 11; i++)
        {
            // Read and store the height in the array
            ht[i] = Convert.ToDouble(Console.ReadLine());

            // Add the height to the total sum
            sum += ht[i];
        }

        // Calculate the mean height
        double mean = sum / 11;

        // Display the mean height
        Console.WriteLine($"Mean height of the football team is {mean}");
    }
}
