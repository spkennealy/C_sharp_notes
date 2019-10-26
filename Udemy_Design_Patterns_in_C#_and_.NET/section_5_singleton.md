## **Section 5: Singleton**

"When discussing which patterns to drop, we found that we still love them all.
(Not really - I'm in favor of dropping Singleton. Its use is almost always a design smell.)"
- Erich Gamma

**Motivation**
* For some components it only makes sense to have one in the system
    * Database repository
    * Object factory
* E.g., the constructor call is expensive
    * We only do it once
    * We provide everyone with the same instance
* Want to prevent anyone creating additional copies
* Need to take care of lazy instantiation and thread safety

**Singleton**
* A component which is only instantiated once

### **Singleton Implementation**

```csharp
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            WriteLine("Initializing database");
            
            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = 
            new Lazy<SingletonDatabase>(() => new SingletonDatabse());

        public static SingletonDatabase Intstance => instance;
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Writeline($"{city} has a population of {db.GetPopulation(city)}");
        }
    }
}
```

### **Testability Issues**

```csharp
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; // add this is in here
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            WriteLine("Initializing database");
            
            capitals = File.ReadAllLines(
                Path.Combine( // must add this path.combine when using the test
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"
                )
            )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = 
            new Lazy<SingletonDatabase>(() => new SingletonDatabse());

        public static SingletonDatabase Intstance => instance;
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumberable<string> name)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }

    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000)); // you have to hard code the numbers in this case
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Writeline($"{city} has a population of {db.GetPopulation(city)}");
        }
    }
}
```
* You have to hard code a reference to the singleton and this can be a problem.

### **Singleton in Dependency Injection**

```csharp
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private OrdinaryDatabase()
        {
            WriteLine("Initializing database");
            
            capitals = File.ReadAllLines(
                Path.Combine( // must add this path.combine when using the test
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"
                )
            )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetTotalPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumberable<string> name)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }

        public int GetTotalPopulation(IEnumberable<string> name)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetPopulation(name);
            return result;
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3,
            } [name];
        }
    }

    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();

            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
            }
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Writeline($"{city} has a population of {db.GetPopulation(city)}");
        }
    }
}
```

### **Monostate**

```csharp
using System;
using static System.Console;

namespace DesignPatterns
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var ceo = new CEO();
            ceo.Name = "Adam Smith;
            ceo.Age = 55;

            var ceo2  = new CEO();
            WriteLine(ceo); // this will output Adam Smith 55
        }
    }
}
```
* Have the state of the class that you want a singleton for be static but being exposed in a non-static way.

### **Singleton Coding Exercise**

Since implementing a singleton is easy, you have a different challenge: write a method called `IsSingleton()`. 
This method takes a factory method that returns an object and it's up to you to determine whether or not that object is a singleton instance.

```csharp
using System;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var results1 = func();
            var results2 = func();
            return results1 == results2;
        }
    }
}
```