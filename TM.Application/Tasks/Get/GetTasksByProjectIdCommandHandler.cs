using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Application.Tasks.TaskDtos;
using TM.Domain.Entities;
using TM.Domain.Exceptions;

namespace TM.Application.Tasks.Get
{
    public class GetTasksByProjectIdCommandHandler : IRequestHandler<GetTasksByProjectIdCommand, ProjectDTO>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTasksByProjectIdCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDTO> Handle(GetTasksByProjectIdCommand request, CancellationToken cancellationToken)
        {
            // get task 

            var projectTasks = await _dbContext.Projects
                                .Where(p => p.ProjectId == request.ProjectId)
                                .Select(p => new ProjectDTO
                                {
                                    
                                    Name = p.Name,
                                    Tasks = p.Tasks
                                })
                                .FirstOrDefaultAsync(cancellationToken);

            if (projectTasks is null) 
            {
                throw new ProjectNotFoundException(request.ProjectId);
            }

            return projectTasks;
            
        }
    }
}
