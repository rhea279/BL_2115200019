using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 123);
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 456);
            Book book3 = new Book("1984", "George Orwell", 789);

            // Creating Library objects
            Library library1 = new Library("City Library");
            Library library2 = new Library("University Library");

            // Adding books to libraries
            library1.AddBooks(book1);
            library1.AddBooks(book2);

            library2.AddBooks(book2);
            library2.AddBooks(book3);

            // Displaying library contents
            library1.DisplayBooks();
            library2.DisplayBooks();


        }
    }
    //Define a Library class
    class Library
    {
        public string name { get; set; }
        List<Book> books;

        public Library(string Name)
        {
            name = Name;
            books = new List<Book>();
        }

        // Method to add books to the library
        public void AddBooks(Book book)
        {
            books.Add(book);
        }

        // Method to display books in the library
        public void DisplayBooks()
        {
            Console.WriteLine($"Welcome to {name}");
            foreach (var book in books)
            {
                book.DisplayBook();
            }
            Console.WriteLine();
        }
    }



    //Define a Book class
    class Book
    {
        string author { get; set; }
        string name { get; set; }
        int isbn { get; set; }

        public Book(string Name, string Author, int ISBN)
        {
            name = Name;
            author = Author;
            isbn = ISBN;
        }

        public void DisplayBook()
        {
            Console.WriteLine("\n==== Book Details ====");
            Console.WriteLine($"Book   : {name}");
            Console.WriteLine($"Author : {author}");
            Console.WriteLine($"ISBN   : {isbn}");
        }
    }


}