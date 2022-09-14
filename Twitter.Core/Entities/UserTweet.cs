using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class UserTweet : BaseEntity
    {
        public UserTweet(int idUser, int idTweet)
        {
            IdUser = idUser;
            IdTweet = idTweet;
        }

        public int IdUser { get; private set; }
        public int IdTweet { get; private set; }
        public Tweet Tweet { get; private set; }
    }
}
