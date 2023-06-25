using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;

namespace TM.Application.Projects.RemoveTasks
{
    internal sealed class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand>
    {
        private readonly IApplicationDbContext _context;
        public RemoveTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _context
                .Projects
                .Include(t => t.Tasks.Where(t => t.TaskId == request.TaskId))
                .SingleOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);

            if (project is null)
                return;

            project.RemoveTask(request.TaskId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
