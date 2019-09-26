## **Section 7: Linq**

What is LINQ?
* Stands for: **L**anguage **In**tegrated **Q**uery
* Gives you the capability to query objects

You can query
* Objects in memory, eg collections *(LINQ to Objects)*
* Databases *(LINQ to Entities)*
* XML *(LINQ to XML)*
* ADO.NET Data Sets *(LINQ to Data Sets)*

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // To find the books that are cheaper than $10, if we didn't have Linq, we would have to do this:
            var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Price < 10)
                    cheapBooks.Add(book);
            }

            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title + " " + book.Price);
            // --------------

            // with Linq, we can do this:
            var cheapBooks = books.Where(book => book.Price < 10);

            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title + " " + book.Price);
            // --------------
            
            // Linq.OrderBy
            books.OrderBy(b => b.Title);
            // you can also chain the methods
            var cheapBooks = books.Where(book => book.Price < 10).OrderBy(b => b.Title);
            // --------------

            // Linq.Select
            var cheapBooks = books
                                .Where(book => book.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title);
            // Select will select the titles only, which are strings in this case
            // The indentations are convention
            // The syntax above is called LINQ Extension Methods

            // LINQ Query Operators
            // This does the same thing as above.
            var cheaperBooks = 
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // To find or get one "book" (object) in a list, you can use the Single method
            var book = books.Single(b => b.Title == "ASP.NET MVC");
            // If that book is not found, there will be an exception

            // if you're not sure it the object is in the list, you can use SingleOrDefault
            var book = books.SingleOrDefault(b => b.Title == "ASP.NET MVC");
            // this will return null if not found

            // First will get the first object. You can pass a predicate to find the first that fits your condition.
            // We also have FirstOrDefault, Last, and LastOrDefault
            var book = books.First();
            var book = books.First(b => b.Title == "C# Advanced Topics");
            var book = books.FirstOrDefualt(b => b.Title == "C# Advanced Topics");
            var book = books.Last(b => b.Title == "C# Advanced Topics");
            var book = books.LastOrDefualt(b => b.Title == "C# Advanced Topics");

            // Skip & Take
            // used for paging data
            var book = books.Skip(2).Take(3);

            // Count
            var count = books.Count();

            // Max & Min - in a list of books, you would need to give it a meaning
            var highestPricedBook = books.Max(b => b.Price);
            var highestPricedBook = books.Min(b => b.Price);

            // Sum
            var sum = books.Sum(b => b.Price);
        }
    }

    // BookRepository.cs
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() { Title = "ADO.NET Step by Step", Price = 5 },
                new Book() { Title = "ASP.NET MVC", Price = 9.99f },
                new Book() { Title = "ASP.NET Web API", Price = 12 },
                new Book() { Title = "C# Advanced Topics", Price = 7 },
                new Book() { Title = "C# Advanced Topics", Price = 9 },
            }
        }
    }
}
```