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
        Task<PaginationResult<Follow>> GetAllFollowsAsync(string username, int page = 1);
        Task<Follow> AnyAsync(string username);
        Task Add(Follow follow);
        Task Remove(Follow follow);
    }
}
