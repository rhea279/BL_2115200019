
using System;
using System.Reflection;

namespace MaxLength_Attribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLengthAttribute:Attribute
    {
        public int Value { get; }
        public MaxLengthAttribute(int value)
        {
            this.Value = value;
        }
    }

    public class User
    {
        [MaxLength(8)]
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            private set
            {
                ValidateMaxLength(value);
                _username = value;
            }
        }
        public User(string username)
        {
            Username = username;
        }
        private void ValidateMaxLength(string value)
        {
            FieldInfo field = typeof(User).GetField("_username", BindingFlags.NonPublic | BindingFlags.Instance);
            var maxLengthAttribute = field.GetCustomAttribute<MaxLengthAttribute>();
            if(maxLengthAttribute!=null && value.Length > maxLengthAttribute.Value)
            {
                throw new ArgumentException($"Username exceeds maximum length of {maxLengthAttribute.Value} characters");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user1 = new User("Rhea");
                Console.WriteLine($"User Created: {user1.Username}");

                User user2 = new User("RheaLather");
                Console.WriteLine($"User Created: {user2.Username}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
