using System;
using DomainLogic;

namespace ObjectOrientedProgrammingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Car("Opel", "Insignia", 60, 6);
            Console.WriteLine(c.FuelLevel);
            c.AddFuel(50);
            Console.WriteLine(c.FuelLevel);
            Console.WriteLine(c.Odometer);
            c.Drive(1049);
            Console.WriteLine(c.FuelLevel);
            Console.WriteLine(c.Odometer);

            //var s = new Student("Shitty name", new DateTime(1950, 1, 5));

            //Console.WriteLine(s.Name);
            //s.Name = "Another name";
            //Console.WriteLine(s.Age);
        }
    }
}
