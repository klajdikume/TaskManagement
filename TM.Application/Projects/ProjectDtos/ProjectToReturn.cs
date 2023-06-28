using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Projects.ProjectDtos
{
    public class ProjectToReturn
    {
        public string ProjectName { get; set; } = string.Empty;
        public int NumberOfTasks { get; set; }
    }
}
