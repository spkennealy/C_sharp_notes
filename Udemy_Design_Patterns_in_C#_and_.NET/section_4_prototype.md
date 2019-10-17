## **Section 4: Prototype**

When it's easier to copy an existing object to fully initialize a new one.

**Motivation**
* Complicated objects (e.g., cars) aren't designed from scratch.
    * They reiterate existing designs.
* An existing (partially or fully constructed) design is a Prototype.
* We make a copy (clone) the prototype and customize it.
    * Requires 'deep copy' support.
* We make the cloning convenient (e.g., via a Factory).

**Prototype**
* A partially or fully initialized object that you copy (clone) and make use of.

### **ICloneable is Bad**
```csharp
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns
{
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (streeName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            // This will point to the same object and just change John's name to Jane.
            var jane = john;
            jane.Names[0] = "Jane";

            WriteLine(john); // Names: Jane Smith, Address: London Road 123
            WriteLine(jane); // Names: Jane Smith, Address: London Road 123
    }
}
```
* You can extend Person with `ICloneable` and use the `.Clone()` method, but this will not create a deep copy.
* `ICloneable` is not the best since it's a shallow copy and returns an object which you will have to cast to your specific object.

### **Copy Constructors**
* You can use a separate constructor passing in the object (in this case, Person) that you want to copy.
```csharp
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns
{
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address); // Address will need a copy constructor as well.
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (streeName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = new Person(john);
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            WriteLine(john); // Names: John Smith, Address: London Road 123
            WriteLine(jane); // Names: Jane Smith, Address: London Road 321
    }
}
```

### **Explicit Deep Copy Interface**
```csharp
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (streeName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address DeepCopy()
        {
            return new Address(StreeName, HouseNumber);
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            WriteLine(john); // Names: John Smith, Address: London Road 123
            WriteLine(jane); // Names: Jane Smith, Address: London Road 321
    }
}
```
* This can be very tedious.

### **Copy Through Serialization**

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        // To do this, you must remove the [Serializable] tags on all the objects.
        // You must also create parameterless constructors for each object.
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemorySteam())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }

    [Serializable] // you must add this to serialize with Binary Formatter
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public Person() {} // here is the empty/default constructor
    }

    [Serializable] 
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (streeName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Addres() {} // here is the empty/default constructor
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            WriteLine(john); // Names: John Smith, Address: London Road 123
            WriteLine(jane); // Names: Jane Smith, Address: London Road 321
    }
}
```

### **Prototype Coding Exercise**

Given the definitions above, you are asked to implement `Line.DeepCopy()` to perform a deep copy of the current `Line` object.

```csharp
using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            // code goes here...
        }
    }
}
```