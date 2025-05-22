using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Companies.Commands.AddEmployee;
using SaaSFileManager.Application.Features.Companies.Commands.ChangeInformation;
using SaaSFileManager.Application.Features.Companies.Commands.ChangePassword;
using SaaSFileManager.Application.Features.Companies.Commands.RemoveEmployee;
using SaaSFileManager.Application.Features.Companies.Queries.GetCompanyDetails;
using SaaSFileManager.Application.Features.Companies.Queries.GetEmployees;

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

        [HttpGet]
        public async Task<ActionResult<CompanyDetailsVm>> GetCompanyDetails()
        {
            var query = new GetCompanyDetailsQuery();
            var company = await _mediator.Send(query);
            return Ok(company);
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

        [HttpGet("employees")]
        public async Task<ActionResult<List<EmployeeVm>>> GetEmployees()
        {
            var query = new GetEmployeesQuery();
            var employees = await _mediator.Send(query);

            return Ok(employees);
        }

        [HttpPost("employees")]
        public async Task<ActionResult<Guid>> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            var employeeId = await _mediator.Send(command);

            return Ok(employeeId);
        }

        [HttpDelete("employees/{employeeId}")]
        public async Task<ActionResult> RemoveEmployee([FromRoute] Guid employeeId)
        {
            var command = new RemoveEmployeeCommand();
            command.EmployeeId = employeeId;
            await _mediator.Send(command);

            return NoContent();
        }
    }

}
