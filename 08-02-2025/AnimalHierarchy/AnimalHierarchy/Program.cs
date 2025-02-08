using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of subclasses
            Animal myDog = new Dog("Buddy", 3);
            Animal myCat = new Cat("Whiskers", 2);
            Animal myBird = new Bird("Tweety", 1);

            // Calling overridden methods
            myDog.MakeSound(); // Output: Dog barks
            myCat.MakeSound(); // Output: Cat meows
            myBird.MakeSound(); // Output: Bird chirps
        }
    }
    //Define a superclass Animal
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age) {
            Name = name;
            Age = age;
        }
        //Add a method MakeSound() that provides a generic sound message 
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }
    //Define subclasses Dog
    class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age) { }
        //override the MakeSound() method to provide its unique behavior
        public override void MakeSound()
        {
            Console.WriteLine("Dog Barks");
        }
    }
    //Define subclasses Cat
    class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }
        //override the MakeSound() method to provide its unique behavior
        public override void MakeSound()
        {
            Console.WriteLine("Cat Meows");
        }
    }
    //Define subclasses Bird
    class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age) { }
        //override the MakeSound() method to provide its unique behavior
        public override void MakeSound()
        {
            Console.WriteLine("Bird Chirps");
        }
    }
}

