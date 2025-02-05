using System;

class Student
{
    public int id { get; set; }
    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; private set; }

    public Student(string Name, string email, string password)
    {
        Random random = new Random();
        this.id = random.Next(1000, 9999); 
        this.Name = Name;
        this.email = email;
        this.password = password;
    }

   
    public void UserRegistration()
    {
        Console.WriteLine("Enter User Name:");
        this.Name = Console.ReadLine();
        Console.WriteLine("Enter User Email:");
        this.email = Console.ReadLine();
        Console.WriteLine("Set Password:");
        this.password = Console.ReadLine();  
        Console.WriteLine("Successfully Registered!");
    }

 
    public void UserLogin()
    {
        Console.WriteLine("Enter  registered email:");
        string inputEmail = Console.ReadLine();
        if (inputEmail == email)
        {
            Console.WriteLine("Enter  password");
            string inputPassword = Console.ReadLine();
            if (inputPassword == password)
            {
                Console.WriteLine("Logged in Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Password");
            }
        }
        else
        {
            Console.WriteLine("Invalid Email or Not Registered yet");
        }
    }


    public void UpdateUserLogin()
    {
        Console.WriteLine("Enter your email to update your password:");
        string inputEmail = Console.ReadLine();
        if (inputEmail == email)
        {
            Console.WriteLine("Enter your current password:");
            string currentPassword = Console.ReadLine();
            if (currentPassword == password)
            {
                Console.WriteLine("Enter new Password");
                password = Console.ReadLine();  
                Console.WriteLine("Password updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Password");
            }
        }
        else
        {
            Console.WriteLine("Invalid Email or Not Registered yet");
        }
    }

    static void Main(string[] args)
    {
        Student student = null; 

        while (true)
        {
           
            Console.WriteLine("\n1. User Registration");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. Update User Login");
            Console.WriteLine("4. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    student = new Student("", "", ""); 
                    student.UserRegistration();
                    break;

                case 2:
                    if (student == null)
                    {
                        Console.WriteLine("You need to register first.");
                    }
                    else
                    {
                        student.UserLogin();
                    }
                    break;

                case 3:
                    if (student == null)
                    {
                        Console.WriteLine("You need to register first.");
                    }
                    else
                    {
                        student.UpdateUserLogin();
                    }
                    break;

                case 4:
                    Console.WriteLine("Successfully exited!");
                    return;

                default:
                    Console.WriteLine("Please enter a valid choice.");
                    break;
            }
        }
    }
}