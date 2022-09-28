using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string name, string username, DateTime createdAt, string bio, string location)
        {
            Name = name;
            Username = username;
            CreatedAt = createdAt;
            Bio = bio;
            Location = location;
            Tweets = new List<Tweet>();
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Bio { get; private set; }
        public string Location { get; private set; }
        public List<Tweet> Tweets { get; private set; }
    }
}
