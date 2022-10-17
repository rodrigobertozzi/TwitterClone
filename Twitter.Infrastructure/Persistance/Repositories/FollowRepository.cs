using Microsoft.EntityFrameworkCore;
using System.Threading;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;
using Twitter.Domain.Services;

namespace Twitter.Infrastructure.Persistance.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private const int PAGE_SIZE = 2;
        private readonly TwitterDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public FollowRepository(TwitterDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
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

        public async Task<Follow> AnyAsync(string username)
        {
            IQueryable<Follow> applicationUser = _dbContext.Follows;
            applicationUser = applicationUser
               .Where(f => f.Followed.Username == username  && f.Follower.ApplicationUserId == _currentUserService.UserId);

            return await applicationUser.FirstAsync();
        }
    }
}
