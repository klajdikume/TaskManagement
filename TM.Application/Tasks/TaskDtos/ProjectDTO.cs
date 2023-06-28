using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Tasks.TaskDtos
{
    public class ProjectDTO
    {
        public string Name { get; set; } = string.Empty;
        public IReadOnlyList<Task>? Tasks { get; set; } 
    }
}
