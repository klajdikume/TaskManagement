using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Tasks.Create
{
    internal sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskId>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskId> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            
            var task = Task.Create(request.Task.Title);

            _dbContext.Tasks.Add(task);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.TaskId;
        }

    }
}
