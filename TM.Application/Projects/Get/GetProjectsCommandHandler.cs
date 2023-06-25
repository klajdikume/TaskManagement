using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;

namespace TM.Application.Projects.Get
{
    internal class GetProjectsCommandHandler : IRequestHandler<GetProjectsCommand, List<Project>>
    {
        private readonly IApplicationDbContext _context;

        public GetProjectsCommandHandler(IApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<List<Project>> Handle(GetProjectsCommand request, CancellationToken cancellationToken)
        {
            return await _context.Projects.ToListAsync();
        }

       
    }
}
