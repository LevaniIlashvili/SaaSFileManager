using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Commands.ChangeInformation
{
    public class ChangeCompanyInformationCommandHandler : IRequestHandler<ChangeCompanyInformationCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public ChangeCompanyInformationCommandHandler(ICompanyRepository companyRepository, ILoggedInUserService loggedInUserService)
        {
            _companyRepository = companyRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task Handle(ChangeCompanyInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeCompanyInformationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var company = await _companyRepository.GetByIdAsync(Guid.Parse(_loggedInUserService.UserId));
        
            if (request.Name != null)
            {
                company.Name = request.Name;
            }

            if (request.Country != null)
            {
                company.Country = request.Country;
            }

            if (request.Industry != null)
            {
                company.Industry = request.Industry;
            }

            await _companyRepository.UpdateAsync(company);
        }
    }
}
