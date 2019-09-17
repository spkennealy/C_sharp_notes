## **Section 6: Interfaces**

### **What is an Interface?**

An interface is a language construct that is similar to a class (based on syntax), but is fundamentally different.
```csharp
public interface ITaxCalculator
{
    int Calculate();
}
```
* For convention, all interface names begin with an `I`.
* All methods do not have implementation, they are just declarations.
* No access modifiers.

**Why?**
Interfaces are used to build loosely-coupled applications.

### **Interfaces & Testability**
* Use an interface to make classes loosely-coupled and make it reuseable in different unit tests.

### **Interfaces & Extensibility**
```csharp
using System;
using System.IO;

namespace Extensibility
{
    // ILogger.cs
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }

    // ConsoleLogger.cs
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Conosle.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Conosle.ForegroundColor = ConsoleColor.Green;
            throw new NotImplementedException();
        }
    }

    // FileLogger.cs
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        private void Log(string message, string messageType)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(messageType + ": " + message);
                // streamWriter.Dispose(); not needed here becuase of the using block
            }
        }
    }

    // DbMigrator.cs
    public class DbMigrator
    {
        private readonly ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            _logger = logger; // this is dependency injection
        }

        public void Migrate()
        {
            // Console.WriteLine("Migration started at {0}", DateTime.Now);
            // instead do this:
            _logger.LogInfo("Migration started at {0}", DateTime.Now);

            // details of migrating the database

            // Console.WriteLine("Migration finished at {0}", DateTime.Now);
            // instead do this:
            _logger.LogInfo("Migration finished at {0}", DateTime.Now);
        }
    }

    // Program.cs 
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new FileLogger("C:\\Projects\\log.txt"));
            dbMigrator.Migrate();
        }
    }
}
```

### **Interfaces & Inheritance**

Interfaces have nothing to do with inheritance, because you still need to implement the methods in that interface.

```csharp
namespace MultipleInheritance
{
    // IDraggable.cs
    public interface IDraggable
    {
        void Drag();
    }
    
    // IDroppable.cs
    public interface IDroppable
    {
        void Drop();
    }

    public class TextBox : UiControl, IDraggable, IDroppable
    {
        public void Drag()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }
    }

    public class UiControl
    {
        public string Id { get; set; }
        public Size Size { get; set; }
        public Position TopLeft { get; set; }

        public virtual void Draw()
        {

        }
    }
}
```

### **Interfaces and Polymorphism**
```csharp
using System.Collections;
using System.Collections.Generic;

namespace Polymorphism
{
    // VideoEncoder.cs
    public class VideoEncoder
    {
        // private readonly MailService _mailService; no longer need this with the INotificationChannel
        priavte readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            // _mailService = new MailService(); this will change to this:
            _notificationChannels = new List<INotificationChannel>();
        }

        public void Encode(Video video)
        {
            // Video encoding logic
            // ...

            // _mailService.Send(new Mail()); This will be removed

            foreach (var channel in _notificationChannels)
                channel.Send(new Message());
        }

        public void RegisterNotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }
    }

    // MailService.cs
    public class MailService
    {
        public void Send(Mail mail)
        {
            Console.WriteLine("Sending email...");
        }
    }

    // INotificationChannel.cs
    public interface INotificationChannel
    {
        void Send(Message message);
    }

    // Message.cs
    public class Message
    {

    }

    // MailNotificationChannel.cs
    public class MailNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending mail...");
        }
    }

    // SmsNotificationChannel.cs
    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending SMS...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var encoder = new VideoEncoder();
            encoder.RegisterNotificationChannel(new MailNotificationChannel());
            encoder.RegisterNotificationChannel(new SmsNotificationChannel());
            encoder.Encode(new Video());
        }
    }
}
```