## **Section 3: Non-Primitive Types**

### **Classes**

Classes contain fields (attributes) and methods. The class is a blueprint for creating objects. An object is an instance of a class.

Declaring a class: 
```csharp
public class Person 
{
    public string Name;

    public void Introduce()
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