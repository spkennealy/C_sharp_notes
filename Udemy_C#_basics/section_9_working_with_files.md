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
