## **Section 4: Inheritance - Second Pillar of OOP**

### **Access Modifiers**
* `public`
    * accessible from everywhere
* `private`
    * accessible only from the current class
* `protected`
    * accessible only from the class and it's derived classes
    * preferred to use private instead of protected
* `internal`
    * mostly used for class methods and not a class itself, but can be used for a class
    * accessible only from the same assembly
* `protected internal`
    * accessible only from the same assembly or any derived class

**Demo**
```csharp
namespace AccessModifiers
{
    // Customer.cs
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            var rating = CalculateRating1();

            if (rating == 0)
                Console.WriteLine("Promoted to level 1");
            else 
                Console.WriteLine("Promoted to level 2");

        }

        private int CalculateRating1()
        {
            return 0; // any code here
        }

        protected int CalculateRating2()
        {
            return 0; // any code here
        }
    }

    // GoldCustomer.cs
    public class GoldCustomer : Customer
    {
        public void OfferVoucher()
        {
            this.CalculateRating1(); // this will not work
            this.CalculateRating2(); // this will work here because it's derived from Customer
        }
    }

    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            customer.Promote(); // this will work
            customer.CalculateRating1(); // this will not work
        }
    }
}
```

```csharp
// if we moved the Customer class into the Amazon namespace and removed it from the AccessModifier namespace above.

using Amazon;
// Program.cs
namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(); // this will not work unless we add a reference and add the Using statement above
            Amazon.RateCalculator calculator = new RateCalculator(); // this will not work because it's in a different assembly
        }
    }
}

namespace Amazon
{
    // RateCalculator.cs
    internal class RateCalculator
    {
        public int Calculate(Customer customer)
        {
            // any code here
        }
    }

    // Customer.cs
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            var calculator = new RateCalculator(); // this is not great for encapsulation
            var rating = calculator.Calculate(this);

            Console.WriteLine("Promote logic changed");

        }
    }
}
```