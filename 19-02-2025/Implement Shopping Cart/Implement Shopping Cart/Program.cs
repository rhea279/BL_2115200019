using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    static Dictionary<string, double> productPrices = new Dictionary<string, double>();
    static LinkedList<KeyValuePair<string, double>> cartOrder = new LinkedList<KeyValuePair<string, double>>();
    static SortedDictionary<double, List<string>> sortedCart = new SortedDictionary<double, List<string>>();

    static void Main()
    {
        Console.WriteLine("Enter number of products to add:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter product name: ");
            string product = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            AddToCart(product, price);
        }

        Console.WriteLine("\nShopping Cart (Order of Addition):");
        foreach (var item in cartOrder)
        {
            Console.WriteLine($"{item.Key}: INR{item.Value}");
        }

        Console.WriteLine("\nShopping Cart (Sorted by Price):");
        foreach (var entry in sortedCart)
        {
            foreach (var product in entry.Value)
            {
                Console.WriteLine($"{product}: INR{entry.Key}");
            }
        }
    }

    static void AddToCart(string product, double price)
    {
        productPrices[product] = price;
        cartOrder.AddLast(new KeyValuePair<string, double>(product, price));

        if (!sortedCart.ContainsKey(price))
        {
            sortedCart[price] = new List<string>();
        }
        sortedCart[price].Add(product);
    }
}
