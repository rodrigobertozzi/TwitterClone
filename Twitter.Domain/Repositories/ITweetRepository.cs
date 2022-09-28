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
        Task<Tweet> GetByIdAsync(int id);
        Task<PaginationResult<Tweet>> GetAllAsync(string query, int page = 1);
        Task AddAsync(Tweet tweet);
        Task DeleteAsync(Tweet tweet);
    }
}
