
using System;
using System.Runtime.InteropServices;

namespace Retrieve_Attributes_at_Runtime
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; }
        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
    [Author("JK Rowling")]
    class Sample
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is from Sample Class");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Sample);
            object[] attributes = type.GetCustomAttributes(typeof(AuthorAttribute), false);

            if (attributes.Length > 0)
            {
                AuthorAttribute authorAtt = (AuthorAttribute)attributes[0];
                Console.WriteLine($"Class: {type.Name} is written by {authorAtt.Name}");
            }
            else
            {
                Console.WriteLine($"No Author Attribute found for class '{type.Name}'");
            }
        }
    }
}
