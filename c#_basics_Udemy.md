# C# Basics for Beginners: Learn C# Fundamentals by Coding

## **Section 1: About the Course**

Will learn C# basics.


## **Section 2: Introduction to C# and .NET**

### **Difference between C# and .NET**
* C# is a programming language.
* .NET is a framework for building web applications.
    * .NET is not limited to C#
    * Made of 2 components:
        * CLR - Common language runtime
        * Class library

### **What is CLR?**

CLR is essentially an application whose job it is to translate the IL (Intermediate Language) code into the machine code. This process is called JIT.

### **Architecture of .NET Applications**

Application will consist of `classes`. Classes are a blueprint for data and methods. Classes have attributes and actions.

`Namespace` is a container for related classes. As namespaces grow, we need another container called an `assembly`. An assembly is a file, in the form of a executable or a DLL, that contains one ore more namespaces and classes.

### **Summary**

**C# vs .NET**
* C# is a programming language, while .NET is a framework. It consists of a run-time environment (CLR) and a class library that we use for building applications.

**CLR** 
* When you compile an application, C# compiler compiles your code to IL (Intermediate Language) code. IL code is platform agnostics, which makes it possible to a take a C# program on a different computer with different hardware architecture and operating system and run it. For this to happen, we need CLR. When you run a C# application, CLR compiles the IL code into the native machine code for the computer on which it is running. This process is called Just-in-time Compilation (JIT).

**Architecture of .NET Applications**
* In terms of architecture, an application written with C# consists of building blocks called classes. A class is a container for data (attributes) and methods (functions). Attributes represent the state of the application. Methods include code. They have logic. That's where we implement our algorithms and write code.

* A namespace is a container for related classes. So as your application grows in size, you may want to group the related classes into various namespaces for better maintainability.

* As the number of classes and namespaces even grow further, you may want to physically separate related namespaces into separate assemblies. An assembly is a file (DLL or EXE) that contains one or more namespaces and classes. An EXE file represents a program that can be executed. A DLL is a file that includes code that can be re-used across different programs.


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