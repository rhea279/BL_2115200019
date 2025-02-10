using System;
using System.Collections.Generic;


namespace Library_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LibraryItem> items = new List<LibraryItem>();
            while (true) {
                Console.WriteLine("\nLibrary Management System:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display Items");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Item Type (Book/Magazine/DVD): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Item ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        if (type.Equals("Book", StringComparison.OrdinalIgnoreCase))
                        {
                            items.Add(new Book(id, title, author));
                        }
                        else if (type.Equals("Magazine", StringComparison.OrdinalIgnoreCase))
                        {
                            items.Add(new Magazine(id, title, author));
                        }
                        else if (type.Equals("DVD", StringComparison.OrdinalIgnoreCase))
                        {
                            items.Add(new DVD(id, title, author));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Item Type!");
                        }
                        break;

                    case "2":
                        if (items.Count == 0)
                        {
                            Console.WriteLine("No items available.");
                        }
                        else
                        {
                            Console.WriteLine("\nItem Details:");
                            foreach (var item in items)
                            {
                                item.GetItemDetails();
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("Thank you for using Library Management System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
    }
    //Implement an interface IReservable with methods ReserveItem() and CheckAvailability()
    interface IReservable
    {
        void ReserveItem();
        bool CheckAvailability();
    }
    //Define an abstract class LibraryItem with fields like itemId, title, and author.
    abstract class LibraryItem
    {
        public string itemId { get; private set; }
        public string name { get; set; }
        public string author { get; set; }
        public LibraryItem(string ItemId, string Name, string Author)
        {
            itemId = ItemId;
            name = Name;
            author = Author;
        }
        public abstract int GetLoanDuration();
        public void GetItemDetails()
        {
            Console.WriteLine("\n==== Item Details ====");
            Console.WriteLine($"Item ID   : {itemId}");
            Console.WriteLine($"Title     : {name}");
            Console.WriteLine($"Author    : {author}");
            Console.WriteLine($"Loan Duration: {GetLoanDuration()} days");
        }
    }
    //Create a subclass Book
    class Book : LibraryItem,IReservable { 
        public Book(string ItemId, string Name, string Author)
            :base (ItemId, Name, Author) { }
        public override int GetLoanDuration()
        {
            return 14;
        }
        public void ReserveItem()
        {
            Console.WriteLine("Book reserved.");
        }

        public bool CheckAvailability()
        {
            return true;
        }
    }
    //Create a subclass Magazine
    class Magazine : LibraryItem ,IReservable{
        public Magazine(string ItemId, string Name, string Author)
                : base(ItemId, Name, Author) { }
        public override int GetLoanDuration()
        {
            return 7;
        }
        public void ReserveItem()
        {
            Console.WriteLine("Magazine reserved.");
        }

        public bool CheckAvailability()
        {
            return true;
        }
    }
    ////Create a subclass DVD
    class DVD : LibraryItem ,IReservable{
        public DVD(string ItemId, string Name, string Author)
                : base(ItemId, Name, Author) { }
        public override int GetLoanDuration()
        {
            return 14;
        }
        public void ReserveItem()
        {
            Console.WriteLine("DVD reserved.");
        }

        public bool CheckAvailability()
        {
            return true;
        }
    }
}
