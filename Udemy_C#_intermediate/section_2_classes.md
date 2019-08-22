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