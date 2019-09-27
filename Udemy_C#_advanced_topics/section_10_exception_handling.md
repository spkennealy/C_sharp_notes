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

            // to handle exception, we can use try/catch blocks
            try 
            {
                var calculator = new Calculator();
                var result = calculator.Divide(5, 0); 
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an unexpected error occured.");
            }
        }
    }
}
```