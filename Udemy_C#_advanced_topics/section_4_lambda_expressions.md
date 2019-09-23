## **Section 4: Lambda Expressions**

What is a Lambda Expression?
An anonymous method:
* No access modifier
* No name
* No return statement

What do we use them?
* For convenience, and less code to write

```csharp
namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Square(5)); // returns 25

            // args => expression
            // number => number * number; // equivalent to Square(number); 

            // first parament represents the arguement and the second represents the return value
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5)); // returns 25

            // another example
            const int factor = 5;

            Func<int, int> multiplier = n => n * factor;
            var result = multiplier(10); // returns 50
        }

        static int Square(int number)
        {
            return number * number;
        }
    }
}
```


```csharp
namespace LambdaExpressions
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<book>
            {
                new Book() { Title = "Title 1", Price = 5 },
                new Book() { Title = "Title 2", Price = 7 },
                new Book() { Title = "Title 3", Price = 17 }
            };
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // books.FindAll(Predicate<Book>) -- all find methods accept a predicate
            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);

            // instead, you can do this:
            var cheapBooksLambda = books.FindAll(book => book.Price < 10);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }
        }

        // This is predicate method
        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }
    }
}
```