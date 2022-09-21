using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Following : BaseEntity
    {
        public Following(int idFollowing, User username)
        {
            IdFollowing = idFollowing;
            Username = username;
        }
        public Following()
        {

        }

        public int IdFollowing { get; private set; }
        public User Username { get; private set; } = new User();
    }
}
