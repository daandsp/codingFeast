using Bloxmod.Data.Context;
using Bloxmod.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bloxmod.Data
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBloxmodDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplicationDbServices(configuration);
            services.AddScopedServices(configuration);

            return services;
        }

        public static IServiceCollection AddApplicationDbServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextFactory<BloxmodDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IBloxmodDbContext>(provider => provider.GetRequiredService<BloxmodDbContext>());

            services.AddScoped<BloxmodDbContextInitializer>();

            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<DataAccessLayer>();

            return services;
        }
    }
}
