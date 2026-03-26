using Auth.Module.Application.UseCases;
using Auth.Module.Domain.Ports;
using Auth.Module.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Module;

public static class AuthModuleExtensions
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasherAdapter>();
        services.AddScoped<RegisterUserUseCase>();
        services.AddScoped<LoginUseCase>();
        return services;
    }
}
