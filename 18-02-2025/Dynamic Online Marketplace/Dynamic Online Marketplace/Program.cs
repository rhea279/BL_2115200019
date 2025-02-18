using System;
using System.Collections.Generic;

// Define the category classes
public class BookCategory
{
    public string CategoryName { get; set; } = "Books";
}

public class ClothingCategory
{
    public string CategoryName { get; set; } = "Clothing";
}

// Define a common interface for Product
public interface IProduct
{
    string ProductName { get; set; }
    decimal Price { get; set; }
    string GetProductInfo();
}

// Define the generic Product class implementing IProduct
public class Product<T> : IProduct where T : class
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public T Category { get; set; }

    public Product(string productName, decimal price, T category)
    {
        ProductName = productName;
        Price = price;
        Category = category;
    }

    public string GetProductInfo()
    {
        return $"{ProductName} is a product in the {Category.GetType().Name} category priced at ${Price}.";
    }
}

// Marketplace class for managing products
public class Marketplace
{
    public List<IProduct> products = new List<IProduct>();

    public void AddProduct<T>(Product<T> product) where T : class
    {
        products.Add(product);
    }

    // Generic method to apply discount to any product
    public void ApplyDiscount<T>(T product, double percentage) where T : IProduct
    {
        // Ensure product is not null and percentage is valid
        if (product != null && percentage > 0 && percentage < 100)
        {
            product.Price -= product.Price * (decimal)(percentage / 100);
            Console.WriteLine($"Discount applied. New price: ${product.Price}");
        }
        else
        {
            Console.WriteLine("Invalid discount percentage.");
        }
    }

    public void DisplayProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        foreach (var product in products)
        {
            Console.WriteLine(product.GetProductInfo());
        }
    }
}

public class Program
{
    public static void Main()
    {
        var marketplace = new Marketplace();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== Marketplace Menu =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Apply Discount");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProductMenu(marketplace);
                    break;
                case "2":
                    ApplyDiscountMenu(marketplace);
                    break;
                case "3":
                    marketplace.DisplayProducts();
                    Console.ReadLine(); // Wait for user input to proceed
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private static void AddProductMenu(Marketplace marketplace)
    {
        Console.Clear();
        Console.WriteLine("===== Add Product =====");
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Select category:");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. Clothing");
        string categoryChoice = Console.ReadLine();

        if (categoryChoice == "1")
        {
            var bookProduct = new Product<BookCategory>(productName, price, new BookCategory());
            marketplace.AddProduct(bookProduct);
            Console.WriteLine("Book product added.");
        }
        else if (categoryChoice == "2")
        {
            var clothingProduct = new Product<ClothingCategory>(productName, price, new ClothingCategory());
            marketplace.AddProduct(clothingProduct);
            Console.WriteLine("Clothing product added.");
        }
        else
        {
            Console.WriteLine("Invalid category choice.");
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine(); // Wait for user input before returning to main menu
    }

    private static void ApplyDiscountMenu(Marketplace marketplace)
    {
        Console.Clear();
        Console.WriteLine("===== Apply Discount =====");
        marketplace.DisplayProducts();

        Console.Write("Enter product name to apply discount: ");
        string productName = Console.ReadLine();

        IProduct selectedProduct = null;

        foreach (var product in marketplace.products)
        {
            if (product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
            {
                selectedProduct = product;
                break;
            }
        }

        if (selectedProduct != null)
        {
            Console.Write("Enter discount percentage: ");
            double discountPercentage = double.Parse(Console.ReadLine());
            marketplace.ApplyDiscount(selectedProduct, discountPercentage);
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine(); // Wait for user input before returning to main menu
    }
}
