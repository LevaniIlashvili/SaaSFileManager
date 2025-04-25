using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Companies.Commands.ActivateCompany;
using SaaSFileManager.Application.Features.Companies.Commands.CreateCompany;

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

        [HttpPost(Name = "CreateCompany")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            await _mediator.Send(createCompanyCommand);

            return Ok();
        }

        [HttpGet("activate")]
        public async Task<IActionResult> ActivateCompany([FromQuery] ActivateCompanyCommand activateCompanyCommand)
        {
            var activated = await _mediator.Send(activateCompanyCommand);

            if (activated) return Ok ();

            return BadRequest("Invalid Token");
        }
    }
}
