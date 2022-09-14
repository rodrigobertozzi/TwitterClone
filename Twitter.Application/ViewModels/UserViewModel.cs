using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string username, string bio, string location)
        {
            Name = name;
            Username = username;
            Bio = bio;
            Location = location;
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Bio { get; private set; }
        public string Location { get; private set; }

    }
}
