using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;

namespace Twitter.Infrastructure.Persistance.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private const int PAGE_SIZE = 2;
        private readonly TwitterDbContext _dbContext;
        public FollowRepository(TwitterDbContext dbContext)
        {
            _dbContext = dbContext;
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
            IQueryable<Follow> follow = _dbContext.Follows;

            follow = follow
               .Where(f => f.FollowedId == followedId && f.FollowerId == followerId);

            return await follow.FirstAsync();
        }

        public async Task Remove(Follow follow)
        {
            _dbContext.Follows.Remove(follow);
            await _dbContext.SaveChangesAsync();
        }
    }
}
