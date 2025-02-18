using System;
using System.Collections.Generic;

// Interface for Meal Plans
public interface IMealPlan
{
    string MealName { get; }
    int Calories { get; }
    void DisplayMeal();  // Method to display meal details
}

// Vegetarian Meal Implementation
public class VegetarianMeal : IMealPlan
{
    public string MealName { get; }
    public int Calories { get; }

    public VegetarianMeal(string mealName, int calories)
    {
        MealName = mealName;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"Vegetarian Meal: {MealName} | Calories: {Calories}");
    }
}

// Vegan Meal Implementation
public class VeganMeal : IMealPlan
{
    public string MealName { get; }
    public int Calories { get; }

    public VeganMeal(string mealName, int calories)
    {
        MealName = mealName;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"Vegan Meal: {MealName} | Calories: {Calories}");
    }
}

// Keto Meal Implementation
public class KetoMeal : IMealPlan
{
    public string MealName { get; }
    public int Calories { get; }

    public KetoMeal(string mealName, int calories)
    {
        MealName = mealName;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"Keto Meal: {MealName} | Calories: {Calories}");
    }
}

// High-Protein Meal Implementation
public class HighProteinMeal : IMealPlan
{
    public string MealName { get; }
    public int Calories { get; }

    public HighProteinMeal(string mealName, int calories)
    {
        MealName = mealName;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"High-Protein Meal: {MealName} | Calories: {Calories}");
    }
}

// Generic Meal Class
public class Meal<T> where T : IMealPlan
{
    public T MealPlan { get; }

    public Meal(T mealPlan)
    {
        MealPlan = mealPlan;
    }

    public void DisplayMealPlan()
    {
        MealPlan.DisplayMeal();
    }
}

// Meal Plan Generator
public class MealPlanGenerator
{
    private List<IMealPlan> mealPlans = new List<IMealPlan>();

    // Generic method to generate and store meal plans
    public void GenerateMealPlan<T>(T meal) where T : IMealPlan
    {
        mealPlans.Add(meal);
    }

    // Display all stored meal plans
    public void DisplayMealPlans()
    {
        Console.Clear();
        Console.WriteLine("===== Your Meal Plans =====");

        if (mealPlans.Count == 0)
        {
            Console.WriteLine("No meals available.\n");
        }
        else
        {
            foreach (var meal in mealPlans)
            {
                meal.DisplayMeal();
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}

// Main Program with Menu
public class Program
{
    public static void Main()
    {
        var mealGenerator = new MealPlanGenerator();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== Personalized Meal Plan Generator =====");
            Console.WriteLine("1. Add a Meal Plan");
            Console.WriteLine("2. Display Meal Plans");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddMealPlanMenu(mealGenerator);
                    break;
                case "2":
                    mealGenerator.DisplayMealPlans();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Menu for adding meal plans
    private static void AddMealPlanMenu(MealPlanGenerator mealGenerator)
    {
        Console.Clear();
        Console.WriteLine("===== Add a Meal Plan =====");
        Console.Write("Enter Meal Name: ");
        string mealName = Console.ReadLine();

        Console.Write("Enter Calories: ");
        if (!int.TryParse(Console.ReadLine(), out int calories))
        {
            Console.WriteLine("Invalid input. Calories must be a number.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select Meal Category:");
        Console.WriteLine("1. Vegetarian");
        Console.WriteLine("2. Vegan");
        Console.WriteLine("3. Keto");
        Console.WriteLine("4. High-Protein");
        Console.Write("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                var vegetarianMeal = new VegetarianMeal(mealName, calories);
                mealGenerator.GenerateMealPlan(vegetarianMeal);
                Console.WriteLine("Vegetarian Meal added successfully.");
                break;
            case "2":
                var veganMeal = new VeganMeal(mealName, calories);
                mealGenerator.GenerateMealPlan(veganMeal);
                Console.WriteLine("Vegan Meal added successfully.");
                break;
            case "3":
                var ketoMeal = new KetoMeal(mealName, calories);
                mealGenerator.GenerateMealPlan(ketoMeal);
                Console.WriteLine("Keto Meal added successfully.");
                break;
            case "4":
                var highProteinMeal = new HighProteinMeal(mealName, calories);
                mealGenerator.GenerateMealPlan(highProteinMeal);
                Console.WriteLine("High-Protein Meal added successfully.");
                break;
            default:
                Console.WriteLine("Invalid meal category selection.");
                break;
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
