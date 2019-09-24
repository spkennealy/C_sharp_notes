## **Section 5: Events**

What are events?
* A mechanism for communication between objects.
* Used in building *Loosely Coupled Applications*.
* Helps extending applications.

```csharp
public class VideoEncoder
{
    public void Encode(Video video)
    {
        // Encoding logic
        // ...

        _mailservice.Send(new Mail());
        _messageService.Send(new Text());

        // instead of calling both mailService & messageService 
        OnVideoEncoded();
    }
}
// these will be in the mailService & messageService classes
// you will need a delegate in the VideoEncoder class and that way it will not be coupled to the mailService & messageService classes.
public void OnVideoEncoded(object source, EventArgs e)
{

}
```

Example:
```csharp
namespace EventsAndDelegates
{
    // Program.cs
    class Program
    {
        static void Main(string[] args)
        {
            var vidoe = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber
            var messageService = new MessageService(); // subscriber

            // adds a list of method calls to the publisher
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // no call, just making a reference to the method.
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }

    // Video.cs
    public class Video
    {
        public string Title { get; set; }
    }

    // MailService.cs
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MailSerivce: Sending an email..." + args.Video.Title);
        }
    }

    // MessageService.cs
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MessageService: Sending an SMS..." + args.Video.Title);
        }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    // VideoEncoder.cs
    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event, based on that delegate
        // 3. Raise the event

        // Changed this when adding in the VideoEventArgs
        // public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // convention says that it should be protected, virtual, void, and start with 'On'
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                // when you change EventArgs to a custom class, like VideoEventArgs, in the delegate, you cannot pass in EventArgs args
                // VideoEncoded(this, EventArgs.Empty);
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }
    }
}
```

You can acheive the same thing with less code:
```csharp
// VideoEncoder.cs
public class VideoEncoder
{
    // EventHandler
    // EventHandler<TEventArgs>
    
    public event EventHandler<VideoEventArgs> VideoEncoded; // this class is available in C#

    public void Encode(Video video)
    {
        Console.WriteLine("Encoding video...");
        Thread.Sleep(3000);

        OnVideoEncoded(video);
    }

    // convention says that it should be protected, virtual, void, and start with 'On'
    protected virtual void OnVideoEncoded(Video video)
    {
        if (VideoEncoded != null)
        {
            // when you change EventArgs to a custom class, like VideoEventArgs, in the delegate, you cannot pass in EventArgs args
            // VideoEncoded(this, EventArgs.Empty);
            VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
```
* You most likely won't ever need to create your own event hanlder.