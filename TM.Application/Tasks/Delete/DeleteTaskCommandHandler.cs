using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Data;
using TM.Domain.Exceptions;

namespace TM.Application.Tasks.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(request.TaskId);

            if (task == null)
            {
                throw new TaskNotFoundException(request.TaskId);
            }

            _dbContext.Tasks.Remove(task);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

       
    }
}
