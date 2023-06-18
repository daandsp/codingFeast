using Application.Common.Interfaces;
using DinkToPdf.Contracts;
using DinkToPdf;
using Infrastructure.BloxLinkApi;
using Infrastructure.Components;
using Infrastructure.DepartmentDiscords;
using Infrastructure.Departments;
using Infrastructure.Identity;
using Infrastructure.LoggingEntries;
using Infrastructure.Persistence;
using Infrastructure.Reports;
using Infrastructure.RobloxApi;
using Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbcontextServices(configuration);
        services.AddScopedServices(configuration);
        services.AddSingletonServices(configuration);
        //services.AddIdentityServices(configuration);

        return services;
    }

    public static IServiceCollection AddApplicationDbcontextServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = configuration.GetValue<bool>("UseInMemoryDatabase")
            ? services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ISuiteDB"))
            : services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LoginConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                        .CommandTimeout(120)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        return services;
    }

    public static IServiceCollection AddScopedServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IDepartmentService, DepartmentsService>();
        services.AddScoped<IDepartmentGuildService, DepartmentDiscordsService>();
        services.AddScoped<IUserService, UsersService>();
        services.AddScoped<ILoggingEntriesService, LoggingEntriesService>();
        services.AddScoped<IBloxLinkApiService, BloxLinkService>();
        services.AddScoped<IRobloxUserApiService, RobloxUserService>();
        services.AddScoped<IComponentService, ComponentService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }

    public static IServiceCollection AddSingletonServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IEmbedCollection, EmbedsCollection.EmbedsCollection>();
        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        return services;
    }
}
