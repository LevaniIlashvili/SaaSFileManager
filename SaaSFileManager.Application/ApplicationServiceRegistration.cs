using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SaaSFileManager.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
