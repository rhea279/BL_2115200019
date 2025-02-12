using System;

class Movie
{
    public string Title;
    public string Director;
    public int Year;
    public double Rating;
    public Movie Next;
    public Movie Prev;

    public Movie(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        Next = null;
        Prev = null;
    }
}

class MovieManagement
{
    private Movie head;
    private Movie tail;

    // Add movie at the beginning
    public void AddMovieAtBeginning(string title, string director, int year, double rating)
    {
        Movie newMovie = new Movie(title, director, year, rating);
        if (head == null)
        {
            head = tail = newMovie;
        }
        else
        {
            newMovie.Next = head;
            head.Prev = newMovie;
            head = newMovie;
        }
    }

    // Add movie at the end
    public void AddMovieAtEnd(string title, string director, int year, double rating)
    {
        Movie newMovie = new Movie(title, director, year, rating);
        if (head == null)
        {
            head = tail = newMovie;
        }
        else
        {
            tail.Next = newMovie;
            newMovie.Prev = tail;
            tail = newMovie;
        }
    }

    // Add movie at a specific position
    public void AddMovieAtPosition(string title, string director, int year, double rating, int position)
    {
        Movie newMovie = new Movie(title, director, year, rating);

        if (position < 1)
        {
            Console.WriteLine("Invalid position!");
            return;
        }

        if (position == 1)
        {
            AddMovieAtBeginning(title, director, year, rating);
            return;
        }

        Movie temp = head;
        for (int i = 1; temp != null && i < position - 1; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Position out of range!");
            return;
        }

        newMovie.Next = temp.Next;
        if (temp.Next != null)
        {
            temp.Next.Prev = newMovie;
        }
        newMovie.Prev = temp;
        temp.Next = newMovie;

        if (newMovie.Next == null)
        {
            tail = newMovie;
        }
    }

    // Remove a movie by title
    public void RemoveMovieByTitle(string title)
    {
        if (head == null)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        Movie temp = head;

        while (temp != null && temp.Title != title)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Movie not found.");
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

        Console.WriteLine($"Movie '{title}' removed successfully.");
    }

    // Search for movies by Director
    public void SearchByDirector(string director)
    {
        Movie temp = head;
        bool found = false;
        while (temp != null)
        {
            if (temp.Director.ToLower() == director.ToLower())
            {
                Console.WriteLine($"Title: {temp.Title}, Year: {temp.Year}, Rating: {temp.Rating}");
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
        {
            Console.WriteLine("No movies found for this director.");
        }
    }

    // Search for movies by Rating
    public void SearchByRating(double rating)
    {
        Movie temp = head;
        bool found = false;
        while (temp != null)
        {
            if (temp.Rating == rating)
            {
                Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.Year}");
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
        {
            Console.WriteLine("No movies found with this rating.");
        }
    }

    // Update a movie's rating by title
    public void UpdateMovieRating(string title, double newRating)
    {
        Movie temp = head;
        while (temp != null)
        {
            if (temp.Title == title)
            {
                temp.Rating = newRating;
                Console.WriteLine($"Movie '{title}' rating updated to {newRating}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Movie not found.");
    }

    // Display movies in forward order
    public void DisplayMoviesForward()
    {
        if (head == null)
        {
            Console.WriteLine("\nNo movies available.");
            return;
        }

        Movie temp = head;
        Console.WriteLine("\nMovies List (Forward Order):");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.Year}, Rating: {temp.Rating}");
            temp = temp.Next;
        }
    }

    // Display movies in reverse order
    public void DisplayMoviesReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("\nNo movies available.");
            return;
        }

        Movie temp = tail;
        Console.WriteLine("\nMovies List (Reverse Order):");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.Year}, Rating: {temp.Rating}");
            temp = temp.Prev;
        }
    }
}

class Program
{
    static void Main()
    {
        MovieManagement movieList = new MovieManagement();
        while (true)
        {
            Console.WriteLine("\n--- Movie Management System ---");
            Console.WriteLine("1. Add Movie at Beginning");
            Console.WriteLine("2. Add Movie at End");
            Console.WriteLine("3. Add Movie at Specific Position");
            Console.WriteLine("4. Remove Movie by Title");
            Console.WriteLine("5. Search by Director");
            Console.WriteLine("6. Search by Rating");
            Console.WriteLine("7. Update Movie Rating");
            Console.WriteLine("8. Display Movies Forward");
            Console.WriteLine("9. Display Movies Reverse");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    Console.Write("\nEnter Movie Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Director: ");
                    string director = Console.ReadLine();
                    Console.Write("Enter Year of Release: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Rating: ");
                    double rating = Convert.ToDouble(Console.ReadLine());

                    if (choice == 1) movieList.AddMovieAtBeginning(title, director, year, rating);
                    else if (choice == 2) movieList.AddMovieAtEnd(title, director, year, rating);
                    else
                    {
                        Console.Write("Enter Position: ");
                        int position = Convert.ToInt32(Console.ReadLine());
                        movieList.AddMovieAtPosition(title, director, year, rating, position);
                    }
                    break;

                case 4:
                    Console.Write("\nEnter Movie Title to Remove: ");
                    movieList.RemoveMovieByTitle(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("\nEnter Director Name: ");
                    movieList.SearchByDirector(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("\nEnter Rating to Search: ");
                    movieList.SearchByRating(Convert.ToDouble(Console.ReadLine()));
                    break;

                case 7:
                    Console.Write("\nEnter Movie Title: ");
                    string updateTitle = Console.ReadLine();
                    Console.Write("Enter New Rating: ");
                    movieList.UpdateMovieRating(updateTitle, Convert.ToDouble(Console.ReadLine()));
                    break;

                case 8: movieList.DisplayMoviesForward(); break;
                case 9: movieList.DisplayMoviesReverse(); break;
                case 10: return;
                default: Console.WriteLine("Invalid choice! Try again."); break;
            }
        }
      }
}
