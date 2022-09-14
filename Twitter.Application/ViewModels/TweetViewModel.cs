using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.ViewModels
{
    public class TweetViewModel
    {
        public TweetViewModel(int idTweet, string content, DateTime createdAt)
        {
            IdTweet = idTweet;
            Content = content;
            CreatedAt = createdAt;
        }

        public int IdTweet { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
