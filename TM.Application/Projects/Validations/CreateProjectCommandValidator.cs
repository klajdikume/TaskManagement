using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Projects.Create;

namespace TM.Application.Projects.Validations
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(command => command.name).NotEmpty().MaximumLength(50);
            
        }
    }
}
