namespace ObjectOrientedProgramingContinuation;

public class Triangle : Shape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public Triangle(double a, double b, double c) => (_a, _b, _c) = (a, b, c);

    public override double Area()
    {
        var p = Perimeter() / 2;
        return Math.Sqrt(p*(p-_a)*(p-_b)*(p-_c));
    }

    public override double Perimeter() => _a + _b + _c;
}