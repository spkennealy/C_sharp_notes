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

### **Composition**

* A kind of relationship between two classes that allows one to contain the other.
* Has-A relationship
* Example: Car has an engine

Benefits:
* Code reuse
* Flexibility
* A means to loose-coupling

Example:
* DbMigrator requires logging.
* Installer requires logging.
```csharp
public class Installer
{
    private Logger _logger;

    public Installer(Logger logger)
    {
        _logger = logger;
    }
}
```

**Demo**
```csharp
namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new Logger());

            var logger = new Logger();
            var installer = new Installer(logger);

            dbMigrator.Migrate();

            installer.Install();
        }
    }

    // separate file Logger.cs
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // separate file DbMigrator.cs
    public class DbMigrator
    {
        private readonly Logger _logger;

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.Log("We are migrating...");
        }
    }

    // separate file Installer.cs
    public class Installer
    {
        private readonly Logger _logger;

        public Installer(Logger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.Log("We are installing...");
        }
    }
}
```

### **Favor Composition over Inheritance**

**Problems with Inheritance**
* Easily abused by amateur designers/developers
* Large hierarchies
* Fragility
* Tightly coupling

**Composition**
* Any inheritance can be converted to composition
* Great flexibility
* Eventually loose couppling