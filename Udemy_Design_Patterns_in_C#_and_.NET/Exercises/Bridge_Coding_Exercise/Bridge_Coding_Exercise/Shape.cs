namespace Bridge_Coding_Exercise
{
    public abstract class Shape
    {
        private IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }
}
