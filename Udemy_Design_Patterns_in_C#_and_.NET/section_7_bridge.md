## **Section 7: Bridge**

**Motivation**
* Bridge prevents a 'Cartesian product' complexity explosion
* Example: 
    * Base class `ThreadScheduler`
    * Can be preemptive or cooperative
    * Can run on Windows or Unix
    * End up with a 2x2 scenario: WindowsPTS, UnixPTS, WindowsCTS, UnixCTS
* Bridge pattern avoids the entity explosion

**Bridge**
* A mechanism that decouples an interface (hierarchy) from an implementation (hierarchy).

### **Bridge Pattern**
```csharp
namespace DesignPatterns
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}")
        }
    }

    public class RastorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing pixels for a circle with radius {radius}")
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        
        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            raidus *= factor;
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
            // IRenderer renderer = new RasterRenderer();
            IRenderer renderer = new VectorRenderer();
            var circle = new Circle(renderer, 5);

            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            // another way 
            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>()
                .SingleInstance();
            cb.Register((c, p) => 
                new Circle(c.Resolve<IRenderer>(),
                    p.Positional<float>(0)));
            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(
                    new PositionalParameter(0, 5.0f)
                );

                circle.Draw();
                circle.Resize(2.0f);
                circle.Draw();
            }
        }
    }
}
```