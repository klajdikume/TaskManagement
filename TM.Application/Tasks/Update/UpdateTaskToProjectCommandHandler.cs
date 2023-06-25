using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;
using TM.Domain.Exceptions;

namespace TM.Application.Tasks.Update
{
    internal class UpdateTaskToProjectCommandHandler : IRequestHandler<UpdateTaskToProjectCommand, TaskId>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateTaskToProjectCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskId> Handle(UpdateTaskToProjectCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(request.TaskId);

            if (task == null)
            {
                throw new TaskNotFoundException(request.TaskId);
            }

            task.SetToProject(request.ProjectId);

            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.TaskId;
        }
    }
}
