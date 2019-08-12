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