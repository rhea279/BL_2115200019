using System;
using System.Collections.Generic;

namespace Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set Library Name
            Book.LibraryName = "Central City Library";
            List<Book> books = new List<Book>();

            while (true) {
                Console.WriteLine("\n ==== Student Management System ====");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Display Book Details");
                Console.WriteLine("3. Display library Name");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 5):");
                }

                switch (choice) { 
                    case 1:
                        Console.WriteLine("Enter Book Title :");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Author name :");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter Book ISBN :");
                        int isbn = int.Parse(Console.ReadLine());

                        books.Add(new Book(name, author, isbn));
                        Console.WriteLine("\nBook Added Successfully!");
                        break;

                    case 2:

                        Console.WriteLine("Enter ISBN to View Details :");
                        int searchNum;
                        while (!int.TryParse(Console.ReadLine(), out searchNum))
                        {
                            Console.WriteLine("Enter a Valid ISBN!");
                        }
                        Book book = books.Find(b=> b.ISBN == searchNum);
                        if (book != null)
                        {
                            // Use is operator to check if object is a Patient instance
                            if (book is Book)
                            {
                                book.DisplayBookDetails();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Book Not Found");
                        }

                        break;
                    case 3:
                        Book.DisplayLibraryName();
                        break;
                    case 4:
                        Console.WriteLine("Thank You for using Library management System!");
                        return;


                }
            }

        }
    }
    class Book { 
        public static string LibraryName ="Default Library";
        public readonly int  ISBN;
        public string Title;
        public string Author;
       
        //constructor for book
        public Book(string Title, string Author, int ISBN) { 
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
        }

        // Static method to display library name
        public static  void DisplayLibraryName() {
                Console.WriteLine($"Library Name : {LibraryName}");
        }

        //  method to display book details
        public void DisplayBookDetails() {
            if (this is Book)
            {
                Console.WriteLine($"\nBook Title  : {Title}");
                Console.WriteLine($"Book Author : {Author}");
                Console.WriteLine($"ISBN        : {ISBN}");
            }
        }
    }
}
