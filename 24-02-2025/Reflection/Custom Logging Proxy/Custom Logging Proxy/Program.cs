using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicProxyExample
{
    public interface IGreeting
    {
        void SayHello(string name);
    }

    public class Greeting : IGreeting
    {
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    public class LoggingProxy<T> : DispatchProxy where T : class
    {
        private T _instance;

        public static T Create(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance), "Instance cannot be null.");

            T proxy = Create<T, LoggingProxy<T>>();
            if (proxy is LoggingProxy<T> loggingProxy)
            {
                loggingProxy._instance = instance;
            }

            return proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine($"[LOG] Invoking method: {targetMethod.Name} with arguments: {string.Join(", ", args)}");
            return targetMethod.Invoke(_instance, args);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IGreeting greeting = new Greeting();
            IGreeting proxyGreeting = LoggingProxy<IGreeting>.Create(greeting);

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            proxyGreeting.SayHello(name);
        }
    }
}
