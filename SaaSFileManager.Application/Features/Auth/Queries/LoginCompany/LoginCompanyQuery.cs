using MediatR;

namespace SaaSFileManager.Application.Features.Auth.Queries.LoginCompany
{
    public class LoginCompanyQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
