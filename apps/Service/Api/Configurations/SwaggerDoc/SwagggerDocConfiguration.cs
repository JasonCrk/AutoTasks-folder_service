using Microsoft.OpenApi.Models;

namespace Api.Configurations.SwaggerDoc
{
    public static class SwaggerDocConfiguration
    {
        public static IServiceCollection AddSwaggerDocConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AutoTasks - Folder service"
                });
                options.EnableAnnotations();
            });

            return services;
        }
    }
}