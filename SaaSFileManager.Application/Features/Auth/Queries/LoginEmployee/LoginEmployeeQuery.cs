using MediatR;

namespace SaaSFileManager.Application.Features.Auth.Queries.LoginEmployee
{
    public class LoginEmployeeQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
