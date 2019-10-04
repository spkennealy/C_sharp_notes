## **Section 2: Builder**

**Gamma Categorization**
* Design Patterns are typically split into three categories.
* This is called *Gamma Categorization* after Erich Gamma, one of the GoF authors.
* **Creational Patterns**
    * Deal with the creation (construction) of objects.
    * Explicit (constructor) vs. implicit (DI, reflection, etc.)
    * Wholesale (single statement) vs. piecewise (step-by-step)
* **Structural Patterns**
    * Concerned with the stucture (e.g., class members)
    * Many patterns are wrappers that mimic the underlying class' interface
    * Stress the importance of good API design
* **Behavioral Patterns**
    * They are all different; no central theme

### **Builder**
Motivation
* Some objects are simple and can be created in a single constructor call
* Other objects require a lot of ceremony to create
* Having an object with 10 constructor arguments is not productive
* Instead, opt for piecewise construction
* Bulider provides and API for constructing an object step-by-step

Builder - when piecewise object construction is complicated, provide an API for doing it succinctly.

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
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElemnt();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            WriteLine(builder.ToString());
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

    public class Demo
    {
        static void Main(string[] args)
        {
            
        }
    }
}
```