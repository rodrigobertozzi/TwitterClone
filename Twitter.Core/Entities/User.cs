using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class User : BaseEntity
    {
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
            Tweets = new List<Tweet>();
            Followers = new List<UserFollower>();
            Following = new List<UserFollowing>(); 
        }

        public User()
        {

        }

        public string FullName { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Bio { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        public bool Active { get; private set; }
        public List<Tweet> Tweets { get; private set; } = new List<Tweet>();
        public List<UserFollower> Followers { get; private set; } = new List<UserFollower>();
        public List<UserFollowing> Following { get; private set; } = new List<UserFollowing>();

    }
}
