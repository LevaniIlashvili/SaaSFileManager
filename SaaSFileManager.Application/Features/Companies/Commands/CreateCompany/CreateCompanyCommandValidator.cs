using FluentValidation;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandValidator(ICompanyRepository companyRepository)
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

            RuleFor(p => p.Password)
                .MinimumLength(8);

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
