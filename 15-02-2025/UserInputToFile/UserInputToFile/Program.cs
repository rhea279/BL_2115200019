using System;
using System.IO;

namespace UserInputToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENter the file path to save input:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Enter text to write to file (Type 'EXIT' to stop):");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (userInput.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                            break;
                        writer.WriteLine(userInput);
                    }
                }
                Console.WriteLine("User Input has been successfully written to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
