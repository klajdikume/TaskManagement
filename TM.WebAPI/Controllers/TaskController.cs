using MediatR;
using Microsoft.AspNetCore.Mvc;
using TM.Application.Tasks.Create;
using TM.Application.Tasks.Delete;
using TM.Application.Tasks.Get;
using TM.Application.Tasks.Update;
using TM.Domain.Entities;

namespace TM.WebAPI.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CreateTaskRequest request)
        {
            var command = new CreateTaskCommand(request.Task);

            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> getTasksByProjectId([FromQuery] ProjectId projectId)
        {
            var command = new GetTasksByProjectIdCommand(projectId);

            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> getAllTasksWithoutProject([FromQuery] ProjectId projectId)
        {
            var command = new GetTasksByProjectIdCommand(projectId);

            return Ok(await _mediator.Send(command));
        }

        
        [HttpPatch]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest request)
        {
            var command = new UpdateTaskCommand(request.Task);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTaskById([FromQuery] TaskId taskId)
        {
            var command = new DeleteTaskCommand(taskId);

            await _mediator.Send(command);

            return Ok();
        }

    }
}
