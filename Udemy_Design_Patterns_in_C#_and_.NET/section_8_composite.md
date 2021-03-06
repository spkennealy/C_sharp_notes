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
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, 
            IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;

            foreach(var from in self)
            {
                foreach(var to in other)
                {
                    from.Out(Add(to));
                    to.In.Add(from);
                }
            }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumrator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }

    static class Program
    {
        static void Main(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2); // 1 layer

            var layer1 = NeuronLayer();
            var layer2 = NeuronLayer();

            neuron1.ConnectTo(layer1); // these work now with the ExtensionMethods
            layer1.ConnectTo(layer2);
        }
    }
}
```

### **Composite Coding Exercise**

Consider the code presented below. The `Sum()` extension method adds up all the values in a list of `IValueContainer` elements it gets passed. We can have a single value or set of values.

Complete the implementation of the interfaces so that `Sum()` begins to work correctly.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

  namespace Coding.Exercise
  {
    public interface IValueContainer : IEnumerable<int>
    {
      
    }

    public class SingleValue : IValueContainer
    {
      public int Value;

      public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {
      
    }

    public static class ExtensionMethods
    {
      public static int Sum(this List<IValueContainer> containers)
      {
        int result = 0;
        foreach (var c in containers)
        foreach (var i in c)
          result += i;
        return result;
      }
    }
  }
```

### **Summary**
* Objects can use other objects via inheritance/composition
* Some composed and singular objects need similar/identical behavior
* Composite design pattern lets us treat both types of obejcts uniformly
* C# has special support for the *enumeration* concept
* A single object can masquerade as a collection with *yield return this;*