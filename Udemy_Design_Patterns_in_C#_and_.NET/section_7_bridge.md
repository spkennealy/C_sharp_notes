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

## **Bridge Coding Exercise**

You are given an example of an inheritance hierarchy which results in Cartesian-product duplication.

Please refactor this hierarchy, giving the base class `Shape`; a constructor that takes an interface `IRenderer`; defined as:
```csharp
interface IRenderer
{
    string WhatToRenderAs { get; }
}
```
as well as `VectorRenderer` and `RastRenderer` classes. Each implementer of the `Shape` abstract class should have a constructor
that takes an `IRenderer` such that, subsequently, each constructed object's `ToString()` operates correctly, for example,
`new Triangle(new RasterRenderer()).ToString() // returns "Drawing Triangle as pixels"`

```csharp
using System;

  namespace Coding.Exercise
  {
    // public abstract class Shape
    // {
    //   public string Name { get; set; }
    // }

    // public class Triangle : Shape
    // {
    //   public Triangle() => Name = "Triangle";
    // }

    // public class Square : Shape
    // {
    //   public Square() => Name = "Square";
    // }

    // public class VectorSquare : Square
    // {
    //   public override string ToString() => "Drawing {Name} as lines";
    // }

    // public class RasterSquare : Square
    // {
    //   public override string ToString() => "Drawing {Name} as pixels";
    // }

    // imagine VectorTriangle and RasterTriangle are here too
    
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }
    
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
    
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }
    
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
    
    public class RasterRenderer : IRenderer
    {
      public string WhatToRenderAs
      {
        get { return "pixels"; }
      }
    }

    public class VectorRenderer : IRenderer
    {
      public string WhatToRenderAs
      {
        get { return "lines"; }
      }
    }
  }
```

