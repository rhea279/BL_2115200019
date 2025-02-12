using System;
using System.Collections.Generic;
using System.Net;
namespace Library_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            while (true) {
                Console.WriteLine("\n---- Library Management System ----");
                Console.WriteLine("1. Add a new book at the beginning, end, or at a specific position");
                Console.WriteLine("2. Remove a book by Book ID");
                Console.WriteLine("3. Search for a book by Book Title or Author");
                Console.WriteLine("4. Update a book’s Availability Status");
                Console.WriteLine("5. Display all books in forward and reverse order");
                Console.WriteLine("6. Count the total number of books in the library");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice){
                    case 1:
                        Console.WriteLine("Enter Book Title :");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Author Name :");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter Genre :");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Enter Book Id :");
                        int bookId= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Book Availability:");
                        bool availability = Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Where do you want to add the book?\n1. At the beginning \n2. At the end \n3. At a particular position");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                library.AddBookAtBeginning(title, author, genre, bookId, availability);
                                break;
                            case 2:
                                library.AddBookAtEnd(title, author, genre, bookId, availability);
                                break;
                            case 3:
                                Console.WriteLine("Enter the position at which book should be added:");
                                int position = Convert.ToInt32(Console.ReadLine());
                                library.AddBookAtPosition(title, author, genre, bookId, availability,position);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Book Id which is to be removed:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        library.RemoveBookById(id);
                        break;
                    case 3:
                        Console.WriteLine("Search for a book by \n1. Book Title or\n2. Author");
                        int option1 = Convert.ToInt32(Console.ReadLine());
                        switch (option1)
                        {
                            case 1:
                                Console.WriteLine("Enter Book title to search:");
                                string bookTitle = Console.ReadLine();
                                library.SearchByTitle(bookTitle);
                                break;
                            case 2:
                                Console.WriteLine("Enter Book Author to search:");
                                string bookAuthor = Console.ReadLine();
                                library.SearchByAuthor(bookAuthor);
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("Enter Book ID to update availability: ");
                        int bookID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Is Available (true/false): ");
                        bool isAvailable = Convert.ToBoolean(Console.ReadLine());
                        library.UpdateAvailability(bookID, isAvailable);
                        break;

                    case 5:
                        Console.WriteLine("\nBooks in Forward Order:");
                        library.DisplayBook();
                        Console.WriteLine("\nBooks in Reverse Order:");
                        library.DisplayBookReverse();
                        break;

                    case 6:
                        library.CountTotalBooks();
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            }
            }
    }
    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int BookId;
        public bool Availability;
        public Book Next;
        public Book Prev;
        public Book(string title, string author, string genre, int bookId, bool availablility)
        {
            Title = title;
            Author = author;
            Genre = genre;
            BookId = bookId;
            Availability = availablility;
            Next = null;
            Prev = null;
        }
    }
    class Library
    {
        private Book head;
        private Book tail;

        // Add Book at the beginning
        public void AddBookAtBeginning(string title, string author,string genre, int bookId, bool availability)
        {
            Book newBook = new Book(title,author,genre,bookId,availability);
            if (head == null)
            {
                head = tail = newBook;
            }
            else
            {
                newBook.Next = head;
                head.Prev = newBook;
                head = newBook;
            }
        }

        // Add Book at the end
        public void AddBookAtEnd(string title, string author, string genre, int bookId, bool availability)
        {
            Book newBook = new Book(title, author, genre, bookId, availability);
            if (head == null)
            {
                head = tail = newBook;
            }
            else
            {
                tail.Next = newBook;
                newBook.Prev = tail;
                tail = newBook;
            }
        }

        // Add Book at a specific position
        public void AddBookAtPosition(string title, string author, string genre, int bookId, bool availability, int position)
        {
            Book newBook = new Book(title, author, genre, bookId, availability);

            if (position < 1)
            {
                Console.WriteLine("Invalid position!");
                return;
            }

            if (position == 1)
            {
                AddBookAtBeginning(title,author,genre,bookId,availability);
                return;
            }

            Book temp = head;
            for (int i = 1; temp != null && i < position - 1; i++)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                Console.WriteLine("Position out of range!");
                return;
            }

            newBook.Next = temp.Next;
            if (temp.Next != null)
            {
                temp.Next.Prev = newBook;
            }
            newBook.Prev = temp;
            temp.Next = newBook;

            if (newBook.Next == null)
            {
                tail = newBook;
            }
        }
        //Remove a book by Book ID
        public void RemoveBookById(int bookId)
        {
            if (head == null)
            {
                Console.WriteLine("No book available.");
                return;
            }

            Book temp = head;

            while (temp != null && temp.BookId != bookId)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (temp == head)
            {
                head = head.Next;
                if (head != null) head.Prev = null;
            }
            else if (temp == tail)
            {
                tail = tail.Prev;
                if (tail != null) tail.Next = null;
            }
            else
            {
                temp.Prev.Next = temp.Next;
                temp.Next.Prev = temp.Prev;
            }

            Console.WriteLine($"Book '{bookId}' removed successfully.");
        }

        //Search for a book by Book Title or Author
        public void SearchByTitle(string title)
        {
            Book temp = head;
            bool found = false;
            while (temp != null)
            {
                if (temp.Title.ToLower() == title.ToLower())
                {
                    Console.WriteLine($"Title: {temp.Title}\n Author: {temp.Author}\n Genre: {temp.Genre} \nBook Id: {temp.BookId} \nAvailablility : {temp.Availability}");
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
            {
                Console.WriteLine("Book not found");
            }
        }

        // Search for book by author
        public void SearchByAuthor(string author)
        {
            Book temp = head;
            bool found = false;
            while (temp != null)
            {
                if (temp.Author.ToLower() == author.ToLower())
                {
                    Console.WriteLine($"Title: {temp.Title}\n Author: {temp.Author}\n Genre: {temp.Genre} \nBook Id: {temp.BookId} \nAvailablility : {temp.Availability}");
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
            {
                Console.WriteLine("No Book found.");
            }
        }
        //Update a book’s Availability Status
        public void UpdateAvailability(int bookId,bool availability)
        {
            Book temp = head;
            while (temp != null)
            {
                if (temp.BookId == bookId)
                {
                    temp.Availability = availability;
                    Console.WriteLine("Availability Updated");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Book not found");
        }
        //Display all books in forward order.
        public void DisplayBook()
        {
            if (head == null)
            {
                Console.WriteLine("Library is empty");
                return;
            }
            Book temp = head;
            while (temp != null)
            {
                Console.WriteLine($"\n----Book Detail ----");
                Console.WriteLine($"Book Title : {temp.Title}\nAuthor : {temp.Author}\nGenre : {temp.Genre}\nBook Id : {temp.BookId}\nAvailability Status : {temp.Availability}");
                temp = temp.Next;
            }
        }
        //Display all books in reverse order.
        public void DisplayBookReverse()
        {
            if(head == null)
            {
                Console.WriteLine("Library is empty");
                return;
            }
            Book temp = tail;
            while (temp != null) {
                Console.WriteLine($"\n----Book Detail ----");
                Console.WriteLine($"Book Title : {temp.Title}\nAuthor : {temp.Author}\nGenre : {temp.Genre}\nBook Id : {temp.BookId}\nAvailability Status : {temp.Availability}");
                temp = temp.Prev;
            }
        }
        //Count the total number of books in the library
        public void CountTotalBooks()
        {
            Book temp = head;
            int total = 0;
            while (temp != null)
            {
                total++;
                temp = temp.Next;
            }
            Console.WriteLine($"Total number of books in library : {total}");
        }
    }
}
