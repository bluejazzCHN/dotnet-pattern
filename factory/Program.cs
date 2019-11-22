using System;

namespace FactoryMethodPattern
{
    public interface IAnimal
    {
        void Speak();
        void Action();
    }
    public class Dog: IAnimal
    {
        public void Speak(){
            Console.WriteLine("Dog says: Bow-Bow.");
        }
        public void Action(){
            Console.WriteLine("Dog prefer barking...\n");
        }
    }
    public class Tiger :IAnimal
    {
        public void Speak(){
            Console.WriteLine("Tiger says:Halum.");
       }
       public void Action(){
           Console.WriteLine("Tiger prefer hunting...\n");
       }
    }
    public abstract class IAnimalFactory
    {
        public abstract IAnimal CreateAnimal();
         public IAnimal MakeAnimal()
        {
            IAnimal Animal = CreateAnimal();
            Animal.Speak();
            Animal.Action(); 
            return Animal;
        }
    }
    public class DogFactory:IAnimalFactory
    {
        public override IAnimal CreateAnimal(){
            return new Dog();
        }
      
    }
    public class TigerFactory:IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Tiger();
        }
    }


    class client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Pattern Demo***\n");
            // Creating a Tiger Factory
            IAnimalFactory tigerFactory =new TigerFactory();
            IAnimal tiger = tigerFactory.MakeAnimal();
            // Creating a tiger using the Factory Method
            // IAnimal aTiger = tigerFactory.CreateAnimal();
            // aTiger.Speak();
            // aTiger.Action();
            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            IAnimal dog = dogFactory.MakeAnimal();
            // Creating a dog using the Factory Method
            // IAnimal aDog = dogFactory.CreateAnimal();
            // aDog.Speak();
            // aDog.Action();
            Console.ReadKey();
        }
    }
}
