## **Section 9: Working with Files***

### **System.IO Namespace**

* File, FileInfo
    * Provide methods for creating, copying, deleting, moving, and opening of files.
    * File: provides static methods
        * More convenient to access
        * Every time one is called, there is a security check to make sure that the current user has access to the file. If you have a large number of operations, this will affect the performance of your application.
    * FileInfo: provides instance methods
        * Creating an instance will only have one security check and then you can access all of the instance methods.
    * Some useful methods:
        * Create()
        * Copy()
        * Delete()
        * Exists()
        * GetAttributes()
        * Move()
        * ReadAllText()
* Directory, DirectoryInfo
    * Directory: provides static methods
    * DirectoryInfo: provides instance methods
    * Some useful methods: 
        * CreateDirectory()
        * Delete()
        * Exists()
        * GetCurrentDirectory()
        * GetFiles()
        * Move()
        * GetLogicalDrives()
* Path
    * Works with a string that contains a file or directory path information.
    * Some useful methods:
        * GetDirectoryName()
        * GetFileName()
        * GetExtension()
        * GetTempPath()

### **File & FileInfo Demo**
```csharp
using System.IO;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // the @ symbol allows you to not have to espace the \
            File.Copy(@"c:\Desktop\tempfile.png", @"d:\tempfile.png", true); // first arg is source file, second arg is the destination, third arg is a boolean if the file exists there you can overwrite it

            File.Delete(@"c:\path"); 

            if (File.Exists(@"c:\path"))
            {
                // ...
            }

            var content = File.ReadAllText(@"c:\path"); // will be a string of all the content

            var path = @"c:\path";

            // FileInfo uses instance methods
            var fileInfo = new FileInfo(path);
            fileInfo.CopyTo("...");
            fileInfo.Delet(); // no parameters
            if (fileInfo.Exists())
            {
                // ...
            }
        }
    }
}

### **Directory & DirectoryInfo Demo**
```csharp
using System.IO;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\folder1";

            Directory.CreateDirectory(path); 
            var files = Directory.GetFiles(path, "*.*", SearchOptions.AllDirectories); // 1. path, 2. search pattern (example is all files), 3. search options
            // returns all files in a string

            var directories = Directory.GetDirectories(path, "*.*", SearchOptions.AllDirectores); // same arguements as above

            Directory.Exists(path); 

            var directoryInfo = new DirectoryInfo("..");
            directoryInfo.GetFiles();
            directoryInfo.GetDirectories();
        }
    }
}
```

### **Path Demo**
```csharp
using System.IO;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\Projects\CSharpFundamentals\HelloWorld\HelloWorld.sln";

            var dotIndex = path.IndexOf('.');
            var extension = path.SubString(dotIndex);

            Path.GetExtension(path); // will do the same as above
            Path.GetFileName(path); 
            Path.GetFileNameWithoutExtension(path); 
            Path.GetDirectoryName(path); 
        }
    }
}
```