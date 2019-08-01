## **Section 3: Non-Primitive Types**

### **Classes**

Classes contain fields (attributes) and methods. The class is a blueprint for creating objects. An object is an instance of a class.

Declaring a class: 
```csharp
public class Person 
{
    public string Name;

    public void Introduce() // void means it doesn't return any values
    {
        Console.Writeline("Hi, my name is " + Name);
    }
}
```

Creating an object:
```csharp
int number;
Person person = new Person(); // must allocate memory for the object
var person = new Person(); // another option
person.name = "Mosh";
person.Introduce();
```

Static Modifier:
```csharp
public class Calculator 
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
```
* Adding `static` allows the method to be called on the class itself, `Calculator.Add(1, 2)`. Esentially like a class method in Ruby. Without the static modifier, you can only access the class methods by instantiating an object. 

### **Structs**

Similar to classes, structures combine related fields and methods together.
```csharp
public struct RbgColor
{
    public int Red;
    public int Green;
    public int Blue;
}
```

99% of the time you will use classes, not structures. Use `structs` when you want only one instance of that object.

### **Arrays**

An array is a data structure to store a collection of variables of the same type. 

Declaring arrays:
```csharp
int number1;
int number2;
int number3;

int[] numbers = new int[3] { 1, 2, 3 }; // the int[3] sets the size of the array
// during declaration you can supply a code block with the values.

// or you can assign them after
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
```

Arrays must have a fixed size, therefore you must declare the size of the array from the beginning.

Default values will be the default value of that data type. For example, `int` would default to `0` and `bool` will default to `false`.

### **Strings**

A string is a sequence of characters. Must be surrounded by double quotes.
```csharp
string firstName = "Sean";
string lastName = "Kennealy";

string name = firstName + " " + lastName; // you can concatenate strings too

string name = string.Format("{0} {1}", firstName, lastName); // can use the format static method on the string class

// create strings using join
var number = new int[3] {1, 2, 3};
string list = string.Join(",", numbers);

// access strings using index
string name = "Sean";
char firstChar = name[0];
```
* `"{0} {1}"` is a placeholder. The numbers are the indicies.
* In `string.Join` the first arguement is what you want to join them on and the second is the array.
* Strings are immutable and, once you create them, you *cannot* change them.

**Special Characters in C#**
* `\n` = new line
* `\t` = tab
* `\\` = backslash
* `\'` = single quotation mark
* `\"` = dobule quotation mark

**Verbatim Strings**
```csharp
string path = "c:\\projects\\projects1\\folder1";
string path = @"c:\projects\projects1\folder1"; // using the @ sybmol will allow for a verbatim string or stirng literal
```

**Another example of string building**
```csharp
var firstName = "Sean";
var lastName = "Kennealy";
var myFullName = string.Format("My full name is {0} {1}", firstName, lastName);
```

### **Enums**

An enum is a set of name/value pairs (constants). Use an enum where you have mulitple relatable constants. An enum must be defined at the namespace level.

If you do not set a value to the first enum, it's value will be set to 0 and each one after that will be incremented by 1.

```csharp
using System;

namespace CSharpFundamentals
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method); // must cast to convert it to an integer

            var methodId = 3;
            Console.WriteLine((ShippingMethod)methodId); // can cast it to a shipping method and will return "Express"

            var methodName = "Express";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
        }
    }
}
```

### **Reference Types & Value Types**

