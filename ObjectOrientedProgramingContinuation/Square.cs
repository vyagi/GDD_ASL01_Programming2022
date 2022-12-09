namespace ObjectOrientedProgramingContinuation;

public class Square : Shape
{
    private readonly double _a;

    public Square(double a) => _a = a;
    public override double Area() => _a*_a;
    public override double Perimeter() => 4*_a;
}