using System;

namespace OnlineRetailOrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for order details
            Console.Write("Enter Order ID: ");
            string orderId = Console.ReadLine();

            Console.Write("Enter Order Date (yyyy-mm-dd): ");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Tracking Number: ");
            string trackingNumber = Console.ReadLine();

            Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
            DateTime deliveryDate = DateTime.Parse(Console.ReadLine());

            // Create a DeliveredOrder object with user input
            DeliveredOrder deliveredOrder = new DeliveredOrder(orderId, orderDate, trackingNumber, deliveryDate);
            Console.WriteLine("\nOrder Status:");
            deliveredOrder.GetOrderStatus(); // Display order status
        }
    }

    // Base class representing a general order
    class Order
    {
        public string OrderId { get; set; } // Unique identifier for the order
        public DateTime OrderDate { get; set; } // Date when the order was placed

        // Constructor to initialize order properties
        public Order(string orderId, DateTime orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
        }

        // Virtual method to display order status
        public virtual void GetOrderStatus()
        {
            Console.WriteLine("Order Information:");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Order Date: {OrderDate.ToShortDateString()}");
            Console.WriteLine("Status: Order Placed");
        }
    }

    // Derived class representing a shipped order
    class ShippedOrder : Order
    {
        public string TrackingNumber { get; set; } // Tracking number for the shipment

        // Constructor to initialize shipped order properties
        public ShippedOrder(string orderId, DateTime orderDate, string trackingNumber)
            : base(orderId, orderDate)
        {
            TrackingNumber = trackingNumber;
        }

        // Override method to display shipped order status
        public override void GetOrderStatus()
        {
            base.GetOrderStatus();
            Console.WriteLine($"Tracking Number: {TrackingNumber}");
            Console.WriteLine("Status: Order Shipped");
        }
    }

    // Derived class representing a delivered order
    class DeliveredOrder : ShippedOrder
    {
        public DateTime DeliveryDate { get; set; } // Date when the order was delivered

        // Constructor to initialize delivered order properties
        public DeliveredOrder(string orderId, DateTime orderDate, string trackingNumber, DateTime deliveryDate)
            : base(orderId, orderDate, trackingNumber)
        {
            DeliveryDate = deliveryDate;
        }

        // Override method to display delivered order status
        public override void GetOrderStatus()
        {
            base.GetOrderStatus();
            Console.WriteLine($"Delivery Date: {DeliveryDate.ToShortDateString()}");
            Console.WriteLine("Status: Order Delivered");
        }
    }
}
