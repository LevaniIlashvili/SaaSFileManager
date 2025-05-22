using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Employees.Commands.ActivateEmployee
{
    public class ActivateEmployeeCommandHandler : IRequestHandler<ActivateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ActivateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ActivateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var validator = new ActivateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            if (!Guid.TryParse(command.ActivationToken, out var activationToken))
            {
                throw new Exceptions.BadRequestException("Invalid activation token format.");
            }

            var employee = await _employeeRepository.GetByActivationToken(activationToken);

            if (employee == null)
            {
                throw new Exceptions.BadRequestException("Activation token is incorrect");
            }

            employee.IsActivated = true;
            employee.PasswordHash = _passwordHasher.Hash(command.Password);
            employee.ActivationToken = null;

            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
