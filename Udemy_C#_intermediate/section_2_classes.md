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