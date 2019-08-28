using System;
namespace StackOverflowPost
{
    public class Post
    {
        // Design a class called Post. This class models a StackOverflow post. It should have properties for title,
        // description and the date/time it was created. We should be able to up-vote or down-vote a post. We should
        // also be able to see the current vote value. In the main method, create a post, up-vote and down-vote it a
        // few times and then display the the current vote value.

        private string Title;
        private string Description;
        private DateTime DateCreated;
        private int voteValue;

        public Post(string title, string description, DateTime currentTime)
        {
            Title = title;
            Description = description;
            DateCreated = currentTime;
            voteValue = 0;
        }

        public void UpVote()
        {
            voteValue++;
        }

        public void DownVote()
        {
            voteValue--;
        }

        public void CurrentValue()
        {
            Console.WriteLine("Vote value: " + voteValue);
        }
    }
}
