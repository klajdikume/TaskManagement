using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Tasks.Update
{
    public record UpdateTaskCommand(Task Task) : IRequest;
    public record UpdateTaskRequest(Task Task);
}
