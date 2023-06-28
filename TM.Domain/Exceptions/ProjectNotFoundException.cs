using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Domain.Exceptions
{
    public sealed class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(ProjectId id)
            : base($"The project with the ID = {id} was not found")
        {
        }
    }
}
