using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;
using TM.Domain.Repositories;
using Task = TM.Domain.Entities.Task;

namespace TM.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Domain.Entities.Task?> GetByIdAsync(TaskId id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<List<Task>> GetTasksWithoutProject()
        {
            return await _dbContext.Tasks
                .Where(t => t.ProjectId == null)
                .ToListAsync();
        }

        public void Update(Task task)
        {
            _dbContext.Tasks.Update(task);
        }
    }
}
