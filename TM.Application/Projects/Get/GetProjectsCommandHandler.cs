using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Application.Projects.ProjectDtos;
using TM.Domain.Entities;
using TM.Domain.IRepositories;

namespace TM.Application.Projects.Get
{
    internal class GetProjectsCommandHandler : IRequestHandler<GetProjectsCommand, List<ProjectToReturn>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IProjectRepository _projectRepository;
        public GetProjectsCommandHandler(IApplicationDbContext dbContext, IProjectRepository projectRepository) 
        {
            _context = dbContext;
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectToReturn>> Handle(GetProjectsCommand request, CancellationToken cancellationToken)
        {
            
            var projects = await _projectRepository.GetAllProjects();
            
            return projects.Select(p => new ProjectToReturn
                            {
                                ProjectName = p.Name,
                                NumberOfTasks = p.Tasks.Count
                            }).ToList();
        }

       
    }
}
