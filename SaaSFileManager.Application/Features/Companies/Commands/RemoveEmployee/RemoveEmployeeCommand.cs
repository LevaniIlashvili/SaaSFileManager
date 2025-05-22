using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
    }
}
