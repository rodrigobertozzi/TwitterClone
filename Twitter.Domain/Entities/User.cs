using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Domain.Entities
{
    public class User : BaseEntity
    {

        public User(string fullName, string name, string email, string username, string password, DateTime birthDate, string bio, string location)
        {
            FullName = fullName;
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthDate;
            Bio = bio;
            Location = location;
        }

        public string FullName { get; private set; } 
        public string Name { get; private set; } 
        public string Email { get; private set; } 
        public string Username { get; private set; } 
        public string Password { get; private set; } 
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string Bio { get; private set; } 
        public string Location { get; private set; } 
        public bool Active { get; private set; } = true;
        public List<Tweet> Tweets { get; private set; } = new List<Tweet>();
        public IEnumerable<Follow> Followers { get; set; } = new List<Follow>();
        public IEnumerable<Follow> Followeds { get; set; } = new List<Follow>();
        
        public void UpdateUser(string fullName, string name, string email, string username, string password, DateTime birthDate, string bio, string location)
        {
            FullName = fullName;
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthDate;
            Bio = bio;
            Location = location;
        }
    }
}
