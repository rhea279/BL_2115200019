using System;

class Youngest
{
    static void Main()
    {
        // Enter the ages of three friends
        Console.WriteLine("Enter age of Amar, Akbar, and Anthony respectively:");
        int[] age = new int[3];
        for (int i = 0; i < 3; i++)
        {
            age[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Enter the heights of three friends
        Console.WriteLine("Enter height of Amar, Akbar, and Anthony respectively:");
        int[] height = new int[3];
        for (int i = 0; i < 3; i++) // Corrected the loop to go through 3 elements
        {
            height[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Find the youngest friend and the tallest friend
        YoungestFrnd(age);
        TallestFrnd(height);
    }

    static void YoungestFrnd(int[] age)
    {
        int youngestAge = age[0];
        string youngestFriend = $"Friend 1"; // Initialize youngestFriend variable

        for (int i = 1; i < 3; i++) // Start from index 1 to compare with the first friend's age
        {
            if (age[i] < youngestAge)
            {
                youngestAge = age[i];
                youngestFriend = $"Friend {i + 1}";
            }
        }
        Console.WriteLine($"\nThe youngest friend is {youngestFriend} with age {youngestAge}.");
    }

    static void TallestFrnd(int[] height)
    {
        int tallestHeight = height[0];
        string tallestFriend = $"Friend 1"; // Initialize tallestFriend variable

        for (int i = 1; i < 3; i++) // Start from index 1 to compare with the first friend's height
        {
            if (height[i] > tallestHeight)
            {
                tallestHeight = height[i];
                tallestFriend = $"Friend {i + 1}";
            }
        }
        Console.WriteLine($"The tallest friend is {tallestFriend} with height {tallestHeight} meters.");
    }
}
