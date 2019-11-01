## **Section 6: Adapter**

* Electircal devices have different power (interface) requirements.
    * Voltage (5V, 220V)
    * Socket/plug type (Europe, UK, USA)
* We cannot modify our gadgets to support every possible interface
    * Some support possible (e.g., 120/220V)
* Thus, we use a special device (an adapter) to give us the interface we require from the interface we have

**Adapter**
* A construct which adapts an existing interface X to conform to the required interface Y.

### **Vector/Raster Demo**

```csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using Autofac;
using ImpromptuInterface;
using JetBrains.Annotations;
using static System.Console;

namespace DesignPatterns
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException(paramName: nameof(start));
            }

            Start = start;
            End = end;
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : Collection<Point>
    {
        private static int count;

        public LineToPointAdapter(Line line)
        {
            WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}]");
        }
    }

    class Demo
    {
        private static readonly List<VectorObject> vectorObjects;
            = new List<VectorObject>
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            };

        public static void DrawPoint(Point p)
        {
            Write(".");
        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        static void Main(string[] args)
        {
            Draw();
            Draw(); // this will generate the points 16 times and is uneccesary
        }
    }
}
```
* This generates a lot of temporary information.

### **Adapter Caching**

```csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using Autofac;
using ImpromptuInterface;
using JetBrains.Annotations;
using static System.Console;

namespace DesignPatterns
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException(paramName: nameof(start));
            }

            Start = start;
            End = end;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count;
        static Dictionary<int, List<Point>> cache
            = new Dictionary<int, List<Point>>();

        public LineToPointAdapter(Line line)
        {
            var hash = line.GetHashCode();
            if (cache.ContainsKey(hash))
            {
                return;
            }

            WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}]");

            var points = new List<Point>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                } 
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Demo
    {
        private static readonly List<VectorObject> vectorObjects;
            = new List<VectorObject>
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            };

        public static void DrawPoint(Point p)
        {
            Write(".");
        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        static void Main(string[] args)
        {
            Draw();
            Draw(); 
        }
    }
}
```

### **Generic Value Adapter**

```csharp
using System;
using System.Linq;

namespace DesignPatterns
{    
    // Vector2f, Vector3i

    public interface IInteger
    {
        int Value { get; }
    }

    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }   
    }

    public class Vector<TSelf, T, D> 
        where D : IInteger, new() 
        where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] data;

        public Vector()
        {
            // data = new T[D]; // this cannot work because D needs to be a literal and not a generic
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                datat[i] = values[i];
        }

        public static TSelf Create(params T[] values)
        {
            // return new Vector<T, D>(values);
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                result.datat[i] = values[i];

            return result;
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public T X
        {
            get => data[0];
            set => data[0] = value;
        }
    }

    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D> 
        where D : IInteger, new()
        where TSelf : Vector<TSelf, float, D>, new()
    {

    }

    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D> 
        where D : IInteger, new()
    {
        public VectorOfInt()
        {

        }

        public VectorOfInt(params int[] values) : base(values)
        {

        }

        public static VectorOfInt<D> operator + (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
        }
    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i()
        {

        }

        public Vector2i(params int[] values) : base(values)
        {

        }
    }

    public class Vector3f : 
        VectorOfFloat<Vector3f, Dimensions.Three>
    {
        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }   
    }

    class Demo
    {
        static void Main(string[] args)
        {
            var v = new Vector2i(1, 2);
            v[0] = 0;

            var vv = new Vector2i(3, 2);

            var result = v + vv;

            var u = Vector3f.Create(3.5f, 2.2f, 1); // we want this Create to give us a Vector3f
        }
    }
}
```
* Recursive generics can help a lot, but it is very complex.

### **Adapter Coding Exercise**

Here's a very synthetic example for you to try.

You are given an `IRectangle` interface and an extension method on it. Try to define a `SquareToRectangleAdapter`
that adapts the `Square` to the `IRectangle` interface.

```csharp
using System;

namespace Coding.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
        return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;
        
        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }
        
        public int Width => square.Side;
        public int Height => square.Side;
    }
}
```

### **Summary**
* Implementing an Adapter is easy
* Determine the API you have and the API you need
* Create a component which aggregates (has a reference to, ...) the adaptee
* Intermediate representations can pile up: use caching and other optimizations