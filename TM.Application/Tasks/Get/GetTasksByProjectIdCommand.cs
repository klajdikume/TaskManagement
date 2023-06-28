using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Tasks.TaskDtos;
using TM.Domain.Entities;

namespace TM.Application.Tasks.Get
{
    public record GetTasksByProjectIdCommand(ProjectId ProjectId) : IRequest<ProjectDTO>;
}
