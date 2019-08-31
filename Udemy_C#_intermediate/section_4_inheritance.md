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