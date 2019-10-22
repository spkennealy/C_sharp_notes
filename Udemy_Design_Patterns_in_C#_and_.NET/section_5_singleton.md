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
            
            capitals = File.ReadAllLines("capitals.txt");
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