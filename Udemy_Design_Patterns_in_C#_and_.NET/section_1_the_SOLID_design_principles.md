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

### **2. The `O`pen-Closed Principle**

Violating the OCP:
```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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

### **3. The `L`iskov Substitution Principle**

* You should be able to substitute a base type with a sub type.
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
    public class Rectangle
    {
        // to fix the issue below, you can add `virtual`
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToSting()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        // to fix the issue below we would change `new` to `override`
        // public new int Width
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        
        // public new int Height
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Demo
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle();
            WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");

            // if you change it to a rectangle it will not behave correctly, because you're not setting the Height
            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
```

### **4. The `I`nterface Segregation Principle**

Your interfaces should be segregated.
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
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    // IMachine works if you have a multi-functioning printer...
    public class MultifunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            // ... 
        }
        public void Scan(Document d)
        {
            // ... 
        }
        public void Fax(Document d)
        {
            // ... 
        }
    }

    // But what happens here, when you have a printer that can just print...
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            // ... 
        }
        public void Scan(Document d)
        {
            // What do you do here? No implementation
        }
        public void Fax(Document d)
        {
            // What do you do here? No implementation
        }
    }

    // Instead, you can implement more smaller interfaces
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    // If you have a photocopier, you can do this...
    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            // ... 
        }
        public void Scan(Document d)
        {
            // ...
        }
    }

    // You can have a multifunctional interface inherit from other interfaces:
    public interface IMultiFunctionDevice : IScanner, IPrinter // , ...
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }

            this.printer = printer;
            this.scanner = scanner;
        }

        // You can delegate the methods to the printer & scanner.. "the decorator pattern"
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
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
* "Make sure you don't pay for things you don't need."
* Make more smaller interfaces.

### **5. The `D`ependency Inversion Principle**
* High-level parts of the system should not depend on low-level parts of the system directly.
* Instead, they should depend on some kind of abstraction.

Example of a simple geneology system:
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
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        // for simplicity, just the name for now
        // public DateTime DateOfBirth
    }

    // low-level
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations 
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add(parent, Relationship.Parent, child);
            relations.Add(child, Relationship.Child, parent);
        }

        // one solution, but now you're exposing your private List
        public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class Research
    {
        public void Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            foreach (var r in relations.Where(
                x => x.Item1.Name == "John" &&
                    x.Item2 == Relationship.Parent
            ))
            {
                WriteLine($"John has a child called {r.Item3.Name}");
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationship();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
```

Instead of exposing your private list, you can do this:
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
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    // instead of exposing your private list, you can do this:
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations 
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add(parent, Relationship.Parent, child);
            relations.Add(child, Relationship.Child, parent);
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(
                x => x.Item1.Name == name &&
                     x.Item2 == Relationship.Parent
            ).Select(r => r.Item3);
        }
    }
    
    // High-level module:
    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                WriteLine($"John has a child called {p.Name}");
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationship();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
```

### **Summary**
* Single Responsiblity Principle
    * A class should only have one reason to change.
    * *Separation of concerns* - different classes handling different, independent tasks/problems.
* Open-Closed Principle
    * Classes should be open for extension but closed for modification.
* Liskov Substitution Principle
    * You should be able to substitute a base type for a subtype.
* Interface Segregation Principle
    * Don't put too much into an interface; split into separate interfaces.
    * YAGNI - You Ain't Going to Need It.
* Dependency Inversion Principle
    * High-leve modules should not depend upon low-level ones; use abstractions.