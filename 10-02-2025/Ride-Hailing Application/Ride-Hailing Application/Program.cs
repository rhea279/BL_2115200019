using System;
using System.Collections.Generic;

namespace RideHailingApplication
{
    //Implement an interface IGPS
    interface IGPS
    {
        //Define methods GetCurrentLocation() and UpdateLocation()
        string GetCurrentLocation();
        void UpdateLocation(string newLocation);
    }
    //Define an abstract class Vehicle with fields: vehicleId, driverName, and ratePerKm
    abstract class Vehicle
    {
        private string vehicleId;
        private string driverName;
        private double ratePerKm;

        public string VehicleId { get { return vehicleId; } protected set { vehicleId = value; } }
        public string DriverName { get { return driverName; } set { driverName = string.IsNullOrWhiteSpace(value) ? "Unknown" : value; } }
        public double RatePerKm { get { return ratePerKm; } protected set { ratePerKm = value > 0 ? value : 1; } }

        public Vehicle(string vehicleId, string driverName, double ratePerKm)
        {
            VehicleId = vehicleId;
            DriverName = driverName;
            RatePerKm = ratePerKm;
        }
        //Add an abstract method CalculateFare(double distance)
        public abstract double CalculateFare(double distance);
        //Implement a concrete method GetVehicleDetails().
        public void GetVehicleDetails()
        {
            Console.WriteLine($"\nVehicle ID: {VehicleId}, Driver: {DriverName}, Rate per Km: {RatePerKm}");
        }
    }
    //Extend Vehicle into Car
    class Car : Vehicle, IGPS
    {
        public Car(string vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm) { }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm;
        }

        public string GetCurrentLocation() => "Fetching Car Location...";
        public void UpdateLocation(string newLocation) => Console.WriteLine($"Car Location Updated to: {newLocation}");
    }
    //Extend Vehicle into Bike
    class Bike : Vehicle, IGPS
    {
        public Bike(string vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm) { }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm * 0.8; // Discounted rate for bikes
        }

        public string GetCurrentLocation() => "Fetching Bike Location...";
        public void UpdateLocation(string newLocation) => Console.WriteLine($"Bike Location Updated to: {newLocation}");
    }
    //Extend Vehicle into Auto
    class Auto : Vehicle, IGPS
    {
        public Auto(string vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm) { }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm * 0.9; // Slightly lower rate than a car
        }

        public string GetCurrentLocation() => "Fetching Auto Location...";
        public void UpdateLocation(string newLocation) => Console.WriteLine($"Auto Location Updated to: {newLocation}");
    }

    class Program
    {
        static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nRide-Hailing Application:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Calculate Fare");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Vehicle Type (Car/Bike/Auto): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Vehicle ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Enter Driver Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Rate per Km: ");
                        double rate = double.Parse(Console.ReadLine());

                        if (type.Equals("Car", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Car(id, name, rate));
                        }
                        else if (type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Bike(id, name, rate));
                        }
                        else if (type.Equals("Auto", StringComparison.OrdinalIgnoreCase))
                        {
                            vehicles.Add(new Auto(id, name, rate));
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
                            Console.Write("Enter Vehicle ID: ");
                            string vehicleId = Console.ReadLine();

                            Vehicle selectedVehicle = vehicles.Find(v => v.VehicleId == vehicleId);
                            if (selectedVehicle != null)
                            {
                                Console.Write("Enter Distance (in Km): ");
                                double distance = double.Parse(Console.ReadLine());
                                Console.WriteLine($"Fare: {selectedVehicle.CalculateFare(distance)} INR");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found!");
                            }
                        }
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Thank you for using the Ride-Hailing Application!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
    }
}
