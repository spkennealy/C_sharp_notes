## **Section 7: Working with Dates**

### **Datetime**

Datetime objects are immutable. 

```csharp
using System;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var datetime = new DateTime(2015, 1, 1); // arguements go from year, month, day, hour, etc.
            var now = DateTime.Now; // exact current time
            var today = DateTime.Today; 

            Console.WriteLine("Hour: " + now.Hour);
            Console.WriteLine("Minute: " + now.Minute);

            var tomorrow = now.AddDays(1);
            var yesterday = now.AddDays(-1);

            Console.WriteLine(now.ToLongDateString())
            Console.WriteLine(now.ToShortDateString())
            Console.WriteLine(now.ToLongTimeString())
            Console.WriteLine(now.ToShortTimeString())
            Console.WriteLine(now.ToString()) // you can also add a format specifier as an arguement
        }
    }
}
```