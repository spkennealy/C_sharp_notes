## **Section 9: Dynamics**

Programming languages are divided into two types:
* Statically-typed languages: C#, Java
* Dynamically-typed languages: Ruby, Javascript, Python

Type Resolution:
* Static languages: at compile-time
* Dynamic languages: at run-time

Benefits:
* Static languages: early feedback (compile-time)
* Dynamic languages: easier and faster to code
    * needs more unit tests

C# History:
* Started as a static language
* .NET 4 added the dynamic capability, to improve interoperability with
    * COM (eg writing office applications)
    * Dynamic languages (IronPython)

```csharp
namespace DynamicBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = "Sean";
            // obj.GetHashCode();

            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            object excelObject = "sean";
            excelObject.Optimize();

            // dynamic keyword
            dynamic name = "sean";
            name = 10; // this will work

            dynamic a = 10;
            dynamic b = 5;
            var c = ""; // short way of writing code
            // if we set var to a & b
            var d = a + b; // this will be a dynamic type

            // casting
            int i = 5;
            dynamic d = 1; // dynamic[int]
            long l = d;
        }
    }
}
```
* DLR works with CLR.
* When converting from dynamic to static types, if the runtime type of the dynamic object is implicitly convertible,
to the target type, we don't need to cast it.