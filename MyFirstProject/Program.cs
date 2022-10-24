using System;
using System.Collections.Generic;

namespace MyFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();

            for (var i = 0; i < numbers.Count; i++)
            {
                numbers.Add(Convert.ToInt32(Console.ReadLine()));
            }

            var sum = 0;
            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            var average = 1.0 * sum / numbers.Count;
            Console.WriteLine($"The sum is {sum} and average is {average}");
        }

        private static void Task10b()
        {
            var numbers = new int[4];

            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            var sum = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            var average = 1.0 * sum / numbers.Length;
            Console.WriteLine($"The sum is {sum} and average is {average}");
        }

        private static void Task10a()
        {
            var number1 = int.Parse(Console.ReadLine());
            var number2 = int.Parse(Console.ReadLine());
            var number3 = int.Parse(Console.ReadLine());
            var number4 = int.Parse(Console.ReadLine());

            var sum = number1 + number2 + number3 + number4;
            var average = sum / 4.0;

            Console.WriteLine($"The sum is {sum} and average is {average}");
        }

        private static void Task5()
        {
            var radius = Convert.ToDouble(Console.ReadLine());

            var area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine($"The area of the circle with radius {radius} is {area}.");
        }

        private static void Task4()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
        }

        private static void Task3()
        {
            string name = "Marcin";
            Console.Write("Hello ");
            Console.WriteLine(name);

            Console.WriteLine("Hello " + name); //Don't use this way

            Console.WriteLine(string.Format("Hello {0}", name));//error-prone, lengthy

            Console.WriteLine($"Hello {name}"); //Use this way
        }

        private static void Task2()
        {
            string name = "Marcin";
            Console.WriteLine(name);
        }

        private static void Task1()
        {
            Console.WriteLine("Hello");
        }
    }
}
