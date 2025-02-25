
using System;
using System.IO;

namespace Read_And_Count_Rows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path of CSV File:");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader str = new StreamReader(filePath))
                {
                    string line;
                    int count = 0;
                    bool isHeader = true;
                    while ((line = str.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }
                        count++;
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("File is empty");
                    }
                    else
                    {
                        Console.WriteLine(count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
