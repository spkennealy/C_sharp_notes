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

### **Strings**



### **Enums**



### **Reference Types & Value Types**

