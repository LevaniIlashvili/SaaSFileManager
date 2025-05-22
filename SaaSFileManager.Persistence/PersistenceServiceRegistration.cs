using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Persistence.Repositories;

namespace SaaSFileManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SaaSFileManagerConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<ICompanySubscriptionRepository, CompanySubscriptionRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
