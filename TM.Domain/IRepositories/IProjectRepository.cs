using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(ProjectId id);
    }
}
