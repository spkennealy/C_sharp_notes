using System;

namespace Prototype_Coding_Exercise
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var x = new Point();
            x.X = Start.X;
            x.Y = Start.Y;
            var y = new Point();
            y.X = End.X;
            y.Y = End.Y;

            var line = new Line();
            line.Start = x;
            line.End = y;

            return line;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var line1 = new Line();
            line1.Start = new Point() { X = 2, Y = 3 };
            line1.End = new Point() { X = 1, Y = 4 };

            Console.WriteLine($"Line 1 Start X = {line1.Start.X}");
            Console.WriteLine($"Line 1 Start Y = {line1.Start.Y}");
            Console.WriteLine($"Line 1 End X = {line1.End.X}");
            Console.WriteLine($"Line 1 End Y = {line1.End.Y}");
            Console.WriteLine("--------");

            var line2 = line1.DeepCopy();

            Console.WriteLine($"Line 1 Start X = {line1.Start.X}");
            Console.WriteLine($"Line 1 Start Y = {line1.Start.Y}");
            Console.WriteLine($"Line 1 End X = {line1.End.X}");
            Console.WriteLine($"Line 1 End Y = {line1.End.Y}");
            Console.WriteLine("--------");
            Console.WriteLine("--------");
            Console.WriteLine($"Line 2 Start X = {line2.Start.X}");
            Console.WriteLine($"Line 2 Start Y = {line2.Start.Y}");
            Console.WriteLine($"Line 2 End X = {line2.End.X}");
            Console.WriteLine($"Line 2 End Y = {line2.End.Y}");
        }
    }
}
