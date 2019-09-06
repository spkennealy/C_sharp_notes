## **Section 5: Polymorphism - Third Pillar of OOP**

### **Method Overriding**

Method overriding is when you modify the implementation of an inherited method.

Example:
```csharp
public class Shape
{
    public virtual void Draw() // add virtual
    {

    }
}
public class Circle : Shape 
{ 
    public override void Draw() // add override
    {
        // New implementation
    }
}
public class Image : Shape { }
```
* Adding `virtual` will give you the ability to override that method elsewhere.
* Adding `override` will make that the method override it's in inherited method.

### **Abstract Classes & Members**

**Abstract Modifier**
* Indicates that a class or a member is missing implementation.
```csharp
public abstract class Shape // if you have an abstract method, then you must make the class abstract as well
{
    public abstract void Draw(); // add abstract here
}
public class Circle : Shape 
{ 
    public override void Draw()
    {
        // Implementation for circle
    }
}
```

**Abstract Members Rules**
1. Do not inlcude implementation.
```csharp
public abstract void Draw();
```
2. If a member is declared as abstract, the containing class needs to be declared as abstract too.
```csharp
public abstract class Shape
{
    public abstract void Draw();
}
```
3. Must implement all abstract members in the base abstract class.
```csharp
public class Circle : Shape 
{ 
    public override void Draw()
    {
        // Implementation for circle
    }
}
```
4. Abstract classes cannot be instantiated.
```csharp
var shape = new Shape(); // won't compile
```

Benefits of using abstract:
* When you want to provide some common behavior, while forcing other developers to follow your design.

