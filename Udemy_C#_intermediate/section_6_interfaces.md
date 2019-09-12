## **Section 6: Interfaces**

### **What is an Interface?**

An interface is a language construct that is similar to a class (based on syntax), but is fundamentally different.
```csharp
public interface ITaxCalculator
{
    int Calculate();
}
```
* For convention, all interface names begin with an `I`.
* All methods do not have implementation, they are just declarations.
* No access modifiers.

**Why?**
Interfaces are used to build loosely-coupled applications.
