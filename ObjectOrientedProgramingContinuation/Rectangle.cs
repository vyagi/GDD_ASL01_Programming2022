namespace ObjectOrientedProgramingContinuation;

public class Rectangle : Shape
{
    private readonly double _a;
    private readonly double _b;

    public Rectangle(double a, double b) => (_a, _b) = (a, b);

    public override double Area() => _a * _b;
    public override double Perimeter() => 2 * (_a + _b);
}