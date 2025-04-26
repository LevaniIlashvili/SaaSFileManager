using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Auth.Commands.ActivateCompany;
using SaaSFileManager.Application.Features.Auth.Commands.CreateCompany;
using SaaSFileManager.Application.Features.Auth.Queries.LoginCompany;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("company/register")]
        public async Task<IActionResult> CompanyRegister(RegisterCompanyCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("company/login")]
        public async Task<IActionResult> CompanyLogin(LoginCompanyQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }

        [HttpGet("company/activate/{token}")]
        public async Task<IActionResult> ActivateCompany(string token)
        {
            var command = new ActivateCompanyCommand();
            command.Token = token;
            await _mediator.Send(command);

            return Ok();
        }
    }
}
