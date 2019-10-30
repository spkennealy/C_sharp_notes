using System;

namespace Adapter_Coding_Exercise
{
    public class SquareToRectangleAdapter : IRectangle
    {
        public SquareToRectangleAdapter(Square square)
        {
            // todo
        }

        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();
        // todo
    }
}
