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
            var videoEncoder = new VideoEncoder();

            videoEncoder.Encode(video);
        }
    }

    // Video.cs
    public class Video
    {
        public string Title { get; set; }
    }

    // VideoEncoder.cs
    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event, based on that delegate
        // 3. Raise the event

        public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        // convention says that it should be protected, virtual, void, and start with 'On'
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty);
            }
        }
    }
}
```