using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Models.Mail;
using SaaSFileManager.Application.Options;
using SaaSFileManager.Infrastructure.Mail;
using SaaSFileManager.Infrastructure.Security;

namespace SaaSFileManager.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            return services;
        }
    }
}
