namespace Bridge_Coding_Exercise
{
    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }
        public IRenderer Renderer;

        public VectorRenderer(IRenderer renderer)
        {
            Renderer = renderer;
        }
    }
}
