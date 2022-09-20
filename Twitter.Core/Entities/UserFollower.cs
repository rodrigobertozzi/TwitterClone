using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Enums;

namespace Twitter.Core.Entities
{
    public class UserFollower : BaseEntity
    {
        public UserFollower()
        {

        }

        public UserFollower(int idUser, int idFollower)
        {
            IdUser = idUser;
            IdFollower = idFollower;
        }

        public int IdUser { get; private set; }
        public int IdFollower { get; private set; }
        public Follower? Follower { get; private set; }


    }
}
