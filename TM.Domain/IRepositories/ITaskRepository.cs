using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Task?> GetByIdAsync(TaskId id);
        Task<List<Task>> GetTasksWithoutProject();
        public void Update(Task task);
    }
}
