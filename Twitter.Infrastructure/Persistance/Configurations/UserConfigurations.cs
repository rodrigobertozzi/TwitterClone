using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Infrastructure.Persistance.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasIndex(u => u.ApplicationUserId)
                .IsUnique();

            builder
                .Property(u => u.Username)
                .HasMaxLength(20);
            
            builder
                .Property(u => u.Location)
                .HasMaxLength(30);
            
            builder
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
