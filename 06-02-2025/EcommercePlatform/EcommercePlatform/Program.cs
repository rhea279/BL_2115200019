using System;
using System.Collections.Generic;

namespace EcommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            ECommerce ecommerce = new ECommerce();

            while (true)
            {
                Console.WriteLine("\n===== E-Commerce Platform =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Register Customer");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Invalid input! Please enter a number between 1 and 5: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter Product Price: ");
                        decimal price;
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                        {
                            Console.Write("Invalid price! Enter a valid number: ");
                        }
                        ecommerce.AddProduct(new Product(productName, price));
                        Console.WriteLine($"Product '{productName}' added successfully!");
                        break;

                    case 2:
                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();
                        ecommerce.AddCustomer(new Customer(customerName));
                        Console.WriteLine($"Customer '{customerName}' registered successfully!");
                        break;

                    case 3:
                        Console.Write("Enter Customer Name: ");
                        string customerToOrder = Console.ReadLine();
                        ecommerce.PlaceOrder(customerToOrder);
                        break;

                    case 4:
                        ecommerce.ViewOrders();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using the E-Commerce Platform! 🛒");
                        return;
                }
            }
        
    }
    }
    class ECommerce
    {
        private List<Product> Products;
        private List<Customer> Customers;
        public ECommerce()
        {
            this.Products = new List<Product>();
            this.Customers = new List<Customer>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void PlaceOrder(string customerName)
        {
            Customer customer = Customers.Find(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                Console.WriteLine("Customer not found! Please register first.");
                return;
            }
            Console.WriteLine("Available Products:");
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i].Name} - ${Products[i].Price}");
            }

            Console.Write("Enter product numbers to add to order (comma-separated, e.g., 1,3): ");
            string[] productChoices = Console.ReadLine().Split(',');

            List<Product> selectedProducts = new List<Product>();

            foreach (var choice in productChoices)
            {
                if (int.TryParse(choice.Trim(), out int index) && index > 0 && index <= Products.Count)
                {
                    selectedProducts.Add(Products[index - 1]);
                }
            }

            if (selectedProducts.Count > 0)
            {
                Order newOrder = new Order(customer, selectedProducts);
                customer.AddOrder(newOrder);
                Console.WriteLine($"✅ Order placed successfully for {customer.Name}!");
            }
            else
            {
                Console.WriteLine("❌ No valid products selected. Order not placed.");
            }
        }

        public void ViewOrders()
        {
            Console.WriteLine("\n🛍️ Order History:");
            foreach (var customer in Customers)
            {
                customer.DisplayOrders();
            }
        }
    }
    class Customer {
        public string Name {  get; private set; }
        private List<Order> Orders;

        public Customer(string name) {
            Name = name;
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void DisplayOrders()
        {
            if (Orders.Count == 0)
            {
                Console.WriteLine($"{Name} has no orders ");
            }
            else
            {
                Console.WriteLine($"Orders for {Name}:");
                foreach (Order order in Orders)
                {
                    order.DisplayOrdersDetails();
                }
            }
        }
    }
    class Order {
        public static int OrderCounter = 1;
        public int OrderID { get; private set; }
        public Customer Customer { get; private set; }
        private List<Product> Products;

        public Order(Customer customer, List<Product> products) {
            OrderID = OrderCounter++;
            Customer = customer;
            Products = new List<Product>(products);
        }
        public void DisplayOrdersDetails()
        {
            Console.WriteLine($"Order Id :{OrderID} | Customer: {Customer.Name}");
            foreach(var  product in Products)
            {
                Console.WriteLine($" - {product.Name} (${product.Price}");
            }
        }
    }
    class Product {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price) {
            Name = name;
            Price = price;
        }

    }
}
