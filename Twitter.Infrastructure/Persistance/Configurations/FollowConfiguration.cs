using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Infrastructure.Persistance.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder
                .HasKey(f => new { f.FollowerId, f.FollowedId });

            builder
                .HasOne(f => f.Followed)
                .WithMany(u => u.Followers)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followeds)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .Ignore(f => f.DomainEvents);
        }
    }
}
