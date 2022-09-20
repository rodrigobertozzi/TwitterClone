using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure.Persistance.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Tweets)
                .WithOne()
                .HasForeignKey(u => u.IdTweet)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.Followers)
                .WithOne()
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.Following)
                .WithOne()
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
