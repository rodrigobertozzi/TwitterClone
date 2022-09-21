using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet()
        {

        }
        public Tweet(string content, int idTweet, int idUser)
        {
            Content = content;
            IdTweet = idTweet;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
        }
        public string Content { get; private set; } = string.Empty;
        public int IdTweet { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
