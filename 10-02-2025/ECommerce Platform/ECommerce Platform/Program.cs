using System;
using System.Collections.Generic;
namespace ECommerce_Platform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            while (true) {
                //Menu Option
                Console.WriteLine("\nE-Commerce Platform");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        //Case to Add a Product to the list
                        Console.WriteLine("Enter Product Type(Electronics/Clothing/Groceries");
                        string type = Console.ReadLine();

                        Console.WriteLine("Enter Product Id:");
                        string id = Console.ReadLine();

                        Console.WriteLine("Enter Product Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Product Price:");
                        double price = double.Parse(Console.ReadLine());

                        if (type.Equals("Electronics", StringComparison.OrdinalIgnoreCase)) {
                            products.Add(new Electronics(id, name, price));
                        }
                        else if (type.Equals("Clothing", StringComparison.OrdinalIgnoreCase))
                        {
                            products.Add(new Clothing(id, name, price));
                        }
                        else if (type.Equals("Groceries", StringComparison.OrdinalIgnoreCase))
                        {
                            products.Add(new Groceries(id, name, price));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Product Type!");
                        }
                        break;
                    case "2":
                        //Case to display the details of products in the list
                        if (products.Count == 0)
                        {
                            Console.WriteLine("No products available");
                        }
                        else
                        {
                            foreach (var product in products)
                            {
                                product.DisplayDetails();
                            }
                        }
                            break;
                    case "3":
                        //Case to exit the application
                                Console.WriteLine("Thank you for using E-Commerce Platform");
                                return;
                            default:
                                Console.WriteLine("Invalid Choice! Please select again");
                                break;
                            }
                        }
                }
            }

    }
    interface ITaxable
    {
        double CalculateTax();
        void GetTaxDetails();
    }
//Abstract Product class
    abstract class Product
    {
        //Field Properties
        public string productId { get; private set; }
        public string name { get; private set; }
        public double price { get; private set; }


        public Product(string productId, string name, double price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }
        //Abstract method
        public abstract double CalculateDiscount();

        public double GetFinalPrice()
        {
            double discount = CalculateDiscount();
            double tax = this is ITaxable taxable ? taxable.CalculateTax() : 0;
            return price - discount + tax;
        }
        //Display Product Details
        public void DisplayDetails()
        {
            Console.WriteLine("\n====Product Details====");
            Console.WriteLine($"Product Id   : {productId}");
            Console.WriteLine($"Product Name : {name}");
            Console.WriteLine($"Base Price   : {price}");
            Console.WriteLine($"Discount     : {CalculateDiscount()}");
            Console.WriteLine($"Final Price  : {GetFinalPrice()}");
        }

    }
    //Subclass Electronics
    class Electronics : Product {
        private double discountRate = 0.10;
        private double taxRate = 0.18;
        public Electronics(string productId, string name, double price)
            : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return price * discountRate;
        }
        public double CalculateTax()
        {
            return price * taxRate;
        }
        public string GetTaxDetails()
        {
            return $"Tax Rate : {taxRate * 100}%";
        }
    }
    //Subclass Clothing
    class Clothing : Product
    {
        private double discountRate = 0.15;
        private double taxRate = 0.05;

        public Clothing(string productId, string name, double price)
            : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return price * discountRate;
        }
        public double CalculateTax()
        {
            return price * taxRate;
        }
        public string GetTaxDetails()
        {
            return $"Tax Rate : {taxRate * 100}%";
        }
    }
    //Subclass Groceries
    class Groceries : Product {
        private double discountRate = 0.05;

        public Groceries(string productId, string name, double price)
            : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return price * discountRate;
        }
      
    }
