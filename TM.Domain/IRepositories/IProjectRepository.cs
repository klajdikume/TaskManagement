using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Domain.IRepositories
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllProjects();
    }
}
