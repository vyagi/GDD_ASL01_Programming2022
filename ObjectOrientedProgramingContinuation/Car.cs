namespace ObjectOrientedProgramingContinuation;

public class Car
{
    public static int TotalCarCounter { get; private set; }

    public string Brand { get; set; }

    public Car(string brand)
    {
        TotalCarCounter++;
        Brand = brand;
    }
}