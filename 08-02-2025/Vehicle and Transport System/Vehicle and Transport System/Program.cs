using System;

namespace Vehicle_and_Transport_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[]
        {
            new Car(200, "Petrol", 5),
            new Truck(120, "Diesel", 10000),
            new MotorCycle(180, "Petrol", false)
        };

            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }
        //Define a superclass Vehicle
        class Vehicle
        {
            public int MaxSpeed { get; set; }
            public string FuelType { get; set; }
            public Vehicle(int maxSpeed, string fuelType)
            {
                MaxSpeed = maxSpeed;
                FuelType = fuelType;
            }
            public virtual void DisplayInfo()
            {
                Console.WriteLine("Vehicle Information :");
                Console.WriteLine($"Maximum Speed : {MaxSpeed}");
                Console.WriteLine($"Fuel Type : {FuelType}");
            }
        }
        //Define subclass Car
        class Car : Vehicle
        {
            public int SeatCapacity { get; set; }
            public Car(int maxSpeed, string fuelType, int seatCapacity)
                : base(maxSpeed, fuelType)
            {
                SeatCapacity = seatCapacity;
            }
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Seat Capacity : {SeatCapacity}");
            }
        }
        //Define subclass Truck
        class Truck : Vehicle
        {
            public int PayloadCapacity { get; set; }
            public Truck(int maxSpeed, string fuelType, int payloadCapacity)
                : base(maxSpeed, fuelType)
            {
                PayloadCapacity = payloadCapacity;
            }
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Payload Capacity : {PayloadCapacity}");
            }
        }
        //Define subclass MotorCycle
        class MotorCycle : Vehicle
        {
            public bool HasSidecar { get; set; }
            public MotorCycle(int maxSpeed, string fuelType, bool hasSideCar)
                : base(maxSpeed, fuelType)
            {
                HasSidecar = hasSideCar;
            }
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Has Side Car? : {HasSidecar}");
            }
        }

    }
}