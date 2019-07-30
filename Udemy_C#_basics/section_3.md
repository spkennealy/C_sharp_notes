## **Section 3: Primitive Types and Expressions**

### **Variables and Constants**

A `variable` is a name that we give to a storage location in memory.
A `constant` is an immutable value. 

### **Declaring Variables/Constants**

To declare a variable, you must start with with the `data type`, then followed with an identifier (usually a string to represent the name of the variable).

To declare a constant, you must start with the keyword `const`, then the `data type`, then the identifier, and you must set it's value.

Examples:
```csharp
int number;
int Number = 1;
const float Pi = 3.14f;
```

`Identifiers` cannot start with a number, cannot include whitespace, and cannot be a reserved keyword. Identifiers should use meaningful names.

**Naming Convention** : Use camelCase for variables and PascalCase for constants.

### **Primitive Data Types**
* Integral numbers (`byte`, `short`, `int`, `long`)
* Real numbers (`float`, `double`, `decimal`)
* Character (`char`)
* Boolean (`bool`)

### **Real Numbers**
* `Double` is the default data type for numbers.
* `Float` & `decimal` require a suffix at the end of each number:
```csharp
float number = 1.2f;
decimal number = 1.2m;
```

### **Non-Primitive Data Types**
* String
* Array
* Enum
* Class

### **Overflowing**

Example:
```csharp
byte number = 255;

number = number + 1; // 0
```

`byte` can only go up to 255, so once it exceeds that number, it drops to 0.

If you do not want overflow, you can use the `checked` keyword. It will throw an exception if the number is exceeded. In reality, you may not use this.
```csharp
checked
{
    byte number = 255;
    number = number + 1; // 0
}
```

### **Scope**

Scope is where a variable or a constant has meaning and is accessible. The varialbe or constant is available in the same clode block, or an of it's child blocks. If you attempt to access the variable outside of it's code block, the program will not compile.
```csharp
{
    byte a = 1;
    {
        byte b = 2;
        {
            byte c = 3;
        }
    }
}
```
* `a` is accessible inside `a`, `b` & `c`
* `b` is accessible inside `b` & `c`
* `c` is accessible inside `c`

### **`var`**

Instead of typing out `byte`, `int`, etc, as the data type, you can use `var` to set a vairalbe and the compilier will detect which data type it is. For all numbers, `var` will detect it as an integer.


### **Type Conversion**

* Implicit Type Conversion
    * Example:
```csharp
// will compile
byte b = 1;
int i = b;

// won't compile
int i = 1;
byte b = i; // this won't work
byte b = (byte)i // this is casting
```
* Explicit Type Conversion (casting)
    * Example:
```csharp
// will compile
float f = 1.0f;
int i = (int)f;
```
* Conversion between two non-compatible types
    * Example:
```csharp
string s = "1";
int i = (int)s; // won't compile
int j = Convert.ToInt32(s); // this works
int j = int.Parse(s); // this works
```

#### **Convert Methods**
* ToByte()
* ToInt16()
* ToInt32()
* ToInt64()

### **Operators**

* `=` = assigns
* `+=` = adds & reassigns
* `-=` = subtracts & reassigns
* `*=` = divided & reassigns
* `/=` = divided & reassigns
* `&&` = and
* `||` = or
* `!` = not