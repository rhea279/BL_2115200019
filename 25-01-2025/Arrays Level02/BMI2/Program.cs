using System;

class BMI2
{
    static void Main()
    {
        // Take input for the number of persons
        Console.Write("Enter the number of persons: ");
        int numberOfPersons = Convert.ToInt32(Console.ReadLine());

        // Create a multi-dimensional array to store weight, height, and BMI
        double[,] personData = new double[numberOfPersons,3];  // [weight, height, BMI]
        string[] weightStatus = new string[numberOfPersons];      // Weight status for each person

        // Take input for weight and height of the persons
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine($"Enter details for person {i + 1}:");

            // Input and validate weight
            personData[i,0] = GetValidInput("Weight");
            
            // Input and validate height
            personData[i,1] = GetValidInput("Height");

            // Calculate BMI = weight / (height * height)
            personData[i,2] = CalculateBMI(personData[i,0], personData[i,1]);

            // Determine weight status
            weightStatus[i] = GetWeightStatus(personData[i,2]);
        }

        // Display the height, weight, BMI, and weight status of each person
        Console.WriteLine("\nPerson Details:");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine($"\nPerson {i + 1}:");
            Console.WriteLine($"Weight: {personData[i,0]} kg");
            Console.WriteLine($"Height: {personData[i,1]} meters");
            Console.WriteLine($"BMI: {personData[i,2]:F2}");
            Console.WriteLine($"Weight Status: {weightStatus[i]}");
        }
    }

    // Method to ensure valid positive input
    static double GetValidInput(string type)
    {
        double input;
        while (true)
        {
            Console.Write($"Enter {type}: ");
            input = Convert.ToDouble(Console.ReadLine());

            // Ensure the input is positive
            if (input > 0)
            {
                return input;
            }
            else
            {
                Console.WriteLine($"{type} must be a positive value. Please enter again.");
            }
        }
    }

    // Method to calculate BMI
    static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);
    }

    // Method to determine weight status based on BMI
    static string GetWeightStatus(double bmi)
    {
        if (bmi < 18.5)
        {
            return "Underweight";
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            return "Normal weight";
        }
        else if (bmi >= 25 && bmi < 29.9)
        {
            return "Overweight";
        }
        else
        {
            return "Obese";
        }
    }
}
