## **Section 8: Working with Text**

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
            builder.Append('-', 10); // many different overloads (aka arguements)
            builder.AppendLine(); // adds a line break

            builder.Replace('-', '+'); // replaces all dashes with the plus sign
            builder.Remove(0, 10); // removes 10 characters starting from index 0
            builder.Insert(0, new string('-', 10)); // inserts 2nd arg (10 dashes) at index 0 (frist arg)

            builder[0] // --> "-" you can use the index to return the character

            // you can also chain methods on to each other
            var builder2 = new StringBuilder(); 
            builder2
                .Append('-', 10)
                .AppendLine()
        }
    }
}
```

### **Procedural Programming**

Procedural Programming: A programming paradigm based on procedure calls.
Object-orented Programming: A programming paradigm based on objects.

Always separate the code that works with the console from other logic.

**Building a method**
```csharp
public static string ReversedName(string name)
// 1. public or private - do you want other methods to be able to use this method
// 2. static - if you want to be able to call the method from the Main method
// 3. data type - what will be returned from this method, this can be void if nothing is returned
// 4. name of method
// 5. arguements inside the paraenthesis with a data type or class declaration before the variable name
{
    var array = new char[name.Length];
    for (var i = name.Length; i > 0; i--)
        array[name.Length - 1] = name[i - 1];

    var reversed = new string(array);

    return reversed;
}

// example 2:
public static List<int> GetUniqueNumbers(List<int> numbers)
{
    var uniques = new List<int>();
    foreach (var number in numbers)
    {
        if (!uniques.Contains(number))
            uniques.Add(number);
    }

    return uniques;
}
```

