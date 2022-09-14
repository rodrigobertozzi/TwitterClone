using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class UserFollowing : BaseEntity
    {
        public UserFollowing(int idUser, string username)
        {
            IdUser = idUser;
            Username = username;
        }

        public int IdUser { get; private set; }
        public string Username { get; private set; }
    }
}
