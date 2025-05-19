using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
