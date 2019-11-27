## **Section 9: Decorator**

* Adding behavior without altering the class itself

**Motivation**
* Want to augment an object with additional functionality
* Do not want to rewrite or alter existing code (OCP)
* We want to keep new functionality separate (SRP)
* Need to be able to interact with existing structures
* Two options:
    * Inherit from required object if possible; some objects are sealed
    * Build a decorator, which simply references the decorated object(s)

**Decorator**
Facilitates the addition of behaviors to individual objects without inheriting from them.

