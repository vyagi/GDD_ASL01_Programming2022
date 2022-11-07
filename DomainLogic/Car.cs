namespace DomainLogic
{
    public class Car
    {
        private const int OdometerLimit = 1000000;
        private const int DailyOdometerLimit = 10000;

        private readonly string _brand;
        private readonly string _make;
        private readonly int _tankCapacity;
        private readonly double _fuelConsumption;

        private double _fuelLevel;
        private double _odometer;
        private double _dailyOdometer;

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

        public double DailyOdometer => _dailyOdometer;

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
                _dailyOdometer += howFar;
                _fuelLevel -= howFar * _fuelConsumption / 100;
            }
            else
            {
                _odometer += maxRange;
                _dailyOdometer += maxRange;
                _fuelLevel = 0;
            }

            if (_dailyOdometer >= DailyOdometerLimit) _dailyOdometer -= DailyOdometerLimit;
            if (_odometer >= OdometerLimit) _dailyOdometer -= OdometerLimit;
        }

        public void ResetDailyOdometer() => _dailyOdometer = 0;
    }
}
