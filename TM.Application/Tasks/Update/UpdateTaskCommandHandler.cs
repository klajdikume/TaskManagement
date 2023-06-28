using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Exceptions;

namespace TM.Application.Tasks.Update
{
    internal class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(request.Task.TaskId);

            if (task == null)
            {
                throw new TaskNotFoundException(request.Task.TaskId);
            }

            task.updateTask(task);
            _dbContext.Tasks.Update(task);

            await _dbContext.SaveChangesAsync(cancellationToken);

            
        }
    }
}
