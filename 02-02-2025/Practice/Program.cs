using System;

// Book Class
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book() {}
    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }
}

// Circle Class
class Circle
{
    public double Radius { get; set; }

    public Circle() : this(1.0) {} // Default radius = 1.0
    public Circle(double radius)
    {
        Radius = radius;
    }
}

// Person Class (Copy Constructor)
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public Person(Person other)
    {
        Name = other.Name;
        Age = other.Age;
    }
}

// Hotel Booking System
class HotelBooking
{
    public string GuestName { get; set; }
    public string RoomType { get; set; }
    public int Nights { get; set; }

    public HotelBooking() {}
    public HotelBooking(string guestName, string roomType, int nights)
    {
        GuestName = guestName;
        RoomType = roomType;
        Nights = nights;
    }
    public HotelBooking(HotelBooking other)
    {
        GuestName = other.GuestName;
        RoomType = other.RoomType;
        Nights = other.Nights;
    }
}

// Library Book System
class LibraryBook : Book
{
    public bool IsAvailable { get; set; } = true;

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine("Book borrowed successfully.");
        }
        else
        {
            Console.WriteLine("Book is already borrowed.");
        }
    }
}

// Car Rental System
class CarRental
{
    public string CustomerName { get; set; }
    public string CarModel { get; set; }
    public int RentalDays { get; set; }
    public double TotalCost { get; private set; }

    public CarRental(string customerName, string carModel, int rentalDays)
    {
        CustomerName = customerName;
        CarModel = carModel;
        RentalDays = rentalDays;
        CalculateTotalCost();
    }

    private void CalculateTotalCost()
    {
        double dailyRate = 50.0; // Example daily rate
        TotalCost = RentalDays * dailyRate;
    }
}
