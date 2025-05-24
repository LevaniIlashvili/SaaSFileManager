using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("company/login")]
        public async Task<IActionResult> CompanyLogin(LoginCompanyQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }
    }
}
