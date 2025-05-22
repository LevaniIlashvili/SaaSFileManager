using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public RemoveEmployeeCommandHandler(IEmployeeRepository employeeRepository, ILoggedInUserService loggedInUserService)
        {
            _employeeRepository = employeeRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task Handle(RemoveEmployeeCommand command, CancellationToken cancellationToken)
        {
            var companyId = _loggedInUserService.UserId;

            var employee = await _employeeRepository.GetByIdAsync(command.EmployeeId);

            if (employee == null || employee.CompanyId != Guid.Parse(companyId))
            {
                throw new Exceptions.NotFoundException("Employee not found");
            }

            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
