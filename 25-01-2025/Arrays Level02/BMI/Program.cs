using System;
class BMI{
	static void Main(){
		//Take input to nter number of persons 
		Console.Write("Enter number of persons :");
		int n = Convert.ToInt32(Console.ReadLine());
		
		// Arrays to store weight, height, BMI, and weight status
        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] weightStatus = new string[n];
		
		// Take input for each person's weight and height
        for (int i = 0; i < n; i++)
        {
			Console.Write(" Enter Weight (in kg) of person {i+1}: ");
            weight[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Height (in meters) of person {i+1}: ");
            height[i] = Convert.ToDouble(Console.ReadLine());

            // Calculate BMI
            bmi[i] = weight[i] / (height[i] * height[i]);
			// Determine weight status
            if (bmi[i] < 18.5)
                weightStatus[i] = "Underweight";
            else if (bmi[i] >= 18.5 && bmi[i] < 25)
                weightStatus[i] = "Normal weight";
            else if (bmi[i] >= 25 && bmi[i] < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obesity";
        }

        // Display the details for each person
        Console.WriteLine("\nDetails of each person:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Person {i + 1}:");
            Console.WriteLine($"Height: {height[i]} m");
            Console.WriteLine($"Weight: {weight[i]} kg");
            Console.WriteLine($"BMI: {bmi[i]:F2}");
            Console.WriteLine($"Weight Status: {weightStatus[i]}\n");
        }
    }
}