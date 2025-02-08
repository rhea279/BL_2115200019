using System;
namespace Smart_Home_Devices
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt user for device details
            Console.Write("Enter Device ID: ");
            int deviceId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Device Status (On/Off): ");
            string status = Console.ReadLine();

            Console.Write("Enter Temperature Setting: ");
            double temperatureSetting = double.Parse(Console.ReadLine());

            // Create a Thermostat object with user input
            Thermostat thermostat = new Thermostat(deviceId, status, temperatureSetting);
            Console.WriteLine("\nDevice Status:");
            thermostat.DisplayStatus();
        }
    }
    //Define a superclass Device
    class Device
    {
        public int DeviceId {  get; set; }
        public string Status { get; set; }
        // Constructor to initialize device properties
        public Device(int deviceId, string status)
        {
            DeviceId = deviceId;
            Status = status;
        }
        public virtual void DisplayStatus()
        {
            Console.WriteLine("Device Information:");
            Console.WriteLine($"Device ID: {DeviceId}");
            Console.WriteLine($"Status: {Status}");
        }
    }
    //Define a subclass Thermostat
    class Thermostat : Device {
        public double TemperatureSetting { get; set; }

        // Constructor to initialize thermostat properties
        public Thermostat(int deviceId, string status, double temperatureSetting)
            : base(deviceId, status)
        {
            TemperatureSetting = temperatureSetting;
        }

        public override void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine($"Temperature Setting: {TemperatureSetting}°C");
        }
    }
}
