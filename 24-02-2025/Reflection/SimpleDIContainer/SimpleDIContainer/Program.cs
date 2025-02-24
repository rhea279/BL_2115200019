using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleDIContainer
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Property)]
    public class Inject : Attribute { }

    public class DIContainer
    {
        private readonly Dictionary<Type, Type> _registeredTypes = new();

        public void Register<TInterface, TImplementation>()
        {
            _registeredTypes[typeof(TInterface)] = typeof(TImplementation);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (!_registeredTypes.ContainsKey(type))
                throw new InvalidOperationException($"Type {type.Name} not registered in the container.");

            Type implementationType = _registeredTypes[type];

            ConstructorInfo constructor = implementationType
                .GetConstructors()
                .FirstOrDefault(c => c.GetCustomAttribute<Inject>() != null)
                ?? implementationType.GetConstructors().First();

            var parameters = constructor.GetParameters()
                .Select(p => Resolve(p.ParameterType))
                .ToArray();

            var instance = Activator.CreateInstance(implementationType, parameters);

            foreach (var field in implementationType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                         .Where(f => f.GetCustomAttribute<Inject>() != null))
            {
                field.SetValue(instance, Resolve(field.FieldType));
            }

            return instance;
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }

    public class Application
    {
        private readonly ILogger _logger;

        [Inject] 
        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Application is running...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DIContainer container = new();
            container.Register<ILogger, ConsoleLogger>();
            container.Register<Application, Application>();

            Application app = container.Resolve<Application>();

            app.Run();
        }
    }
}
