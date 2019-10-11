## **Section 3: Factories**

Factory method pattern and the abstract factory pattern.

**Motiviation**
* Object creation logic becomes to convoluted
* Constructor is not descriptive
    * Name mandated by name of containing type
    * Cannot overload with same sets of arguments with different names
    * Can turn into 'optional parameter hell'
* Object creation (non-piecewise, unlike Builder) can be outsourced to
    * A separate function (Factory Method)
    * That may exist in a separate class (Factory)
    * Can create hierachy of factories with Abstract Factory

**Factory**
* A component responsible solely for the wholesale (not piecewise) creation of objects.

### **Point Example**

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatters 
{
    public class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // this won't work
        public Point(double rho, double theta) { }
    }

    // Instead, you can do this:
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    // a & b wouldn't be clear on whether it was rho and theta or x and y, so you would have to add XML doc comments like this:

    // <summary>
    // Initializs a a point from EITHER cartesian or polar
    // <summary>
    // <param name="a">x if cartesian, rho if polar</param>
    // <param name="b"></param>
    // <param name="system"></param>
    public class Point
    {
        private double x, y;

        public Point(double a, double b, CoordinateSystem system = CoordinatSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {

        }
    }
}
```
* This is the kind of problem that factories will solve for us.

### **Factory Method**

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatters 
{
    public class Point
    {
        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;    
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
        }
    }
}
```