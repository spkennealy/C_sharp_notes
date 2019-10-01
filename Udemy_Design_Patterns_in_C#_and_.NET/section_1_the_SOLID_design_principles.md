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

### 1. **The `S`ingle Responsibility Principle**
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