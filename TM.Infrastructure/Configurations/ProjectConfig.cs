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
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasConversion(
                    project => project.Id,
                    value => new ProjectId(value));

            builder.Property(c => c.Name).HasMaxLength(100);

            builder
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ProjectId);
        }
    }
}
