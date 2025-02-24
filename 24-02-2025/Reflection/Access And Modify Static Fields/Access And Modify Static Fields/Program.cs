
using System;
using System.Reflection;
namespace Access_And_Modify_Static_Fields
{
    class Configuration
    {
        private static string API_KEY = "DEFAULT_KEY";
        public static void ShowAPIKey()
        {
            Console.WriteLine($"Current API_KEY:{API_KEY}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before Modification:");
            Configuration.ShowAPIKey();

            Type configType = typeof(Configuration);

            FieldInfo apiKeyField = configType.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

            if (apiKeyField != null)
            {
                Console.Write("\nEnter new API Key: ");
                string newApiKey = Console.ReadLine();

                apiKeyField.SetValue(null, newApiKey); 

                Console.WriteLine("\nAfter Modification:");
                Configuration.ShowAPIKey();
            }
            else
            {
                Console.WriteLine("Error: API_KEY field not found.");
            }
        }
    }
}
