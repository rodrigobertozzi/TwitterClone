using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;

namespace Twitter.Infrastructure.Persistance.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private const int PAGE_SIZE = 2;
        private readonly TwitterDbContext _dbContext;
        private readonly string _connectionString;
        public FollowRepository(TwitterDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("TwitterCs");
        }

        public async Task Add(Follow follow)
        {
            _dbContext.Follows.Add(follow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginationResult<Follow>> GetAllFollowsAsync(int followerId, int page)
        {
            IQueryable<Follow> follows = _dbContext.Follows;
            
             follows = follows
                .Where(f => f.FollowerId == followerId);
            
            return await follows.GetPaged<Follow>(page, PAGE_SIZE);
        }

        public async Task<Follow> GetByIdAsync(int followedId, int followerId)
        {
            return await _dbContext.Follows.SingleOrDefaultAsync(f => f.FollowedId == followedId && f.FollowerId == followerId);
        }

        public async Task Remove(Follow follow)
        {
            _dbContext.Follows.Remove(follow);
            await _dbContext.SaveChangesAsync();
        }
    }
}
