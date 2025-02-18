using System;
using System.Collections.Generic;


namespace Smart_Warehouse_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            electronicsStorage.AddItem(new Electronics("Laptop", 1200, "Dell"));
            electronicsStorage.AddItem(new Electronics("Smartphone", 800, "Samsung"));

            Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            groceriesStorage.AddItem(new Groceries("Milk", 2.5, DateTime.Now.AddDays(10)));
            groceriesStorage.AddItem(new Groceries("Bread", 1.2, DateTime.Now.AddDays(3)));

            Storage<Furniture> furnitureStorage = new Storage<Furniture>();
            furnitureStorage.AddItem(new Furniture("Chair", 50, "Wood"));
            furnitureStorage.AddItem(new Furniture("Table", 120, "Metal"));

            Console.WriteLine("Electronics Storage:");
            electronicsStorage.DisplayItems();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\nGroceries Storage:");
            groceriesStorage.DisplayItems();
            Console.WriteLine("--------------------------------------------"); 
            Console.WriteLine("\nFurniture Storage:");
            furnitureStorage.DisplayItems();
        }


    }
    //Create an abstract class WarehouseItem that all items extend
    public abstract class WarehouseItem
    {
        public string Name { get; set; }
        protected double Price { get; set; }
        public WarehouseItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public abstract void DisplayInfo();
    }
    //Create Class Electronics 
    class Electronics : WarehouseItem {
        public string Brand { get; set; }
        public Electronics(string name, double price, string brand)
            : base(name, price)
        {
            Brand = brand;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"\nName: {Name}\nPrice: {Price}\nBrand: {Brand}");
        }
    }
    //Create Class Grocerries
    class Groceries : WarehouseItem { 
        public DateTime ExpiryDate { get; set; }
        public Groceries(string name,double price, DateTime expiryDate)
            : base(name, price) 
        {
            ExpiryDate = expiryDate;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"\nName: {Name}\nPrice: {Price}\nExpiry Date: {ExpiryDate}");
        }
    }
    //Create Class Furniture
    class Furniture : WarehouseItem {
        public string Material { get; set; }
        public Furniture(string name, double price, string material)
            : base(name, price) 
        {
            Material = material;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"\nName: {Name}\nPrice: {Price}\nMaterial: {Material}");
        }
    }
    //Implement a generic class Storage<T> where T : WarehouseItem to store items safely
    public class Storage<T> where T:WarehouseItem
    {
        private List<T> items = new List<T>();
        public void AddItem(T item)
        {
            items.Add(item);
        }
        //Implement a method to display all items using List<T>
        public void DisplayItems()
        {
            foreach (T item in items)
            {
                item.DisplayInfo();
            }
        }
    }
}
