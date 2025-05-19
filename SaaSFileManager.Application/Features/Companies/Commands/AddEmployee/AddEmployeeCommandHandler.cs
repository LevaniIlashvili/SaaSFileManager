using MediatR;
using Microsoft.Extensions.Options;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Application.Models.Application;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Companies.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Guid>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmailService _emailService;
        private readonly ApplicationSettings _appSettings;

        public AddEmployeeCommandHandler(ILoggedInUserService loggedInUserService, IEmployeeRepository employeeRepository, IEmailService emailService, IOptions<ApplicationSettings> appSettings)
        {
            _loggedInUserService = loggedInUserService;
            _employeeRepository = employeeRepository;
            _emailService = emailService;
            _appSettings = appSettings.Value;
        }

        public async Task<Guid> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var isEmailUnique = await _employeeRepository.IsEmployeeEmailUnique(command.Email);

            if (!isEmailUnique)
            {
                throw new Exceptions.ConflictException("Employee with this email already exists");
            }
               

            var companyId = _loggedInUserService.UserId;

            var activationToken = Guid.NewGuid();

            var employee = new Employee
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                CompanyId = Guid.Parse(companyId),
                ActivationToken = activationToken
            };

            await _employeeRepository.AddAsync(employee);

            await _emailService.SendActivationEmailAsync(command.Email, $"{_appSettings.BaseUrl}/api/employees/activate/{activationToken}");

            return employee.Id;
        }
    }
}
