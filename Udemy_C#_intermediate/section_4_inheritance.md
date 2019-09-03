## **Section 4: Inheritance - Second Pillar of OOP**

### **Access Modifiers**
* `public`
    * accessible from everywhere
* `private`
    * accessible only from the current class
* `protected`
    * accessible only from the class and it's derived classes
    * preferred to use private instead of protected
* `internal`
    * mostly used for class methods and not a class itself, but can be used for a class
    * accessible only from the same assembly
* `protected internal`
    * accessible only from the same assembly or any derived class

**Demo**
```csharp
namespace AccessModifiers
{
    // Customer.cs
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            var rating = CalculateRating1();

            if (rating == 0)
                Console.WriteLine("Promoted to level 1");
            else 
                Console.WriteLine("Promoted to level 2");

        }

        private int CalculateRating1()
        {
            return 0; // any code here
        }

        protected int CalculateRating2()
        {
            return 0; // any code here
        }
    }

    // GoldCustomer.cs
    public class GoldCustomer : Customer
    {
        public void OfferVoucher()
        {
            this.CalculateRating1(); // this will not work
            this.CalculateRating2(); // this will work here because it's derived from Customer
        }
    }

    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            customer.Promote(); // this will work
            customer.CalculateRating1(); // this will not work
        }
    }
}
```

```csharp
// if we moved the Customer class into the Amazon namespace and removed it from the AccessModifier namespace above.

using Amazon;
// Program.cs
namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(); // this will not work unless we add a reference and add the Using statement above
            Amazon.RateCalculator calculator = new RateCalculator(); // this will not work because it's in a different assembly
        }
    }
}

namespace Amazon
{
    // RateCalculator.cs
    internal class RateCalculator
    {
        public int Calculate(Customer customer)
        {
            // any code here
        }
    }

    // Customer.cs
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            var calculator = new RateCalculator(); // this is not great for encapsulation
            var rating = calculator.Calculate(this);

            Console.WriteLine("Promote logic changed");

        }
    }
}
```

### **Constructors & Inheritance**

**Constructor Inheritance**
* Base class constructors are always executed first
* Base class constructors are not inherited

Example:
```csharp
public class Vehicle
{
    private string _registrationNumber;

    public Vehicle(string registrationNumber)
    {
        _registrationNumber = registrationNumber;
    }
}

public class Car : Vehicle
{
    public Car(string registrationNumber)
        : base(registrationNumber) 
    {
        // calling `: base(_egistrationNumber)` will pass the argument to the base class constructor

        _registrationNumber = registrationNumber; // this will not work because the _registrationNumber is private

        // Anything here should be initializing fields specific to the car class
    }
}
```

### **Upcasting & Downcasting**
* Upcasting is a conversion of a derived class to a base class
* Downcasting is a conversion of a base class to a derived class
```csharp
public class Shape { }
public class Circle : Shape { }

Circle circle = new Circle();
Shape shape = circle; // upcasting

Circle anotherCircle = (Circle)shape; // downcasting, this works because the `shape` object is pointing to a Circle object at runtime
Car car = (Car)shape; // this will not compile, InvalidCastException, because they are not related
```

**The `as` keyword**
```csharp
Car car = (Car)obj;

Car car = obj as Car;
if (car != null)
{
    // ...
}
```
* Using the `as` keyword, will not throw an exception if the casting cannot work. Instead it will return null.

**The `is` keyword**
```csharp
if (obj is Car)
{
    Car car = (Car)obj;
    // ...
}
```
* Using the `is` keyword, 

**Demo**
```csharp
namespace Casting
{
    // Shape.cs
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public void Draw()
        {

        }
    }

    // Text.cs
    public class Text : Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }

    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            Shape shape = text; // this will work, text & shape point to the same spot in memory but have different views

            text.Width = 400;
            shape.Width = 100;
            Console.WriteLine(text.width); // will equal 100

            StreamReader reader = new StreamReader(new FileStream()); // or new MemoryStream();

            var list1 = new ArrayList(); // will allow you to keep different types in an list

            var list2 = new List<int>(); // will create a list of integers 

            Shape shape = new Text();
            Text text = (Text)shape; // this is downcasting
        }
    }
}
```