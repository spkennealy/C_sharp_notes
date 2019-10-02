# Design Patterns in C# and .NET

## **Section 1: The SOLID Design Principles**

What are design patterns?
* Design patterns are common architectural approaches.
* Popularized by the Gang of Four book (1994)
    * Smalltalk & C++
    * `Design Patterns, Elements of Reusable Object-Oriented Software`
        * Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides
* Translated to many OOP languages
    * C#, Java, Ruby, ...
* Universally relevant
    * Internalized in some programming languages
    * Libraries
    * Your own code!

**The SOLID Design Principles**
* Design principles introduced by Robert C. Martin
* Book: Agile Principles, Patterns, and Practices in C# - not recommended by instructor
* Frequently references in Design Pattern Literature

### **1. The `S`ingle Responsibility Principle**
* Specifies that any particular class should have a single reason to change.

This is an example of giving too much responsiblity to one class:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index); // not the best way to implement
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entires);
        }

        public void Save(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public static Journal Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);
        }
    }
}
```

Here is how you should change it:
```csharp
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index); // not the best way to implement
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entires);
        }
    }

    // Make a new class that handles the persistance of things:
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }

        public static Journal Load(Journal j, string filename)
        {

        }

        public void Load(Journal j, Uri uri)
        {

        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistance();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(file);
        }
    }
}
```
* The whole point of the single responsiblity principle is that a class is responsible for one thing and has one reason to change.

### **2. The Open-Closed Principle**

Violating the OCP:
```csharp
namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArguementNullException(paramName: nameof(name));
            }

            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size  == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color  == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.Size == size && p.Color  == color)
                    yield return p;
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            WriteLine("Green products (old): ");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($" - {p.Name} is green");
            }
        }
    }
}
```
* This breaks the OCP, because classes should be open for extension. 
* It should be possible to make new filters, but those filters should be closed for modification.

Instead, we can implement the specification pattern:
```csharp
namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArguementNullException(paramName: nameof(name));
            }

            Name = name;
            Color = color;
            Size = size;
        }
    }

    // Instead use Interfaces
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    // Inherits from ISpecification
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        } 
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnmerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();
            WriteLine("Green products (new): ");
            foreach (var p in bf.FilterByColor(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green");
            }

            WriteLine("Large blue items:");
            var colorSpec = new ColorSpecification(Color.Blue);
            var sizeSpec = new SizeSpecification(Size.Large);

            foreach (var p in bf.Filter(products, new AndSpecification<Product>(colorSpec, sizeSpec)))
            {
                WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}
```