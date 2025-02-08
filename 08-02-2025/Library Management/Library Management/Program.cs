using System;

namespace Library_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            int publicationYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Author Name: ");
            string authorName = Console.ReadLine();

            Console.Write("Enter Author Bio: ");
            string authorBio = Console.ReadLine();
            //Display details of the book and author
            Author book = new Author(title, publicationYear, authorName, authorBio);
            Console.WriteLine("\nBook Information:");
            book.DisplayInfo();
        }
    }
    //Define a superclass Book
    class Book
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public Book(string title, int publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
        }
        //Show details of the book
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
        }
    }
    //Define a subclass Author
    class Author : Book
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public Author(string title, int publicationYear, string name, string bio)
            : base(title, publicationYear)
        {
            Name = name;
            Bio = bio;
        }
        //Show details of the author
        public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Author Name: {Name}");
            Console.WriteLine($"Bio : {Bio}");
        }
    }
}