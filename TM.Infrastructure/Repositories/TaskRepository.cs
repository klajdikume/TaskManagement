using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;
using TM.Domain.Repositories;

namespace TM.Infrastructure.Repositories
{
    public class TaskRepository : IProjectRepository
    {
        public Task<Project?> GetByIdAsync(ProjectId id)
        {
            throw new NotImplementedException();
        }
    }
}
