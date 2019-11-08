namespace Bridge_Coding_Exercise
{
    public class RastRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }
        public IRenderer Renderer;

        public RastRenderer(IRenderer renderer)
        {
            Renderer = renderer;
        }
    }
}
