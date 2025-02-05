using System;

class Bonus
{
    static void Main()
    {
        // Declare arrays to store salary and years of service
        double[] salaries = new double[10];
        int[] yearsOfService = new int[10];

        // Take input from the user
        for (int i = 0; i < 10; i++)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");

                // Taking salary input
                Console.Write("Enter salary: ");
                if (double.TryParse(Console.ReadLine(), out double salary) && salary > 0)
                {
                    salaries[i] = salary;
                }
                else
                {
                    Console.WriteLine("Invalid salary. Please enter a valid positive number.");
                    continue;
                }

                // Taking years of service input
                Console.Write("Enter years of service: ");
                if (int.TryParse(Console.ReadLine(), out int years) && years >= 0)
                {
                    yearsOfService[i] = years;
                    validInput = true; // Valid input, exit the loop
                }
                else
                {
                    Console.WriteLine("Invalid years of service. Please enter a valid number.");
                }
            }
        }

        // Call the method to calculate bonus, new salary, and total amounts
        CalculateBonusAndSalary(salaries, yearsOfService);
    }

    static void CalculateBonusAndSalary(double[] salaries, int[] yearsOfService)
    {
        // Arrays to store the bonus amount, new salary for each employee
        double[] bonuses = new double[10];
        double[] newSalaries = new double[10];

        // Variables to keep track of total bonus, total old salary, and total new salary
        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;

        // Loop to calculate bonus, new salary, and total salary
        for (int i = 0; i < 10; i++)
        {
            double bonusPercentage = (yearsOfService[i] >= 5) ? 0.05 : 0.02; // 5% if years >= 5, else 2%
            bonuses[i] = salaries[i] * bonusPercentage; // Calculate the bonus
            newSalaries[i] = salaries[i] + bonuses[i]; // Calculate new salary

            totalBonus += bonuses[i]; // Add to total bonus
            totalOldSalary += salaries[i]; // Add to total old salary
            totalNewSalary += newSalaries[i]; // Add to total new salary
        }

        // Display total bonus payout, total old salary, and total new salary
        Console.WriteLine($"\nTotal Bonus Payout: {totalBonus:C2}");
        Console.WriteLine($"Total Old Salary of all employees: {totalOldSalary:C2}");
        Console.WriteLine($"Total New Salary of all employees: {totalNewSalary:C2}");

        // Display the bonus and new salary for each employee
        Console.WriteLine("\nEmployee Bonus and New Salary Details:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Employee {i + 1}: Bonus = {bonuses[i]:C2}, New Salary = {newSalaries[i]:C2}");
        }
    }
}
