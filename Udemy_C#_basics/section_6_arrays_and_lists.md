## **Section 6: Arrays & Lists**

### **Arrays**

Two types of arrays:
* single-dimentional
* multi-dimentional
    * rectangular
    * jagged - different number of lengths of the nested arrays

Declaring a rectangular multi-dimentional array:
```csharp
var matrix1 = new int[3, 5];
// if you know the values, you can add a block with the values:
var matrix2 = new int[3, 5]
{
    { 1, 3, 4, 5, 2 },
    { 3, 4, 10, 12, 13}, 
    { 4, 40, 23, 15, 17}
};
// to access an element in the array:
var element = matrix2[0, 0];
```

Declaring a jagged multi-dimentional array:
```csharp
var array = new int[3][];
array[0] = new int[4];
array[1] = new int[5];
array[2] = new int[3];
```

### **Array Demo**
```csharp
namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 7, 9, 2, 14, 6 }

            // Length
            Console.WriteLine("Length: " + numbers.Length);

            // IndexOf()
            var index = Array.IndexOf(numbers, 9);
            Console.WriteLine("Index of 9: " + index);

            // Clear()
            Array.Clear(numbers, 0, 2);
            // this will change the first 2 elements starting at index 0 to the number 0

            // Copy()
            int[] another = new int[3];
            Array.Copy(numbers, another, 3);
            // this copies the first 3 elements from numbers into another

            // Sort()
            Array.Sort(numbers) // [0, 0, 2, 6, 9, 14]

            // Reverse()
            Array.Reverse(numbers) // [14, 9, 6, 2, 0, 0]
        }
    }
}
```

### **Lists**

Similat to an array, but has a dynamic size. Stores a number of objects of the same type.

**Creating lists:**
```csharp
var numbers = new List<int>();
// you must specifiy the data type in the <> brackets
```

**Useful methods**
* Add()
* AddRange()
* Remove()
* RemoveAt()
* IndexOf()
* Contains()
* Count()

### **Lists Demo**

```csharp
namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4 };

            numbers.Add(1);
            numbers.AddRange(new int[3] { 5, 6, 7 });
            // result = [1, 2, 3, 4, 1, 5, 6, 7]
            
            numbers.IndexOf(1); // 0
            numbers.LastIndexOf(1); // 4

            numbers.Count // returns 8

            numbers.Remove(1) // [2, 3, 4, 1, 5, 6, 7] it removes the first 1
            // if you want to remove all the 1s, iterate over the list and remove if 1 (should be a regular for loop)

            numbers.Clear() // [] it clears the entire list
        }
    }
}
```