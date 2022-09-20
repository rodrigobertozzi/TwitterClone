using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Follower : BaseEntity
    {
        
        public Follower(int idFollower, User username)
        {
            IdFollower = idFollower;
            Username = username;
        }
        public Follower()
        {

        }

        public int IdFollower { get; private set; }
        public User? Username { get; private set; }
    }
}
