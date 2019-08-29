## **Section 3: Association between Classes**

### **Class Coupling**

A measure of how interconnected classes and subsystems are.

To be a good programmer, you need to understand:
* Encapsulation
* The relationships between classes
* Interfaces

**Types of Relationships**
* Inheritance
* Composition

### **Inheritance**

* A kind of relationship between two classes that allows one to inherit code from the other.
* Is-A
* Example: A car is a vechile

Benefits:
* Code resuse
* Polymorphic behavior

**Syntax**
```csharp
public class PresentationObject
{
    // Common shared code
}

public class Text : PresentationObject
{
    // Code specifice to text
}
```