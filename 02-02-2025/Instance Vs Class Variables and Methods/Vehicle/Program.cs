using System;
class Vehicle
{
    public string OwnerName { get; set; }
    public string VehicleType { get; set; }
    private static double registrationFee = 500.0; // Default fee

    public Vehicle(string ownerName, string vehicleType)
    {
        OwnerName = ownerName;
        VehicleType = vehicleType;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner: {OwnerName}, Vehicle Type: {VehicleType}, Registration Fee: {registrationFee}");
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter Vehicle Owner Name: ");
        string ownerName = Console.ReadLine();
        Console.Write("Enter Vehicle Type: ");
        string vehicleType = Console.ReadLine();
        Console.Write("Enter New Registration Fee: ");
        double registrationFee = Convert.ToDouble(Console.ReadLine());
        Vehicle.UpdateRegistrationFee(registrationFee);
        Vehicle vehicle = new Vehicle(ownerName, vehicleType);
        vehicle.DisplayVehicleDetails();
    }
}
