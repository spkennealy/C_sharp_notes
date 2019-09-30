## **Section 11: Asynchronous Programming**

**Synchronous Programming Execution**
* Program is executed line by line, one at a time.
* When a function is called, program execution has to wait until the function returns.

**Asynchronous Programming Execution**
* When a function is called, program execution continues to the next line, *without* waiting for the function to complete.
* This improves responsiveness
* When to use?
    * accessing the web
    * working with files and databases
    * working with images
* How?
    * Traditional approaches
        * multi-threading
        * callbacks
    * New approach since NET 4.5
        * `async` / `await`

Example:
```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DownloadHtml("http://msdn.microsoft.com");
    }

    // how to write an aysnc method
    public async Task DownloadHtmlAsync(string url)
    {
        var webClient = new WebClient();;
        var html = await webClient.DownloadStringTaskAsync(url);

        using (var streamWriter = new StreamWriter(@"c:\projects\result.html"))
        {
            streamWriter.Write(html);
        }
    }

    // synchronous way:
    public void DownloadHtml(string url)
    {
        var webClient = new WebClient();;
        var html = webClient.DownloadString(url);

        using (var streamWriter = new StreamWriter(@"c:\projects\result.html"))
        {
            streamWriter.Write(html);
        }
    }
}
```