using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Repositories;

namespace TM.Application.Tasks.Get
{
    internal record GetTasksWithoutProjectCommandHandler : IRequestHandler<GetTasksWithoutProjectCommand, List<Domain.Entities.Task>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ITaskRepository _taskRepository;

        public GetTasksWithoutProjectCommandHandler(IApplicationDbContext dbContext, ITaskRepository taskRepository)
        {
            _dbContext = dbContext;
            _taskRepository = taskRepository;
        }

        public async Task<List<Domain.Entities.Task>> Handle(GetTasksWithoutProjectCommand request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTasksWithoutProject();
        }
    }
}
