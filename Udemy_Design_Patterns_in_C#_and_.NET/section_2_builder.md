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

        // public void AddChild(string childName, string childText)
        // to instead be able to have a fluent builder like so: builder.AppendChild("hi").AppendChild("you")
        // return the same object
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this; // add this to return the object
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
            // by returning the object in AddChild, we can chain these calls
            builder.AddChild("li", "hello").AddChild("li", "world");
            WriteLine(builder.ToString());
        }
    }
}
```

### **Fluent Builder Inheritance with Recursive Generics**

```csharp
using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPatters 
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }

        // This allows for recursive generics:
        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
    }

    public class PersonInfoBuilder
    {
        protected Person person = new Person();

        public PersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
    }

    public class PersonJobBulider : PersonInfoBuilder
    {
        public PersonJobBuilder WorksAsA(string position)
        {
            person.Position = position;
            return this;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var vuilder = new PersonJobBuilder();
            builder.Called("dmitri")
                .WorksAsA(""); 
            // this will not work because the Called method returns a PersonInfoBuilder and PersonInfoBuilder doesn't know anything about the JobBuilder.

            // Once we fix the code to resemble below and the recursive generics portion in Person, we'll have this:
            var me = Person.New
                .Called("Sean")
                .WordsAsA("Engineer")
                .Build();
            Console.WriteLine(me);
        }
    }

    // to fix this issue, you can create an abstract class:
    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return Person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBulider<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}
```

### **Faceted Builder**

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
    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;
    }

    public class PersonBuilder // facade
    {
        // reference object!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        // to get a person object returned at the end:
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives.At("300 Mason St.")
                      .In("San Francisco")
                      .WithPostcode(94133)
                .Works.At("Insightly")
                      .AsA("Engineer")
                      .Earning(100000);
            
            WriteLine(person); // we'll get a PersonJobBuilder right now...
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