using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;

namespace Twitter.Core.Repositories
{
    public interface IUserRepository
    {
        public string GetByUsername(string username);
        public List<FollowerDTO> GetAllFollowers(string username);
        public List<FollowingDTO> GetFollowings(string username);
    }
}
