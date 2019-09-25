## **Section 6: Extension Methods**

What are extension methods?
* Allow us to add methods to an existing class without
    * changin its source code, or 
    * createing a new class that inherits from it

To create an extension method, you must create a `public static class`.

```csharp
namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "This is supposed to be a very long blog post blah blah blah...";
            var shortenedPost = post.Shorten(5);
        }
    }

    // StringExtensions.cs
    // convention is to name it the class you are extending with 'Extensions' added to the end
    public static class StringExtensions
    {
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords == 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to 0.");

            if (numberOfWords == 0)
                return "";
            
            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;
            
            return string.Join(' ', words.Take(numberOfWords));
        }
    }

    public class RichString : String {} // this will give an error because you cannot inherit from a sealed class, like string
}
```
* Extension methods come to existence when the class that created them are in the scope.