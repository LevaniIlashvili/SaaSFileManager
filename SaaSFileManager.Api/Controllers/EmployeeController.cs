using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Employees.Commands.ActivateEmployee;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("activate/{activationToken}")]
        public async Task<ActionResult> ActivateAccount([FromRoute] string activationToken, [FromBody] string password)
        {
            var command = new ActivateEmployeeCommand();
            command.ActivationToken = activationToken;
            command.Password = password;

            await _mediator.Send(command);

            return Ok();
        }
    }
}
