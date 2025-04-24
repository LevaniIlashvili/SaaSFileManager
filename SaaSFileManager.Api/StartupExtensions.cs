using SaaSFileManager.Api.Middleware;
using SaaSFileManager.Application;
using SaaSFileManager.Infrastructure;
using SaaSFileManager.Persistence;

namespace SaaSFileManager.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCustomExceptionHandler();

            app.MapControllers();

            return app;
        }
    }
}
