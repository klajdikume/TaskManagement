using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Application.Tasks.Update
{
    public record UpdateTaskToProjectCommand(TaskId TaskId, ProjectId ProjectId) : IRequest<TaskId>;
    
}
