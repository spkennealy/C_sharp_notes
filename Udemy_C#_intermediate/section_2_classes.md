## **Section 2: Classes**

### **Intro to Classes**

**What is a class?**

* A building block of an application.
* An application will consists of multiple classes that control a certain behavior of the application.

**Anatomy of a Class**
* Data (represented by fields)
* Behavior (represented by methods/functions)

**Object**
* An instance of a class.

**Declaring Classes**
```csharp
public class Person
{
    public string Name; // in a real world app, you don't need to declare it public
    
    public void Introduce()
    {
        Console.WriteLine("Hi, my name is " + Name);
    }
}
```

**Creating Objects**
```csharp
Person person = new Person();

var person = new Person();
```

**Using Objects**
```csharp
var person = new Person();
person.Name = "Mosh";
person.Introduce();
```

**Class Members**

* Instance: accessible from an object
```csharp
var person = new Person();
person.Introduce();
```
* Static: accessible from the class.
```csharp
Console.WriteLine();
```

**Why use static members?**
* To represent concepts that are singleton.
* DateTime.Now
* Console.WriteLine()

**Declaring Static Members**
```csharp
public class Person
{
    public static int PeopleCount = 0;
}
```

**Demo**
```csharp
namespace Classes
{
    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }

        public Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "John";
            person.Introduce("Sean");
            
            // or use the Parse
            var person = Person.Parse("John");
            person.Introduce("Sean");
        }
    }
}
```

### **Constructors**

A method that is called when an instance of a class is created. We need a constructor to put an object in an early state.
```csharp
public class Customer
{
    public Customer()
    {
        // this is the constructor
        // this one doesn't have any parameters
    }
}
```

**Example**
```csharp
public class Customer
{
    public string Name;

    public Customer(string name)
    {
        this.Name = name;
    }
}

var customer = new Customer("John");
```

**Constructor Overloading**

Constructor overloading means having a method with the same name but different signatures. By different signatures, it means that they have different return types and/or parameters.
```csharp
public class Customer
{
    public Customer() { ... }

    public Customer(string name) { ... }

    public Customer(int d, string name) 
        : this(name) 
    { 
        ... 
    }
}
```

`: this(name)` will call the other `Customer(string name)` before calling the one with 2 parameters.

### **Object Initializers**

A syntax for quickly initialising an object without the need to call one of its constructors. This will avoid creating multiple constructors.
```csharp
var person = new Person 
                {
                    FirstName = "Sean",
                    LastName = "Kennealy"
                }
```

### **Methods**

**Signature of Methods**
* Name
* Number and type of parameters
```csharp
public class Point
{
    public void Move(int x, int y) {}
}
```

**Method Overloading**
* Having a method with the same name but different signatures
```csharp
public class Point
{
    public void Move(int x, int y) {}

    public void Move(Point newLocation) {}

    public void Move(Point newLocation, int speed) {}
}
```

**The Params Modifier**
```csharp
public class Calculator
{
    public int Add(params int[] numbers) {}
}

var result = calculator.Add(new int[]{ 1, 2, 3, 4 });
var result = calculator.Add(1, 2, 3, 4); // this is easier, but must be used with `params`
```
* This will help with a method that has a varying number of parameters.

**The Ref Modifier**
```csharp
public class MyClass
{
    public void MyMethod(int a)
    {
        a += 2;
    }
}

var a = 1;
myClass.MyMethod(a); // this will return 1
```

You can use the ref modifier so that the a that is passed in to `MyMethod` is not a copy, but a reference.

```csharp
public class Weirdo
{
    public void DoAWeirdThing(ref int a)
    {
        a += 2;
    }
}

var a = 1;
weirdo.DoAWeirdThing(ref a); 
```

This is not an ideal thing to use, but it is available.

**The Out Modifier**
```csharp
public class MyClass
{
    public void MyMethod(out int result)
    {
        resutl = `;
    }
}

int a;
myClass.MyMethod(out a); 
```

`out` will allow a value to be returned. This is again not an ideal way to write code.

### **Fields**

**Initialization:**
```csharp
public class Customer
{
    List<Order> Orders = new List<Order>();
}
```

**Read-only Fields:**
```csharp
public class Customer
{
    readonly List<Order> Orders = new List<Order>();
}
```

**Example:**
```csharp
namespace Fields
{
    public class Customer 
    {
        public int Id;
        public string Name;
        public readonly List<Order> Orders = new List<Order>(); // adding readonly will not allow Promote to reinitialize a new List.

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            Orders = new List<Order>();
        }
    }

    // this can be in a separate file
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            customer.Promote(); // this will reinitialize the orders field

            Console.WriteLine(customer.Orders.Count); // will return 2 if the Promote() method was not called
        }
    }
}
```

### **Access Modifiers**

A way to control access to a class or it's members. This creates safety in the program.

* `public`
* `private`
* `protected`
* `internal`
* `protected internal`

```csharp
public class Customer
{
    private string Name;
}

// ...

var john = new Customer();
john.Name; // won't compile
```

**Object Oriented Programming**
* Encapsulation/Information Hiding
* Inheritance
* Polymorphism

**Encapsulation**
* define feilds as private
* provide getter/setter methods as public

### **Properties**

A class member that encapsulates a getter/setter for accessing a field. 
```csharp
public class Person
{
    private DateTime _birthdate;

    public DateTime Birthdate
    {
        get { return _birthdate; }
        set { _birthdate = value; }
    }
}
```

**Auto implemented property**
```csharp
public class Person
{
    public DateTime Birthdate { get; set; }
}
```

**Demo:**
```csharp
// Person would be in a separate class
public class Person
{
    public DateTime Birthdate { get; private set; }

    public Person(DateTime birthdate)
    {
        Birthdate = birthdate;
    }

    public int Age
    {
        get // a getter method that includes logic
        {
            var timeSpan = DateTime.Today - Birthdate;
            var years = timeSpan.Days/365;

            return years;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var person = new Person(new DateTime(1982, 1, 1));
        Console.WriteLine(person.Age);
    }
}
```

`prop` is a code snippet for `public DateTime Birthdate { get; private set; }`.


### **Indexers**

A way to access elements in a class that represents a list of values. 

Examples:
```csharp
var array = new int[5];
array[0] = 1;

var list = new List<int>();
list[0] = 1;

var cookie = new HttpCookie();
cookie.Expire = DateTime.Today.AddDays(5);

cookie["name"] = "Sean";
cookie.SetItem("name", "Sean");

var name = cookie["name"];
var name = cookie.GetItem("name");

public class HttpCookie
{
    public string this[string key]
    {
        get { ... }
        set { ... }
    }
}
```

**Demo:**
```csharp
namespace Indexers
{
    public class HttpCookie
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value }
        }
    }
}

// separate file
namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Sean";
            Console.WriteLine(cookie["name"]);
        }
    }
}
```