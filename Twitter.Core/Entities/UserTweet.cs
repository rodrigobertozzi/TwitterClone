using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class UserTweet : BaseEntity
    {
        public UserTweet()
        {

        }
        public UserTweet(string content, int idTweet, int idUser, User username)
        {
            Content = content;
            IdTweet = idTweet;
            IdUser = idUser;
            Username = username;

            CreatedAt = DateTime.Now;
        }
        public string? Content { get; private set; }
        public int IdTweet { get; private set; }
        public int IdUser { get; private set; }
        public User? Username { get; private set; }
        public DateTime? CreatedAt { get; private set; }
    }
}
