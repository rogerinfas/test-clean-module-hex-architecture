using Auth.Module.Application.UseCases;
using Auth.Module.Domain.Ports;
using Auth.Module.Infrastructure.Adapters;
using Auth.Module.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Module;

public static class AuthModuleExtensions
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasherAdapter>();
        services.AddScoped<RegisterUserUseCase>();
        services.AddScoped<LoginUseCase>();
        return services;
    }
}
