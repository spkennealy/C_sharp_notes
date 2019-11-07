using System;

namespace Bridge_Coding_Exercise
{
    public abstract class Shape
    {
        public string Name { get; set; }
    }

    public class Triangle : Shape
    {
        public Triangle() => Name = "Triangle";
    }

    public class Square : Shape
    {
        public Square() => Name = "Square";
    }

    public class VectorSquare : Square
    {
        public override string ToString() => "Drawing {Name} as lines";
    }

    public class RasterSquare : Square
    {
        public override string ToString() => "Drawing {Name} as pixels";
    }

    // imagine VectorTriangle and RasterTriangle are here too

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
