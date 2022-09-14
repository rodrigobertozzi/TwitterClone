using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet(int idTweet, string content)
        {
            IdTweet = idTweet;
            Content = content;
            CreatedAt = DateTime.Now;
        }

        public int IdTweet { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
