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

### **Factory**
* Constructors must be public in this scenario
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
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            // this will not work as is, because the constructor in Point is private, so you'll need to change it to public
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public class Point
    {
        private double x, y;

        // changing this to public will allow a developer to instantiate a Point object without the PointFactory
        // private Point(double x, double y)
        public Point(double x, double y)
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

### **Inner Factory**

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
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public class Point
    {
        private double x, y;

        // Changinig it from public to internal will kind of solve the problem, but it's not ideal
        internal Point(double x, double y)
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

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;    
        }
        
        // --- below is separate from the inner factory pattern, but compliments it ----
        // this will instantiate a new point every time you call Point.Origin.
        public static Point Origin => new Point(0, 0);
        // this will instantiate it once and then you have a reference to it.
        public static Point Origin2 = new Point(0, 0);
        // -----

        // this will work perfectly, but you could also remove the static keyword and instantiate a public static property that makes a new Factory().
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
        }
    }
}
```

### **Abstract Factory**

```csharp
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in the tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDirnk drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("DesignPatterns." + Enum.GetName(typeof(AvailableDrink), drink))
                );
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvaialbleDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.Consume();
        }
    }
}
```
* This, however, does not satisfy the open-closed principle, because if you want to add another drink, you must add to the enum.

### **Abstract Facotry and OCP**

```csharp
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in the tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");
            for (var index = 0; index < factoires.Count; index++)
            {
                var tuple = factoires[index];
                WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null 
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                WriteLine("Incorrect input, try again!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}
```
* This is using refelction to satisfy the open-closed principle.

### **Factory Coding Exercise**

You are given a class called `Person`. The person has two fields: `Id` and `Name`.
Please implement a *non-static* `PersonFactory` that has a `CreatePerson()` method that takes a person's name.
The Id of the person should be set as a 0-based index of the object created.
So, the first person the factory makes should have Id=0, second Id=1, and so on.

**Solution**
```csharp
using System;

namespace Coding.Exercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        
    }
}
```