using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;

namespace Twitter.Domain.Repositories
{
    public interface ITweetRepository
    {
        Task<PaginationResult<Tweet>> GetAllAsync(string username, int page = 1);
        Task<Tweet> GetByIdAsync(int id);
        Task AddAsync(Tweet tweet);
        Task DeleteAsync(Tweet tweet);
    }
}
