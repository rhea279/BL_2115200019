using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }  // Encrypted
    public string Department { get; set; }
    public string Salary { get; set; } // Encrypted
}

class Program
{
    private static readonly string encryptionKey = "YourStrongKey1234"; // Must be 16, 24, or 32 bytes for AES

    static void Main()
    {
        Console.WriteLine("Enter CSV file path to store encrypted data:");
        string csvFilePath = Console.ReadLine();

        Console.WriteLine("Enter CSV file path to read and decrypt data:");
        string decryptedFilePath = Console.ReadLine();

        // Sample employees
        List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "John Doe", Email = "john@example.com", Department = "IT", Salary = "75000" },
            new Employee { ID = 2, Name = "Alice Smith", Email = "alice@example.com", Department = "HR", Salary = "65000" },
            new Employee { ID = 3, Name = "Bob Brown", Email = "bob@example.com", Department = "Finance", Salary = "82000" }
        };

        // Write encrypted CSV
        EncryptAndWriteCsv(employees, csvFilePath);

        // Read and decrypt CSV
        List<Employee> decryptedEmployees = ReadAndDecryptCsv(csvFilePath);

        // Display decrypted data
        Console.WriteLine("\nDecrypted Employee Data:");
        foreach (var emp in decryptedEmployees)
        {
            Console.WriteLine($"{emp.ID}, {emp.Name}, {emp.Email}, {emp.Department}, {emp.Salary}");
        }
    }

    static void EncryptAndWriteCsv(List<Employee> employees, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("ID,Name,Email,Department,Salary"); // Header

                foreach (var emp in employees)
                {
                    string encryptedEmail = Encrypt(emp.Email, encryptionKey);
                    string encryptedSalary = Encrypt(emp.Salary, encryptionKey);

                    writer.WriteLine($"{emp.ID},{emp.Name},{encryptedEmail},{emp.Department},{encryptedSalary}");
                }
            }
            Console.WriteLine($"Encrypted CSV file created at: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing encrypted CSV: {ex.Message}");
        }
    }

    static List<Employee> ReadAndDecryptCsv(string filePath)
    {
        List<Employee> employees = new List<Employee>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) { isHeader = false; continue; }

                    string[] columns = line.Split(',');
                    if (columns.Length < 5) continue;

                    employees.Add(new Employee
                    {
                        ID = int.Parse(columns[0].Trim()),
                        Name = columns[1].Trim(),
                        Email = Decrypt(columns[2].Trim(), encryptionKey),
                        Department = columns[3].Trim(),
                        Salary = Decrypt(columns[4].Trim(), encryptionKey)
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading decrypted CSV: {ex.Message}");
        }

        return employees;
    }

    static string Encrypt(string text, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Ensure key is 32 bytes
            aesAlg.IV = new byte[16]; // 16-byte IV (Initialization Vector)

            using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(text);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    static string Decrypt(string cipherText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Ensure key is 32 bytes
            aesAlg.IV = new byte[16]; // 16-byte IV

            using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
            using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
