﻿namespace Bridge_Coding_Exercise
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
}
