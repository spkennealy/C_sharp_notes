## **Section 6: Arrays & Lists**

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

