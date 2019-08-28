using System;

namespace StackOverflowPost
{
    class Program
    {
        public static void Main(string[] args)
        {
            // In the main method, create a post, up-vote and down-vote it a
            // few times and then display the the current vote value.

            var post = new Post(
                                "This is the Title",
                                "This is the description of the post.",
                                DateTime.Now
                                );

            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.DownVote();
            post.UpVote();
            post.DownVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.DownVote();

            Console.WriteLine("Current Value: " + post.CurrentValue());
        }
    }
}
