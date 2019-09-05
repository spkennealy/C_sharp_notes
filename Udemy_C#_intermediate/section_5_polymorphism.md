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

