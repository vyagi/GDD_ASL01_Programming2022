using System;

namespace ObjectOrientedProgrammingFundamentals
{
    class Car
    {
        private readonly string _brand;
        private readonly string _make;
        private readonly int _tankCapacity;
        private readonly double _fuelConsumption;

        private double _fuelLevel;
        private double _odometer;

        public Car(string brand, string make, int tankCapacity, double fuelConsumption)
        {//add necessary checks 
            _brand = brand;
            _make = make;
            _tankCapacity = tankCapacity;
            _fuelConsumption = fuelConsumption;
        }

        public string Brand => _brand;
        public string Make => _make;
        public int TankCapacity => _tankCapacity;
        public double FuelConsumption => _fuelConsumption;

        public double FuelLevel => _fuelLevel;

        public int Odometer => (int)_odometer;

        public void AddFuel(int howMuch)
        { //TODO:(homework) add checks
            _fuelLevel += howMuch;

            if (_fuelLevel > _tankCapacity)
                _fuelLevel = _tankCapacity;
        }

        public void Drive(int howFar)
        {
            var maxRange = _fuelLevel / _fuelConsumption * 100;

            if (howFar <= maxRange)
            {
                _odometer += howFar;
                _fuelLevel -= howFar * _fuelConsumption / 100;
            }
            else
            {
                _odometer += maxRange;
                _fuelLevel = 0;
            }
           
        }
    }

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
