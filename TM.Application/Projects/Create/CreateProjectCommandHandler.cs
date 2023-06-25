using FluentValidation;
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
        private readonly IValidator<CreateProjectCommand> _validator;

        public CreateProjectCommandHandler(
            IApplicationDbContext context, 
            IValidator<CreateProjectCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Project.Create(request.name);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
