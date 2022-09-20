using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }
        public User(string fullName, string name, string email, string username, string password, DateTime birthDate, string location, string bio)
        {
            FullName = fullName;
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;
            Bio = bio;
            Location = location;
            Tweets = new List<UserTweet>();
            Followers = new List<UserFollower>();
            Following = new List<UserFollowing>(); 
        }

        public string? FullName { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public string? Bio { get; private set; }
        public string? Location { get; private set; }
        public bool Active { get; private set; }
        public List<UserTweet>? Tweets { get; private set; }
        public List<UserFollower>? Followers { get; private set; }
        public List<UserFollowing>? Following { get; private set; }

    }
}
