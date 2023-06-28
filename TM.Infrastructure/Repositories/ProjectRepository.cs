using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;
using TM.Domain.IRepositories;

namespace TM.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ProjectRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _dbContext.Projects
                                    .Include(p => p.Tasks.Where(t => t.ProjectId == p.ProjectId)).ToListAsync();
        }
    }
}
