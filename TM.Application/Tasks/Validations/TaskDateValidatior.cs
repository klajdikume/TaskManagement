using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Tasks.Validations
{
    internal class TaskDateValidatior : AbstractValidator<Domain.Entities.Task>
    {
        public TaskDateValidatior()
        {
            RuleFor(task => task.StartDate)
               .NotEmpty().WithMessage("Start date is required.");
               
            RuleFor(task => task.DueDate)
                .GreaterThan(task => task.StartDate).WithMessage("Due date must be greater than the start date.");
        }
    }
}
