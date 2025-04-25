using MediatR;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Commands.ActivateCompany
{
    public class ActivateCompanyHandler : IRequestHandler<ActivateCompanyCommand, bool>
    {
        private readonly ICompanyRepository _companyRepository;

        public ActivateCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(ActivateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByActivationToken(request.Token);

            if (company == null)
            {
                return false;
            }

            company.IsActivated = true;
            company.ActivationToken = null;

            await _companyRepository.UpdateAsync(company);

            return true;
        }
    }
}
