using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Application.Projects.Get
{
    public record GetProjectsCommand : IRequest<List<Project>>;
}
