using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Domain.Exceptions
{
    public sealed class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(TaskId id)
            : base($"The task with the ID = {id} was not found")
        {
        }
    }

}
