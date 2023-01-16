using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExamPractice2
{
    public interface IWalkable
    {
        void Walk(int numberOfSteps);
    }

    public abstract class Animal : IWalkable
    {
        public abstract void Walk(int numberOfSteps);
    }

    public class Cat : Animal
    {
        public override void Walk(int numberOfSteps) => 
            Console.WriteLine($"A cat is walking silently... {numberOfSteps} steps");
    }

    public class Dog : Animal
    {
        public override void Walk(int numberOfSteps) => 
            Console.WriteLine($"A dog is walking like crazy... {numberOfSteps} steps");
    }

    public class Elephant : Animal
    {
        public override void Walk(int numberOfSteps) => 
            Console.WriteLine($"An elephant is too lazy to walk this many, so it takes {numberOfSteps - 1} steps");
    }

    public class Person : IWalkable
    {
        private static int _personsBorn;

        private string _name;

        public static int PersonsBorn => _personsBorn;

        public Person() : this("Unnamed") { }

        public Person(string name)
        {
            _personsBorn++;

            CheckValidity(name);

            _name = FixCasing(name);
        }

        public void Walk(int numberOfSteps)
        {
            if (numberOfSteps < 0)
                throw new ArgumentException("The number of steps must not be negative");

            DistanceWalked += numberOfSteps;
        }

        public int DistanceWalked { get; private set; }

        public string Name
        {
            get => _name;

            set
            {
                CheckValidity(value);

                _name = FixCasing(value);
            }
        }

        private string FixCasing(string value) =>
            value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

        private static void CheckValidity(string name)
        {
            if (name.Length < 3)
                throw new ArgumentException("The name should be minimum 3 letters");

            if (name.Length > 20)
                throw new ArgumentException("The name should be maximum 20 letters");

            if (!Regex.IsMatch(name, "^[A-Za-z]+$"))
                throw new ArgumentException("The name should contains only letters");
        }

        public override string ToString() => $"{Name} walked {DistanceWalked} steps";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person("maRcin");
            p.Walk(1);
            p.Walk(5);
            p.Walk(7);
            Console.WriteLine(p.DistanceWalked);
            Console.WriteLine(p.Name);
            p.Name = "romAN";
            Console.WriteLine(p.Name);

            var p1 = new Person();
            Console.WriteLine(p1.Name);

            Console.WriteLine(Person.PersonsBorn);

            Console.WriteLine(p);

            var list = new List<IWalkable>();
            list.Add(new Cat());
            list.Add(new Cat());
            list.Add(new Dog());
            list.Add(new Elephant());
            list.Add(new Person());
            list.Add(new Person("James"));
            list.Add(p);
            list.Add(p1);

            Walk(list);
        }

        public static void Walk(List<IWalkable> something)
        {
            foreach (var item in something)
            {
                item.Walk(10);
                
                if (item is Person)
                    Console.WriteLine(item);
            }
        }
    }
}
