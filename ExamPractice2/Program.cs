using System;
using System.Text.RegularExpressions;

namespace ExamPractice2
{
    public class Person
    {
        private string _name;

        public Person(string name)
        {
            CheckValidity(name);

            _name = FixCasing(name);
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
        }
    }
}
