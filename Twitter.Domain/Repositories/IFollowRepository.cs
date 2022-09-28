using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;

namespace Twitter.Domain.Repositories
{
    public interface IFollowRepository
    {
        Task<Follow> GetByIdAsync(int followedId, int followerId);
        Task<PaginationResult<Follow>> GetAllFollowsAsync(int followerId, int page = 1);
        Task Add(Follow follow);
        Task Remove(Follow follow);
    }
}
