using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Infrastructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder
                .Property(u => u.UserId)
                .HasConversion(
                    user => user.Id,
                    value => new UserId(value));

            builder.Property(u => u.Email).HasMaxLength(255);

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
