using Inventory.Module.Application.UseCases;
using Inventory.Module.Domain.Ports;
using Inventory.Module.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Module;

public static class InventoryModuleExtensions
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, InMemoryProductRepository>();
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<UpdateStockUseCase>();
        return services;
    }
}
