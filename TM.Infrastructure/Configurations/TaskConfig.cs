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

            builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(li => li.ProjectId);

            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(li => li.UserId);
        }
    }
}
