using MediatR;

namespace SaaSFileManager.Application.Features.Employees.Commands.ActivateEmployee
{
    public class ActivateEmployeeCommand : IRequest
    {
        public string ActivationToken { get; set; }
        public string Password { get; set; }
    }
}
