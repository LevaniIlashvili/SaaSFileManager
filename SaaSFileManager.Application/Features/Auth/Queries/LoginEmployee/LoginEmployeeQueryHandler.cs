using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Auth.Queries.LoginEmployee
{
    public class LoginEmployeeQueryHandler : IRequestHandler<LoginEmployeeQuery, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public LoginEmployeeQueryHandler(IEmployeeRepository employeeRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByEmail(request.Email);

            if (employee == null || !_passwordHasher.Verify(request.Password, employee.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            if (!employee.IsActivated)
            {
                throw new Exceptions.AccountNotActivatedException("Employee has not activated the account.");
            }

            var token = _jwtTokenGenerator.GenerateToken(employee.Id, employee.Email, "Employee");

            return token;
        }
    }
}
