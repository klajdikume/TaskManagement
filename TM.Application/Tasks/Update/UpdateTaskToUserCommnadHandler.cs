using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;
using TM.Domain.Exceptions;
using Task = TM.Domain.Entities.Task;

namespace TM.Application.Tasks.Update
{
    internal class UpdateTaskToUserCommnadHandler : IRequestHandler<UpdateTaskToUserCommnad, TaskId>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateTaskToUserCommnadHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskId> Handle(UpdateTaskToUserCommnad request, CancellationToken cancellationToken)
        {
            var taskToAssign = await _dbContext.Tasks.FindAsync(request.TaskId);

            if (taskToAssign == null)
            {
                throw new TaskNotFoundException(request.TaskId);
            }

            taskToAssign.AssignToUser(request.UserId);

            _dbContext.Tasks.Update(taskToAssign);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return taskToAssign.TaskId;
        }
    }
}
