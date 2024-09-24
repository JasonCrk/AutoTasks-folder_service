using Infrastructure.Adapters.Repositories;
using Domain.Ports.Repositories;

using Shared.Domain;
using Shared.Infrastructure;

namespace Api.Configurations.DependencyInjection
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UuidGenerator, CsharpUuidGenerator>();

            services.AddScoped<FolderRepository>(
                provider => new FolderRepositoryAdapter(configuration.GetConnectionString("DbConnection")!)
            );

            return services;
        }

    }
}