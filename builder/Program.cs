using System;
using System.Collections.Generic;

namespace BuilderPattern {
    interface IBuilder {
        void StartUpOperations ();
        void BuildBody ();
        void InsertWheels ();
        void AddHeadlights ();
        void EndOperations ();
        Product GetVehicle ();
    }
    class Car : IBuilder {
        private string brandName;
        private Product product;
        public Car (string brand) {
            product = new Product ();
            this.brandName = brand;
        }
        public void StartUpOperations () {
            product.Add ("This is a body of Car");
        }
        public void InsertWheels () {
            product.Add ("4 wheels are added");
        }
        public void BuildBody () { }

        public void AddHeadlights () {
            product.Add ("2 Headlights are added");
        }
        public void EndOperations () { }

        public Product GetVehicle () {
            return product;
        }

    }
    class MotorCycle : IBuilder {
        private string brandName;
        private Product product;
        public MotorCycle (string brand) {
            product = new Product ();
            this.brandName = brand;
        }
        public void StartUpOperations () {

        }
        public void BuildBody () {
            product.Add ("This is a body of a Motorcycle");
        }
        public void InsertWheels () {
            product.Add ("2 wheels are added");
        }
        public void AddHeadlights () {
            product.Add ("1 headlight are added");
        }
        public void EndOperations () {
            product.Add (string.Format ("Motorcycle Mode name:{0}", this.brandName));
        }
        public Product GetVehicle () {
            return product;
        }
    }
    class Product {
        private LinkedList<string> parts;
        public Product () {
            parts = new LinkedList<string> ();
        }
        public void Add (string part) {
            parts.AddLast (part);
        }
        public void Show () {
            Console.WriteLine ("\nProduct completed as below :");
            foreach (string part in parts)
                Console.WriteLine (part);
        }
    }
    class Director {
        IBuilder builder;
        // A series of steps-in real life, steps are complex.
        public void Construct (IBuilder builder) {
            this.builder = builder;
            builder.StartUpOperations ();
            builder.BuildBody ();
            builder.InsertWheels ();
            builder.AddHeadlights ();
            builder.EndOperations ();
        }
    }
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("***Builder Pattern Demo***");
            Director director = new Director ();
            IBuilder b1 = new Car ("Ford");
            IBuilder b2 = new MotorCycle ("Honda");
            // Making Car
            director.Construct (b1);
            Product p1 = b1.GetVehicle ();
            p1.Show ();
            //Making MotorCycle
            director.Construct (b2);
            Product p2 = b2.GetVehicle ();
            p2.Show ();
            Console.ReadLine ();
        }
    }
}