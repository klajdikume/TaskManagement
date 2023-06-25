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
using TM.Domain.Repositories;

namespace TM.Application.Tasks.Update
{
    internal class UpdateTaskToProjectCommandHandler : IRequestHandler<UpdateTaskToProjectCommand, TaskId>
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IApplicationDbContext _dbContext;

        public UpdateTaskToProjectCommandHandler(
            IApplicationDbContext dbContext,
            ITaskRepository taskRepository
            )
        {
            _dbContext = dbContext;
            _taskRepo = taskRepository;
        }

        public async Task<TaskId> Handle(UpdateTaskToProjectCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepo.GetByIdAsync(request.TaskId);

            if (task == null)
            {
                throw new TaskNotFoundException(request.TaskId);
            }

            task.SetToProject(request.ProjectId);

            _taskRepo.Update(task);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.TaskId;
        }
    }
}
