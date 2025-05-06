using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.ChangeInformation
{
    public class ChangeCompanyInformationCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Industry { get; set; }
    }
}
