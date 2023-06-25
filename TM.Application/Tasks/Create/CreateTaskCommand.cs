using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Tasks.Create
{
    public record CreateTaskCommand(Task Task) : IRequest<TaskId>;
    
}
