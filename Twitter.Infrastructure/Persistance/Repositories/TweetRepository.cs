using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;

namespace Twitter.Infrastructure.Persistance.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private const int PAGE_SIZE = 2;
        private readonly TwitterDbContext _dbContext;
        private readonly string _connectionString;
        public TweetRepository(TwitterDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("TwitterCs");
        }

        public async Task<Tweet> GetByIdAsync(int id)
        {
            return await _dbContext
                .Tweets
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PaginationResult<Tweet>> GetAllAsync(string query, int page)
        {
            IQueryable<Tweet> tweets = _dbContext.Tweets;
            if(!string.IsNullOrEmpty(query))
            {
                tweets = tweets
                    .Where(t => t.Content.Contains(query));
            }
            return await tweets.GetPaged<Tweet>(page, PAGE_SIZE);
        }

        public async Task AddAsync(Tweet tweet)
        {
            await _dbContext.Tweets.AddAsync(tweet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tweet tweet)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var script = "DELETE FROM Tweets WHERE Id = @id";
            await sqlConnection.ExecuteAsync(script, new { tweet.Id });
        }
    }
}
