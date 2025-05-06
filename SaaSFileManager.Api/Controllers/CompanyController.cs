using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Companies.Commands.ChangeInformation;
using SaaSFileManager.Application.Features.Companies.Commands.ChangePassword;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeCompanyPasswordCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch("change-information")]
        public async Task<IActionResult> ChangeInformation([FromBody] ChangeCompanyInformationCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }

}
