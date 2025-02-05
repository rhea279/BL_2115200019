using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Product
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Product> products = new List<Product>();

            while (true)
            {
                //Menu Options
                Console.WriteLine("\n ==== Shopping Cart System ====");
                Console.WriteLine("1. Add Products to Cart");
                Console.WriteLine("2. Display Product Details");
                Console.WriteLine("3. Update Discount");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                //Input validation: Ensure choice is between 1 and 4
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 4):");
                }

                switch (choice)
                {
                    case 1:
                        //Add New Product Details
                        Console.WriteLine("Enter Product Id :");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Product Name :");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Product Price :");
                        int price = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Product Quantity :");
                        int quantity = int.Parse(Console.ReadLine());

                        products.Add(new Product(id, name, price, quantity));
                        Console.WriteLine("\nProduct Details Added Successfully!");
                        break;

                    case 2:
                        //Display Product Details
                        Console.WriteLine("\nEnter Product Id to View Details :");
                        int searchNum;
                        while (!int.TryParse(Console.ReadLine(), out searchNum))
                        {
                            Console.WriteLine("Enter a Valid Product Id!");
                        }
                        Product product = products.Find(p => p.productId == searchNum);
                        if (product != null)
                        {
                            // Use is operator to check if object is a Patient instance
                            if (product is Product)
                            {
                                product.DisplayProductDetails();
                            }

                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found");
                        }
                        break;
                    case 3:
                        // Update the discount percentage

                        Console.Write("Enter new discount percentage: ");
                        double newDiscount = double.Parse(Console.ReadLine());
                        Product.UpdateDiscount(newDiscount);
                        break;
                    case 4:
                        //Exit Program
                        Console.WriteLine("\nThank You for using Shopping Cart System!");
                        return;
                }

            }
        }
        class Product
        {
            private static double discount;
            public string productName;
            public int price;
            public int quantity;
            public readonly int productId;

            // Constructor to initialize product details
            public Product(int productId, string productName, int price, int quantity)
            {
                this.productId = productId;
                this.productName = productName;
                this.price = price;
                this.quantity = quantity;
            }
            // Static method to update the discount percentage
            public static void UpdateDiscount(double newDiscount)
            {
                discount = newDiscount;
                Console.WriteLine($"\n Discount Updated to {discount}%");
            }

            // Instance method to display product details
            public void DisplayProductDetails()
            {
                if (this is Product)
                {
                    Console.WriteLine($"\nProduct ID: {productId}");
                    Console.WriteLine($"Product Name: {productName}");
                    Console.WriteLine($"Price: ${price}");
                    Console.WriteLine($"Quantity: {quantity}");
                    Console.WriteLine($"Discount: {discount}%");
                    Console.WriteLine($"Total Price after Discount: ${price * quantity * (1 - discount / 100)}");

                }
            }
        }
    }
}
