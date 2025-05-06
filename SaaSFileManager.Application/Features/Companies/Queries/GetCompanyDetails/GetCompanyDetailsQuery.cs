using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQuery : IRequest<CompanyDetailsVm>
    {
        public string Id { get; set; }
    }
}
