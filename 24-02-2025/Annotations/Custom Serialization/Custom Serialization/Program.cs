using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace CustomJsonSerialization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonFieldAttribute : Attribute
    {
        public string Name { get; }
        public JsonFieldAttribute(string name)
        {
            this.Name = name;
        }
    }

    public class User
    {
        [JsonField("user_name")]
        private string _username;

        [JsonField("user_age")]
        private int _age;

        public User(string username, int age)
        {
            _username = username;
            _age = age;
        }

        public string ToJson()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");

            Type type = this.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            List<string> jsonPairs = new List<string>();

            foreach (FieldInfo field in fields)
            {
                var attribute = field.GetCustomAttribute<JsonFieldAttribute>();
                if (attribute != null)
                {
                    string key = attribute.Name;
                    string value = field.GetValue(this).ToString();

                    // Check if value is a string, add quotes
                    if (field.FieldType == typeof(string))
                    {
                        value = $"\"{value}\"";
                    }

                    jsonPairs.Add($"\"{key}\": {value}");
                }
            }

            jsonBuilder.Append(string.Join(", ", jsonPairs));
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("RheaLather", 24);
            string jsonString = user.ToJson();

            Console.WriteLine(" Serialized JSON:");
            Console.WriteLine(jsonString);
        }
    }
}
