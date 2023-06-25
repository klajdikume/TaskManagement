using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TM.Application.Projects.Create
{
    internal class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project.Create(request.name);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
