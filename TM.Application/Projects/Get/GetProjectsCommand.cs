﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Projects.ProjectDtos;
using TM.Domain.Entities;

namespace TM.Application.Projects.Get
{
    public record GetProjectsCommand : IRequest<List<ProjectToReturn>>;
}
