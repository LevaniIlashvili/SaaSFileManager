using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.ActivateCompany
{
    public class ActivateCompanyCommand : IRequest<bool>
    {
        public string Token { get; set; }
    }
}
