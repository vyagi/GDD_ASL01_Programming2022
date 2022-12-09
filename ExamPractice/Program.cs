public interface IMoveable
{
    void Move(double x, double y);
}

public class Segment
{
    protected Point _start;
    protected Point _end;

    public Segment(Point start, Point end) => (_start, _end) = (start, end);

    public virtual double Length => Math.Sqrt(Math.Pow(_start.X - _end.X, 2) + Math.Pow(_start.Y - _end.Y, 2));

    public override string ToString() => $"{_start},{_end}";
}

public class PolygonalChain : Segment, IMoveable
{
    private readonly List<Point> _midpoints = new();

    public PolygonalChain(Point start, Point end) : base(start, end) { }

    public void AddMidpoint(Point midpoint) => _midpoints.Add(midpoint);

    public override double Length
    {
        get
        {
            var temporaryList = new List<Point> {_start};

            temporaryList.AddRange(_midpoints);
            temporaryList.Add(_end);

            var totalLength = 0.0;

            for (var i = 0; i < temporaryList.Count - 1; i++)
                totalLength += new Segment(temporaryList[i], temporaryList[i + 1]).Length;

            return totalLength;
        }
    }

    public void Move(double x, double y)
    {
        _start.Move(x,y);
        _end.Move(x,y);

        foreach (var midpoint in _midpoints) midpoint.Move(x, y);
    }

    public override string ToString() => $"{_start},{string.Join(",", _midpoints)},{_end}";
}

public class Point : IMoveable
{
    private double _x;
    private double _y;

    public double X => _x;
    public double Y => _y;

    public Point() : this(0) { }

    public Point(double a) : this(a,a) { }

    public Point(double x, double y) => (_x, _y) = (x, y);
    public void Move(double x, double y)
    {
        _x += x;
        _y += y;
    }

    public virtual double Distance() => Math.Sqrt(_x * _x + _y * _y);

    public override string ToString() => $"({X},{Y})";
}

public class Program
{
    public static void Main(string[] args)
    {
        var p1 = new Point();
        var p2 = new Point(2);
        var p3 = new Point(1,5);
        p3.Move(2,2);
        Console.WriteLine(p3.X);
        Console.WriteLine(p3.Y); //3,7

        var s1 = new Segment(new Point(1, 1), p3);  //(1,1) - (3,7)   4+36 
        Console.WriteLine(p3.Distance());
        Console.WriteLine(s1.Length);

        var pc1 = new PolygonalChain(new Point(0, 0), new Point(1, 1));
        pc1.AddMidpoint(new Point(1,0));

        Console.WriteLine(pc1.Length);

        pc1.Move(5,5);
        Console.WriteLine(pc1.Length);

        Console.WriteLine(p1);
        Console.WriteLine(s1);
        Console.WriteLine(pc1);
    }
}