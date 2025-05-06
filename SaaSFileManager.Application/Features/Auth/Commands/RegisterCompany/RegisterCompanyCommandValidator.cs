using FluentValidation;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Auth.Commands.CreateCompany
{
    public class RegisterCompanyCommandValidator : AbstractValidator<RegisterCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public RegisterCompanyCommandValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("Invalid email format")
                .MustAsync(CompanyEmailUnique).WithMessage("Company with this email already exists");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");

            RuleFor(p => p.Country)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Industry)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> CompanyEmailUnique(string email, CancellationToken token)
        {
            return await _companyRepository.IsCompanyEmailUnique(email);
        }
    }
}
