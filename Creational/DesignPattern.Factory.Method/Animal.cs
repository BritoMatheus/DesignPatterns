using System;

namespace DesignPattern.Factory.Method
{
    // Product interface
    public interface IAnimal
    {
        void MakeSound();
        void Move();
    }

    // Concrete Products
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }

        public void Move()
        {
            Console.WriteLine("Dog is running");
        }
    }

    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }

        public void Move()
        {
            Console.WriteLine("Cat is walking gracefully");
        }
    }

    public class Bird : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Tweet! Tweet!");
        }

        public void Move()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    // Creator abstract class
    public abstract class AnimalFactory
    {
        // Factory Method
        public abstract IAnimal CreateAnimal();

        // Template method that uses the factory method
        public void InteractWithAnimal()
        {
            var animal = CreateAnimal();
            Console.WriteLine("Created a new animal:");
            animal.MakeSound();
            animal.Move();
            Console.WriteLine();
        }
    }

    // Concrete Creators
    public class DogFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }

    public class CatFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Cat();
        }
    }

    public class BirdFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Bird();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory[] animalFactories = {
                new DogFactory(),
                new CatFactory(),
                new BirdFactory()
            };

            foreach (var factory in animalFactories)
            {
                factory.InteractWithAnimal();
            }
            
        }
    }
}
