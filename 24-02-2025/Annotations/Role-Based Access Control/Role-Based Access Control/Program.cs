using System;
using System.Reflection;

namespace Role_Based_Access_Control
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        public string Role { get; }
        public RoleAllowedAttribute(string role)
        {
            this.Role = role;  
        }
    }

    class User
    {
        public string Role { get; }
        public User(string role)
        {
            Role = role;
        }
    }

    class SecureService
    {
        [RoleAllowed("ADMIN")]
        public void OnlyAdmin()
        {
            Console.WriteLine(" Only Admin can access");
        }

        [RoleAllowed("USER")]
        public void OnlyUser()
        {
            Console.WriteLine(" Only User can access");
        }
    }

    internal class Program
    {
        static void ExecuteAccess(User user, string methodName)
        {
            Type type = typeof(SecureService);
            MethodInfo method = type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine($"Error: Method {methodName} does not exist.");
                return;
            }

            var roleAttribute = method.GetCustomAttribute<RoleAllowedAttribute>();

            if (roleAttribute != null && roleAttribute.Role != user.Role)
            {
                Console.WriteLine(" Access Denied!");
                return;
            }

            SecureService service = new SecureService();
            method.Invoke(service, null);
        }

        static void Main(string[] args)
        {
            User adminUser = new User("ADMIN");
            User normalUser = new User("USER");

            Console.WriteLine("\nAdmin trying to access OnlyAdmin:");
            ExecuteAccess(adminUser, "OnlyAdmin");

            Console.WriteLine("\nUser trying to access OnlyAdmin:");
            ExecuteAccess(normalUser, "OnlyAdmin"); 

            Console.WriteLine("\nUser trying to access OnlyUser:");
            ExecuteAccess(normalUser, "OnlyUser");
        }
    }
}
