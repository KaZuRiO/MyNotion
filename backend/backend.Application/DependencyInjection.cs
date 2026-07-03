using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using backend.Application.UseCases;
using backend.Domain.Repositories;
namespace backend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here
        services.AddScoped<UserUseCase>();
        services.AddScoped<WorkspaceUseCase>();
        services.AddScoped<WorkspaceUserUseCase>();
        services.AddScoped<PageUseCase>();
        services.AddScoped<BlockUseCase>();
        services.AddScoped<RoleUseCase>();
        services.AddScoped<AuthUseCase>();

        return services;
    }
}
