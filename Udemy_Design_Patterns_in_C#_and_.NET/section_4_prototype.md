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