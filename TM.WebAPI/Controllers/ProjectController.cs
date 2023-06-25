using Microsoft.AspNetCore.Mvc;
using TM.Application.Projects.Create;
using MediatR;
using TM.Application.Projects.Get;

namespace TM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string name)
        {
            var command = new CreateProjectCommand(name);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            var command = new GetProjectsCommand();

            return Ok(await _mediator.Send(command));
        }
    }
}
