using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Auth.Queries.LoginCompany;
using SaaSFileManager.Application.Features.Auth.Queries.LoginEmployee;

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

        [HttpPost("company/login")]
        public async Task<ActionResult<string>> CompanyLogin(LoginCompanyQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }

        [HttpPost("employee/login")]
        public async Task<ActionResult<string>> EmployeeLogin(LoginEmployeeQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }
    }
}
