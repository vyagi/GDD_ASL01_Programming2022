namespace DomainLogic
{
    public class Car
    {
        private const int OdometerLimit = 1000000;
        private const int DailyOdometerLimit = 10000;

        private readonly string _brand;
        private readonly string _model;
        private readonly int _tankCapacity;
        private readonly double _fuelConsumption;

        private double _fuelLevel;
        private double _odometer;
        private double _dailyOdometer;

        public Car(string brand, string model, int tankCapacity, double fuelConsumption)
        {
            //TODO: provide checks for all the parameters
            _brand = brand;
            _model = model;
            _tankCapacity = tankCapacity;
            _fuelConsumption = fuelConsumption;
        }

        public string Brand => _brand;
        public string Model => _model;
        public int TankCapacity => _tankCapacity;
        public double FuelConsumption => _fuelConsumption;

        public int FuelLevel => (int)_fuelLevel;
        public int Odometer => (int)_odometer;
        public int DailyOdometer => (int)_dailyOdometer;

        public void AddFuel(int howMuch)
        {
            //TODO: provide checks for howMuch
            _fuelLevel += howMuch;

            if (_fuelLevel > _tankCapacity) _fuelLevel = _tankCapacity;
        }

        public void Drive(int howFar)
        {
            //TODO: provide checks for howFar
            var maximumRange = _fuelLevel / _fuelConsumption * 100;

            if (howFar <= maximumRange)
            {
                _fuelLevel -= howFar * _fuelConsumption / 100;
                _odometer += howFar;
                _dailyOdometer += howFar;
            }
            else
            {
                _fuelLevel = 0;
                _odometer += maximumRange;
                _dailyOdometer += maximumRange;
            }
            if (_dailyOdometer >= DailyOdometerLimit) _dailyOdometer -= DailyOdometerLimit;
            if (_odometer >= OdometerLimit) _odometer -= OdometerLimit;
        }

        public void ResetDailyOdometer() => _dailyOdometer = 0;
    }
}
