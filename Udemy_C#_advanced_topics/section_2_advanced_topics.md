## **Section 2: Advanced Topics**

### **Generics**

```csharp
using System;

namespace Generics
{
    // this is the old way
    public class ObjectList
    {
        public void Add(object value)
        {

        }

        public object this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    // instead of above, we can use a generic
    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book { Isbn = "1111", Title = "C# Advnaced" };

            // var number = new List();
            // numbers.Add(10);

            // var books = new BookList();
            // books.Add(book);

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            // most of the time you won't need to create your own generic, you can just use:
            System.Collections.Generic. // everything after this dot

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());
        }
    }
}
```
* Any type can be passed to `T` in a generic.

```csharp
namespace Generics
{
    // you can also apply the "where T : IComparable" to the class level
    public class Utilities // Utilities<T> where T : IComparable
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public T Max<T>(T a, T b)
        {
            return a > b ? a : b; // this won't compile because it doesn't konw the type of T
        }

        public T Max<T>(T a, T b) where T : IComparable // this will allow it to compile
        {
            return a.CompareTo(b) > 0 ? a : b; 
        }

        public void DoSomething(T value)
        {
            var obj = new T(); // this will not compile unless you add this constraint "where T : new()"
        }
    }
}
```

* Other Constraints:
    * `where T : IComparable`: applying a constraint to an interface
    * `where T : Product`: applying to a certain class and any of it's subclasses
    * `where T : struct`: it has to be a value type
    * `where T : class`: the same class, reference type
    * `where T : new()`: where T has a default constructor

```csharp
namespace Generics
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            product.Price // you'll get all the attributes and methods from the product class
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product
    {
        public string Isbn { get; set; }
    }
}
```

```csharp
namespace Generics
{
    // this is availalbe in System.Null
    public class Nullable<T> where T : struct
    {
        // value types cannot be null, but if we do this constraint we can
        private object _value;

        public Nullable()
        { 
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var number = new Nullable<int>(5);
            Console.WriteLine("Has Value? " + number.HasValue); // true
            Console.WriteLine("Value: " + number.GetValueOrDefault()); // 5

            var number1 = new Nullable<int>();
            Console.WriteLine("Has Value? " + number.HasValue); // false
            Console.WriteLine("Value: " + number.GetValueOrDefault()); // 0
        }
    }
}
```