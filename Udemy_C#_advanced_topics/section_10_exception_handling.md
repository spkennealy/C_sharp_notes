## **Section 10: Exception Handling**

```csharp
namespace ExceptionHandling
{
    public class Calculator
    {
        public int Divide(int numerator, int denomenator)
        {
            return numerator / denomenator;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var result = calculator.Divide(5, 0); // this will error out

            // example here is meant for the finally block
            var streamReader = new StreamReader(@"c:\file.zip");
            // ----------- finally block ex --------------

            // to handle exception, we can use try/catch blocks
            try 
            {
                var calculator = new Calculator();
                var result = calculator.Divide(5, 0); 

                // example here is meant for the finally block
                var content = streamReader.ReadToEnd();
                // ----------- finally block ex --------------
            }
            // you can have multiple catch blocks, starting from the most specific to the most generic
            catch (DivideByZeroException ex)
            {

            }
            catch (ArithmeticException ex)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured.");
            }
            // you can have a finally block and this would be a clean up block
            finally
            {
                streamReader.Dispose(); // whenever you are using files or unmanaged resourses to dispose of them
            }
        }
    }
}
```

**`using` Example**
```csharp
namespace ExceptionHandling
{    
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = null;
            try 
            {
                // no need to use a finally block when the `using` statement is used
                using(var streamReader = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured.");
            }
        }
    }
}
```

**Custom Exceptions**
```csharp
using System;
using System.Collections.Generic;

namespace ExceptionHandling
{    
    // YouTubeException.cs
    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
            : base(message, innerException)
            {

            }
    }

    // YouTubeApi.cs
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // Access YouTube web service
                // Read the date
                // Create a list of Video objects
            }
            catch (Exception ex)
            {
                // Log
                throw new YouTubeException("Could not fetch the videos from YouTube.", ex);
            }

            return new List<Video>();
        }
    }

    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("Sean");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
```