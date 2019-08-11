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

### **TimeSpan**

```csharp
using System;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating 
            var timeSpan = new TimeSpan(1, 2, 3); // arguements can be hours, minutes, seconds
            var timeSpan1 = new TimeSpan(1, 0, 0); // produces 1 hour time span
            var timeSpan2 = TimeSpan.FromHours(1); // produces 1 hour time span

            // Another way to create a time span object is by subtracting or adding two date time objects
            var start = DateTime.Now();
            var end = DateTime.Now().AddMinutes(2);
            var duration = start - end; // time span object

            // Properties
            timeSpan.Minutes; // will return the minutes passed to the time span object, ex. 2
            timeSpan.TotalMinutes; // will calculate the hours and minutes and convert everything to minutes

            // Add & Subtract
            timeSpan.Add(TimeSpan.FromMinutes(8));
            timeSpan.Subtract(TimeSpan.FromMinutes(8));

            // ToString
            timeSpan.ToString();

            // Parse
            timeSpan.Parse("01:02:03");
        }
    }
}
```