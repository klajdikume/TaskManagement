﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TM.Application.Data;
using TM.Domain.Entities;
using TM.Domain.Primitives;
using Task = TM.Domain.Entities.Task;

namespace TM.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Task> Tasks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
    
}