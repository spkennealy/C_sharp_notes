## **Section 5: Control Flow**

### **Conditional Statements**
* `if/else`
* `switch/case`
* conditional operator `a ? b : c`

```csharp
// if/else example:
if (condition) 
{
    someCode // if you have one line of code, then no curly braces are needed
}
else if (condition)
{
    someMoreCode
}
else 
{
    evenMoreCode
}

// switch/case example:
switch (role)
{
    case Role.Admin:
        ...
        break;
    case Role.Moderator:
        ...
        break;
    default:
        ...
        break;
}
```

### **Iteration Statements**

The 4 main iteration statements in C#:
* `for`
* `foreach`
* `while`
* `do-while`

**`for`**
```csharp
for (var i = 0; i < 10; i++)
{
    // ...
}
```

**`foreach`**
* can be used on anything with a list nature (ie strings, arrays)
```csharp
foreach (var number in numbers)
{
    // ...
}
```

**`while`**
```csharp
var i = 0;
while (i < 10)
{
    // ...
    i++;
}
```

**`do-while`**
* the block must be executed at least once because the `while` check comes after the block.
```csharp
var i = 0;
do
{
    // ...
    i++;
} while (i < 10)
```

**Important Keywords**
* `break`: jumps out of the loop
* `continue`: jumps to the next iteration of the loop

### **Random Class**