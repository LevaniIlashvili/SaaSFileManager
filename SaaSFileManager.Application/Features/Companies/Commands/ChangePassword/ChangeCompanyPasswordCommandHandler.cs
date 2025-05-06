using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Commands.ChangePassword
{
    public class ChangeCompanyPasswordCommandHandler : IRequestHandler<ChangeCompanyPasswordCommand>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ICompanyRepository _companyRepository;

        public ChangeCompanyPasswordCommandHandler(ILoggedInUserService loggedInUserService, ICompanyRepository companyRepository)
        {
            _loggedInUserService = loggedInUserService;
            _companyRepository = companyRepository;
        }

        public async Task Handle(ChangeCompanyPasswordCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(Guid.Parse(_loggedInUserService.UserId));

            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, company.PasswordHash))
                throw new UnauthorizedAccessException("Current password is incorrect");

            var validator = new ChangeCompanyPasswordCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
                throw new Exceptions.ValidationException(result);

            if (request.CurrentPassword == request.NewPassword)
                throw new Exceptions.BadRequestException("New password cannot be same as current password");

            company.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            await _companyRepository.UpdateAsync(company);
        }
    }
}
    