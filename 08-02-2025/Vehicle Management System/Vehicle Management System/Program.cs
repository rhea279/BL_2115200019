using System;

namespace Vehicle_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Vehicle Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Max Speed: ");
            int maxSpeed = int.Parse(Console.ReadLine());

            Console.Write("Enter Vehicle Type (Electric/Petrol): ");
            string type = Console.ReadLine().ToLower();

            Vehicle vehicle;

            if (type == "electric")
            {
                Console.Write("Enter Battery Capacity (kWh): ");
                int batteryCapacity = int.Parse(Console.ReadLine());
                vehicle = new ElectricVehicle(model, maxSpeed, batteryCapacity);
            }
            else if (type == "petrol")
            {
                Console.Write("Enter Fuel Capacity (liters): ");
                int fuelCapacity = int.Parse(Console.ReadLine());
                vehicle = new PetrolVehicle(model, maxSpeed, fuelCapacity);
            }
            else
            {
                Console.WriteLine("Invalid vehicle type!");
                return;
            }

            Console.WriteLine("\nVehicle Information:");
            vehicle.DisplayInfo();

            if (vehicle is PetrolVehicle petrolVehicle)
            {
                petrolVehicle.Refuel();
            }
            else if (vehicle is ElectricVehicle electricVehicle)
            {
                electricVehicle.Charge();
            }
        }
    }

    // Superclass Vehicle
    class Vehicle
    {
        public string Model { get; set; }
        public int MaxSpeed { get; set; }

        public Vehicle(string model, int maxSpeed)
        {
            Model = model;
            MaxSpeed = maxSpeed;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
        }
    }

    // Interface for refuelable vehicles
    interface Refuelable
    {
        void Refuel();
    }

    // Subclass ElectricVehicle
    class ElectricVehicle : Vehicle
    {
        public int BatteryCapacity { get; set; }

        public ElectricVehicle(string model, int maxSpeed, int batteryCapacity)
            : base(model, maxSpeed)
        {
            BatteryCapacity = batteryCapacity;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Battery Capacity: {BatteryCapacity} kWh");
        }

        public void Charge()
        {
            Console.WriteLine("Charging the electric vehicle...");
        }
    }

    // Subclass PetrolVehicle implementing Refuelable interface
    class PetrolVehicle : Vehicle, Refuelable
    {
        public int FuelCapacity { get; set; }

        public PetrolVehicle(string model, int maxSpeed, int fuelCapacity)
            : base(model, maxSpeed)
        {
            FuelCapacity = fuelCapacity;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Fuel Capacity: {FuelCapacity} liters");
        }

        public void Refuel()
        {
            Console.WriteLine("Refueling the petrol vehicle...");
        }
    }
}
