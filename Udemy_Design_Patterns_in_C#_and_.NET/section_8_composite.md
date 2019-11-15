## **Section 8: Composite**

* Treating individual and aggregate objects uniformly.

**Motivation**
* Objects use other objects' fields/properties/members through inheritance and composition
* Composition lets us make compound objects
    * E.g., a mathematical expression composed of simple expressions; or 
    * A grouping of shapes that consists of several shapes
* Compostie design pattern is used to treat both single (scalar) and composite objects uniformly
    * I.e., Foo and Collection<Foo> have common APIs

**Composite**
* A mechanism for treating individual (scalar) objects and compositions of objects in a uniform manner.

### **Geometric Shapes**
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;

        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
              .AppendLine(Name);
            foreach (var child in children)
            {
                child.Print(sb, depth+1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            WriteLine(drawing);
        }
    }
}
```

### **Neural Networks**
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns
{
    

    static class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
```