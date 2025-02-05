using System;

// Product Inventory
class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    private static int totalProducts = 0;

    public Product(string productName, double price)
    {
        ProductName = productName;
        Price = price;
        totalProducts++;
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product: {ProductName}, Price: {Price}");
    }

    public static void DisplayTotalProducts()
    {
        Console.WriteLine($"Total Products: {totalProducts}");
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter Product Name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter Product Price: ");
        double productPrice = Convert.ToDouble(Console.ReadLine());
        Product product = new Product(productName, productPrice);
        product.DisplayProductDetails();
        Product.DisplayTotalProducts();
	}
}