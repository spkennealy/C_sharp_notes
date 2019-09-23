## **Section 3: Delegates**

What is a delegate?
* An object that knows how to call a method (or a group of methods)
* A reference to a function

Why do we need delegates?
* For designing extensible and flexible applications (eg frameworks)

```csharp
// PhotoProcessor.cs
namespace Delegates
{
    public class PhotoProcessor
    {
        // This is the delegate
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            // instead of this, use a delegate
            // var filters = new PhotoFilters();
            // filters.ApplyBrightness(photo);
            // filters.ApplyContrast(photo);
            // filters.Resize(photo);

            // with passing in a delegate as an arguement, you can do this:
            filterHandler(photo);

            photo.Save();
        }
    }

    // PhotoFilters.cs
    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }

    // Photo.cs
    public class Photo
    {

    }

    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process("photo.jpg", filterHandler);
        }
    }
}
```
* Every delegate is technically a class that inherits from MulticastDelegate.
* MulticastDelegate inherits from System.Delegate.
* MulticastDelegate allows for multiple methods, while System.Delegate only allows for one.

**Generic Delegates**
* `System.Action<>` - action points to a method that returns void.
* `System.Func<>` - funcs points to a method that returns a value.
```csharp
namespace Delegates
{
    public class PhotoProcessor
    {
        // change here
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
    
    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            // change here
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process("photo.jpg", filterHandler);
        }
    }
}
```

**Interfaces or Delegates?**
* Use a delegate when
    * An eventing design patter is used.
    * The caller doesn't need to access other properties or methods on the object implementing the method.

