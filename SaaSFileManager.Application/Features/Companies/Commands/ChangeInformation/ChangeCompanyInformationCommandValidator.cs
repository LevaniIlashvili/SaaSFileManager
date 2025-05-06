using FluentValidation;

namespace SaaSFileManager.Application.Features.Companies.Commands.ChangeInformation
{
    public class ChangeCompanyInformationCommandValidator : AbstractValidator<ChangeCompanyInformationCommand>
    {
        public ChangeCompanyInformationCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .When(x => x.Name != null);

            RuleFor(x => x.Country)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .When(x => x.Country != null);

            RuleFor(x => x.Industry)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .When(x => x.Industry != null);
        }
    }
}
