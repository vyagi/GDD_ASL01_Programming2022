namespace ObjectOrientedProgramingContinuation;

public class Circle : Shape
{
    private readonly double _r;

    public Circle(double r) => _r = r;
        
    public override double Area() => Math.PI * _r * _r;
    public override double Perimeter() => 2 * Math.PI * _r;
}