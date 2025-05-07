using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Auth.Queries.LoginCompany
{
    public class LoginCompanyQueryHandler : IRequestHandler<LoginCompanyQuery, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCompanyQueryHandler(ICompanyRepository companyRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _companyRepository = companyRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByEmailAsync(request.Email);

            if (company == null || !_passwordHasher.Verify(request.Password, company.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            if (!company.IsActivated)
            {
                throw new Exceptions.AccountNotActivatedException("Company has not activated the account.");
            }

            var token = _jwtTokenGenerator.GenerateToken(company.Id, company.Email);

            return token;
        }
    }
}
