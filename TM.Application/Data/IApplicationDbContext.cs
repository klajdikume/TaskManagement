using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
