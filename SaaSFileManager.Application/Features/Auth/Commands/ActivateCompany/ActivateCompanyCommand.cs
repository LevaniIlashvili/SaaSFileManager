using MediatR;

namespace SaaSFileManager.Application.Features.Auth.Commands.ActivateCompany
{
    public class ActivateCompanyCommand : IRequest<bool>
    {
        public string Token { get; set; }
    }
}
