using System;
using System.Collections.Generic;
namespace Online_Food_Delivery_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FoodItem> order = new List<FoodItem>();
            while (true)
            {
                Console.WriteLine("\nOnline Food Delivery System:");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Display Order");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Food Type (Veg/NonVeg): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Item Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        if (type.Equals("Veg", StringComparison.OrdinalIgnoreCase))
                        {
                            order.Add(new VegItem(name, price, quantity));
                        }
                        else if (type.Equals("NonVeg", StringComparison.OrdinalIgnoreCase))
                        {
                            order.Add(new NonVegItem(name, price, quantity));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Food Type!");
                        }
                        break;

                    case "2":
                        if (order.Count == 0)
                        {
                            Console.WriteLine("No items in the order.");
                        }
                        else
                        {
                            Console.WriteLine("\nOrder Details:");
                            foreach (var item in order)
                            {
                                item.GetItemDetails();
                            }
                        }
                        break;

                    case "3":

                        Console.WriteLine("Thank you for using Online Food Delivery System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
        //Create interface IDiscountable with methods ApplyDiscount() and GetDiscountDetails()
        interface IDiscountable
        {
            void ApplyDiscount();
            string GetDiscountDetails();
        }
        //Define an abstract class FoodItem with fields like itemName, price, and quantity
        abstract class FoodItem
        {
            public string itemName { get; set; }
            public double price { get; private set; }
            public int quantity { get; set; }
            public FoodItem(string ItemName, double Price, int Quantity)
            {
                itemName = ItemName;
                price = Price;
                quantity = Quantity;
            }
            public abstract double CalculateTotalPrice();
            //Method to display the details of an item
            public void GetItemDetails()
            {
                Console.WriteLine("\n==== Item Details ====");
                Console.WriteLine($"Item Name  : {itemName}");
                Console.WriteLine($"Item Price : {price}INR");
                Console.WriteLine($"Quantity   : {quantity}");
                Console.WriteLine($"Total      : {CalculateTotalPrice()} INR");
            }

        }
        //Define subclass VegItem
        class VegItem : FoodItem, IDiscountable
        {
            private double discountRate = 0.15;
            public VegItem(string ItemName, double Price, int Quantity)
                : base(ItemName, Price, Quantity) { }
            public override double CalculateTotalPrice()
            {
                return price * quantity * (1 - discountRate);
            }
            public void ApplyDiscount()
            {
                Console.WriteLine("15% discount applied to Veg Item.");
            }

            public string GetDiscountDetails()
            {
                return "15% discount on all Veg Items.";
            }
        }
        //Define subclass NonVegItem
        class NonVegItem : FoodItem, IDiscountable
        {
            private double discountRate = 0.05;
            public NonVegItem(string ItemName, double Price, int Quantity)
                : base(ItemName, Price, Quantity) { }
            public override double CalculateTotalPrice()
            {
                return price * quantity * (1 - discountRate);
            }
            public void ApplyDiscount()
            {
                Console.WriteLine("5% discount applied to Non-Veg Item.");
            }

            public string GetDiscountDetails()
            {
                return "5% discount on all Non-Veg Items.";
            }
        }
    }
}
