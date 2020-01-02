## **Section 9: Decorator**

* Adding behavior without altering the class itself

**Motivation**
* Want to augment an object with additional functionality
* Do not want to rewrite or alter existing code (OCP)
* We want to keep new functionality separate (SRP)
* Need to be able to interact with existing structures
* Two options:
    * Inherit from required object if possible; some objects are sealed
    * Build a decorator, which simply references the decorated object(s)

**Decorator**
Facilitates the addition of behaviors to individual objects without inheriting from them.

### **Custom String Builder**
```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns
{
    // public class CodeBuilder : StringBuilder // cannot inherit from a sealed class
    public class CodeBuilder
    {
        private StringBuilder builder = new StringBuilder();

        // Generate the delegating members by right clicking on StringBuilder

        // ... many different StringBuilder methods that return CodeBuilders
    }

    static class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
```

### **Adapter-Decorator**
```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using Autofac;
using ImpromptuInterface;
using JetBrains.Annotations;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns
{
    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.sb.Append(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, string s)
        {
            msb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        // Generate the delegating members
    }

    static class Demo
    {
        static void Main(string[] args)
        {
            StringBuilder s = "hello"; // this won't work
            s += "world"; // this won't work
            WriteLine(s);

            // ------------

            MyStringBuilder s = "hello"; // this will work
            s += "world"; 
            WriteLine(s);
        }
    }
}
```

### **Multiple Inheritance with Interfaces**
```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    // right click and 'Extract Interface'
    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky with {Weight}");
        }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    // right click and 'Extract Interface'
    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with {Weight}");
        }
    }

    public class Dragon : ILizard, IBird
                     // : Lizard, Bird // this won't work (you can only inherit from one)
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        // Generate members with resharper
        public void Fly()
        {
            bird.Fly();
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public int Weight 
        { 
            get { return weight;} 
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }
    }

    static class Demo
    {
        static void Main(string[] args)
        {
            
        }
    }
}
```