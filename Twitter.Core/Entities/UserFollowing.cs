using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Enums;

namespace Twitter.Core.Entities
{
    public class UserFollowing : BaseEntity
    {
        public UserFollowing()
        {

        }


        public int IdUser { get; private set; }
        public int IdFollowing { get; private set; }
        public Following Following { get; private set; } = new Following();
    }
}
