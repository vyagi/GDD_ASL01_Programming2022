using System;
using DomainLogic;

namespace ObjectOrientedProgrammingFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student s1 = new Student("James Bond", new DateTime(1950, 02, 10));
            //Console.WriteLine(s1.ToString());
            //Console.WriteLine(s1.Age);
            var c = new Car("Opel", "Insignia", 60, 6);
            c.AddFuel(50);
            Console.WriteLine(c.FuelLevel);
            c.Drive(100);
            Console.WriteLine(c.FuelLevel);
            Console.WriteLine(c.Odometer);
            c.Drive(10000);
            Console.WriteLine(c.FuelLevel);
            Console.WriteLine(c.Odometer);
        }
    }
}
