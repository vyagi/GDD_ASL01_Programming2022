namespace ObjectOrientedProgramingContinuation;

public class ElectricalCar : IVehicle, IElectricalAppliance
{
    public void Drive()
    {
        Console.WriteLine("I am driving");
    }

    public bool IsCharged()
    {
        return new Random().NextDouble() > 0.5;
    }
}