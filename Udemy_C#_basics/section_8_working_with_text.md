## **Section 8: Working with Text***

### **Strings**

Strings are immutable. Once you create them, you cannot change them.

**Formatting**
```csharp
var string = "Hello World";

string.ToLower(); // "hello world"
string.ToUpper(); // "HELLO WORLD"
string.trim(); // gets rid of whitespace around the string
```

**Searching**
```csharp
IndexOf('a');
LastIndexOf("Hello"); 
```

**Substrings**
```csharp
Substring(startIndex);
Substring(startIndex, length);
```

**Replacing**
```csharp
Replace('a', '!');
Replace("mosh", "moshfegh");
```

**Null Checking**
```csharp
String.IsNullOrEmpty(str);
String.IsNullOrWhiteSpace(str);
```

**Split**
```csharp
str.Split(' ');
```

**Converting Strings to Numbers**
```csharp
string s = "1234";
int i = int.Parse(s);
int j = Convert.ToInt32(s);
```

**Converting Numbers to Strings**
```csharp
int i = 1234;
string s = i.ToString(); // "1234"
string t = i.ToString("C"); // "$1,234.00"  C is short for currency
string t = i.ToString("C0") // "$1,234"  0 says no decimals, 1 would have 1 decimal
```

### **StringBuilder**

* Defined in System.Text
* A mutable string
* Easy and fast to create and manipulate strings

```csharp
using System.Text;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder(); // you can pass in a string argument to start the builder with
            builder.Append('-', 10) // many different overloads (aka arguements)
            builder.AppendLine(); // adds a line break

            builder.Replace('-', '+'); // replaces all dashes with the plus sign
            builder.Remove(0, 10); // removes 10 characters starting from index 0
            builder.Insert(0, new string('-', 10)); // inserts 2nd arg (10 dashes) at index 0 (frist arg)


        }
    }
}
```