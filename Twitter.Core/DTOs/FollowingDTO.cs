using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.DTOs
{
    public class FollowingDTO
    {
        public FollowingDTO(string name, string username)
        {
            Name = name;
            Username = username;
        }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
