using System;
using System.Collections.Generic;

namespace Vehicle_Rental_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            while (true)
            {
                Console.WriteLine("\nVehicle Rental System:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Display Vehicles");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Vehicle Type (Car/Bike/Truck): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Vehicle Number: ");
                        string number = Console.ReadLine();

                        Console.Write("Enter Rental Rate: ");
                        double rate = double.Parse(Console.ReadLine());

                        if (type.Equals("Car", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Car(number, rate));
                        }
                        else if (type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Bike(number, rate));
                        }
                        else if (type.Equals("Truck", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Truck(number, rate));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Vehicle Type!");
                        }
                        break;

                    case "2":
                        if (vehicles.Count == 0)
                        {
                            Console.WriteLine("No vehicles available.");
                        }
                        else
                        {
                            Console.WriteLine("\nVehicle Details:");
                            foreach (var vehicle in vehicles)
                            {
                                vehicle.DisplayDetails();
                            }
                        }
                        break;

                    case "3":
                        
                        Console.WriteLine("Thank you for using Vehicle Rental System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
    }
    //Interface IInsurable with methods CalculateInsurance() and GetInsuranceDetails()
    interface IInsurable
    {
        double CalculateInsurance();
        string GetInsuranceDetails();
    }
    //Abstract class Vehicle with fields like vehicleNumber, type, and rentalRate
    abstract class Vehicle{
        public string vehicleNumber { get;private set; }
        public string type { get; private set; }
        public double rentalRate { get; protected set; }
        public Vehicle(string VehicleNumber, string Type, double RentalRate)
        {
            vehicleNumber = VehicleNumber;
            type = Type;
            rentalRate = RentalRate;
        }
        public abstract double CalculateRentalCost(int days);
        public void DisplayDetails()
        {
            Console.WriteLine("\n==== Vehicle Details ====");
            Console.WriteLine($"Vehicle Number   : {vehicleNumber}");
            Console.WriteLine($"Vehicle Type     : {type}");
            Console.WriteLine($"Rental Rate      : {rentalRate} per day");
            Console.WriteLine($"Rental Cost      : {CalculateRentalCost(1)} for 1 day");
            if (this is IInsurable insurable)
            {
                Console.WriteLine($"Insurance Details: {insurable.GetInsuranceDetails()}");
                Console.WriteLine($"Insurance Cost   : {insurable.CalculateInsurance():C}");
            }
        }

    }
    //Subclass Car
    class Car : Vehicle {
        private double insuranceRate = 50.0;
        private double dailyRateMultiplier = 1.2;

        public Car(string number, double rate)
            : base(number, "Car", rate) { }

        public override double CalculateRentalCost(int days)
        {
            return rentalRate * dailyRateMultiplier * days;
        }

        public double CalculateInsurance()
        {
            return insuranceRate;
        }

        public string GetInsuranceDetails()
        {
            return "Standard car insurance coverage";
        }
    }
    //Subclass Bike
    class Bike : Vehicle {
        private double insuranceRate = 50.0;
        private double dailyRateMultiplier = 1.2;

        public Bike(string number, double rate)
            : base(number, "Car", rate) { }

        public override double CalculateRentalCost(int days)
        {
            return rentalRate * dailyRateMultiplier * days;
        }

        public double CalculateInsurance()
        {
            return insuranceRate;
        }

        public string GetInsuranceDetails()
        {
            return "Standard car insurance coverage";
        }
    }
    //Subclass Truck
    class Truck : Vehicle {
        private double insuranceRate = 100.0;
        private double dailyRateMultiplier = 1.5;

        public Truck(string number, double rate)
            : base(number, "Truck", rate) { }

        public override double CalculateRentalCost(int days)
        {
            return rentalRate * dailyRateMultiplier * days;
        }

        public double CalculateInsurance()
        {
            return insuranceRate;
        }

        public string GetInsuranceDetails()
        {
            return "Heavy-duty vehicle insurance coverage";
        }
    
    }

}
