using Inventory.Module.Application.UseCases;
using Inventory.Module.Domain.Ports;
using Inventory.Module.Infrastructure.Adapters;
using Inventory.Module.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Module;

public static class InventoryModuleExtensions
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<InventoryDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<UpdateStockUseCase>();
        return services;
    }
}
