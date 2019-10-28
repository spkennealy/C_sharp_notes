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