using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Core.Repositories
{
    public interface ITweetRepository
    {
        Task<Tweet> GetByIdAsync(int id);
        Task AddAsync(Tweet tweet);
        Task DeleteAsync(Tweet tweet);
    }
}
