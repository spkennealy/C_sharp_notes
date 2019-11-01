using System;

namespace Adapter_Coding_Exercise
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var sq = new Square { Side = 11 };
            var adapter = new SquareToRectangleAdapter(sq);
            Console.WriteLine(adapter.Area() == 121);
        }
    }
}
