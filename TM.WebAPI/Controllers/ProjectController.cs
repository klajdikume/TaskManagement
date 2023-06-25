using Microsoft.AspNetCore.Mvc;
using TM.Application.Projects.Create;
using MediatR;

namespace TM.WebAPI.Controllers
{
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromQuery] string name)
        {
            var command = new CreateProjectCommand(name);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
