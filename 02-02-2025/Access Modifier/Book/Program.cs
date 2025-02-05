using System;
class Book
{
    public string ISBN { get; set; }
    protected string Title { get; set; }
    private string Author;

    public Book(string isbn, string title, string author)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
    }

    public void SetAuthor(string author)
    {
        Author = author;
    }

    public string GetAuthor()
    {
        return Author;
    }
}

class EBook : Book
{
    public EBook(string isbn, string title, string author) : base(isbn, title, author) {}

    public void DisplayDetails()
    {
        Console.WriteLine($"EBook - ISBN: {ISBN}, Title: {Title}, Author: {GetAuthor()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        EBook ebook = new EBook(isbn, title, author);
        ebook.DisplayDetails();
    }
}
