using Microsoft.AspNetCore.Http;
using SaaSFileManager.Application.Contracts.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SaaSFileManager.Infrastructure.Security
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("User is not authenticated");
                }

                return userId;
            }
        }
    }
}