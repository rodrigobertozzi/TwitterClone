using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext(DbContextOptions<TwitterDbContext> options) : base(options)
        {
            
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<UserFollower>? UserFollowers { get; set; }
        public DbSet<UserFollowing>? UserFollowings { get; set; }
        public DbSet<UserTweet>? UserTweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
