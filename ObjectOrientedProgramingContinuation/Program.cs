using System.Threading.Channels;

namespace ObjectOrientedProgramingContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public static void AutoPropertiesDemo()
        {
            var c1 = new Car("Ford Mondeo");
            var c2 = new Car("Opel Insignia");
            var c3 = new Car("Mercedes E200");
            var c4 = new Car("Tesla");
            // c1.Brand = "Fiat 500";
            Console.WriteLine(c1.Brand);
            Console.WriteLine(Car.TotalCarCounter);
            Console.WriteLine(Math.PI);
            Console.WriteLine(Math.Sin(0));
        }

        public static void InvoiceProcessorDemo()
        {
            var testProcessor = new InvoiceProcessor(new DummyLinesProvider());
            var testOutput = testProcessor.GroupByCategory();
            foreach (var gr in testOutput)
            {
                Console.WriteLine($"{gr.Key} : {gr.Value}");
            }

            var processor = new InvoiceProcessor(new FileLinesProvider());
            var groupByCategory = processor.GroupByCategory();

            foreach (var gr in groupByCategory)
            {
                Console.WriteLine($"{gr.Key} : {gr.Value}");
            }
        }

        public static void InterfacesDemo(string[] args)
        {
            var v = new ElectricalCar();
            v.Drive();
            Console.WriteLine(v.IsCharged());
        }

        public static void InheritanceDemo(string[] args)
        {
            var s = new Square(5);
            var r = new Rectangle(4, 5);
            var c = new Circle(6);
            var t = new Triangle(3, 4, 5);

            Console.WriteLine($"The area is {s.Area()} and perimeter is {s.Perimeter()}");
            Console.WriteLine($"The area is {r.Area()} and perimeter is {r.Perimeter()}");
            Console.WriteLine($"The area is {c.Area()} and perimeter is {c.Perimeter()}");
            Console.WriteLine($"The area is {t.Area()} and perimeter is {t.Perimeter()}");

            Display(s);
            Display(r);
            Display(c);
            Display(t);

            //no longer possible, because we have changed Shape to abstract
            //var x = new Shape();
            //Console.WriteLine(x.Area());
            //Display(x);
        }

        public static void Display(Shape shape)
        {
            Console.WriteLine($"The area is {shape.Area()} and perimeter is {shape.Perimeter()}");
        }

        public static void TechnicalStuffDemo()
        {
            var a = new A();
            a.Method();

            var b = new B();
            b.Method();
        }
    }
}