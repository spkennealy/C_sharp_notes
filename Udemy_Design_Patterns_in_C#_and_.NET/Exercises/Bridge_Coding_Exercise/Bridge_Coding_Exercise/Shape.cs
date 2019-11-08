﻿namespace Bridge_Coding_Exercise
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public IRenderer Renderer;

        public Shape(IRenderer renderer)
        {
            Renderer = renderer;
        }
    }
}
