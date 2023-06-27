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
    public class TaskConfig : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.HasKey(x => x.TaskId);

            builder
                .Property(t => t.TaskId)
                .HasConversion(
                    task => task.Id,
                    value => new TaskId(value));

            builder
                .HasOne<Project>(t => t.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .HasPrincipalKey(p => p.ProjectId);

            builder
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);

        }
    }
}
