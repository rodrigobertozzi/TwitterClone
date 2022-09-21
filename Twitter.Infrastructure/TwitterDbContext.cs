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

        public DbSet<User> Users => Set<User>();
        public DbSet<Follower> Followers => Set<Follower>();
        public DbSet<Following> Followings => Set<Following>();
        public DbSet<UserFollower> UserFollowers => Set<UserFollower>();
        public DbSet<UserFollowing> UserFollowings => Set<UserFollowing>();
        public DbSet<Tweet> Tweets => Set<Tweet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
