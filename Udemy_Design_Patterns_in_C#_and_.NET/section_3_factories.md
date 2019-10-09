## **Section 3: Factories**

Factory method pattern and the abstract factory pattern.

**Motiviation**
* Object creation logic becomes to convoluted
* Constructor is not descriptive
    * Name mandated by name of containing type
    * Cannot overload with same sets of arguments with different names
    * Can turn into 'optional parameter hell'
* Object creation (non-piecewise, unlike Builder) can be outsourced to
    * A separate function (Factory Method)
    * That may exist in a separate class (Factory)
    * Can create hierachy of factories with Abstract Factory

**Factory**
* A component responsible solely for the wholesale (not piecewise) creation of objects.

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatters 
{
    public class Demo
    {
        static void Main(string[] args)
        {

        }
    }
}
```