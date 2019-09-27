## **Section 8: Nullable Types**

**Value Types**
* Cannot be null
```csharp
bool hasAcess = true; // or false
```

**Database**
* Can have null
* ex. - `Customer.Birthday (datetime NULL)`

```csharp
namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = null; // this will error out because a DateTime is a value type and cannot be null.

            // you can fix it like this:
            Nullable<DateTime> date = null;

            // shorthand is like this:
            DateTime? date = null;

            // Nullable methods:

            // GetValueOrDefualt()
            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault()); 
            // this will return 1/01/0001 12:00:00 AM because that is the defualt and there are no values.

            // HasValue
            Console.WriteLine("HasValue: " + date.HasValue); 
            // this will return false because the only value we have applied is null.

            // Value()
            Console.WriteLine("Value: " + date.Value); 
            // this will error out if there are no values

            // With values:

            DateTime? date = new DateTime(2014, 1, 1);
            DateTime date2 = date; // this will not compile, because if `date` is null, then `date2` will error out
            // but we can do this
            DateTime date2 = date.GetValueOrDefault(); // this will compile

            DateTime? date3 = date2; // this will easily be converted to a nullable type


            // ------- Null Coalescing Operator -------
            // This is how it woul look without the operator
            DateTime? date = null;
            DateTime date2;

            if (date != null)
                date2 = date.GetValueOrDefault();
            else
                date2 = DateTime.Today;

            // This is how it woul look with the operator
            DateTime? date = null;
            DateTime date2 = date ?? DateTime.Today;
        }
    }
}
```