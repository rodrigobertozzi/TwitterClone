using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
