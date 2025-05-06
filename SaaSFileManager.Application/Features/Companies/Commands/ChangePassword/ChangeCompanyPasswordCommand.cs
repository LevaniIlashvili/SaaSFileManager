using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.ChangePassword
{
    public class ChangeCompanyPasswordCommand : IRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
