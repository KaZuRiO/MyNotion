using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;
using backend.Domain.Repositories;
using backend.Infrastructure.Repositories;

namespace backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

        // ✅ REPOSITORIES REGISTRATION (THIS IS THE MISSING PART)
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
        services.AddScoped<IWorkspaceUserRepository, WorkspaceUserRepository>();
        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        return services;
    }
}