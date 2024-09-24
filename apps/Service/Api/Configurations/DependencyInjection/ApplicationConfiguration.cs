using Application.Commands.Create;
using Application.Commands.Delete;

namespace Api.Configurations.DependencyInjection
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config
                .RegisterServicesFromAssembly(typeof(CreateFolderCommandHandler).Assembly)
                .RegisterServicesFromAssembly(typeof(DeleteFolderCommandHandler).Assembly)
            );

            return services;
        }
    }
}