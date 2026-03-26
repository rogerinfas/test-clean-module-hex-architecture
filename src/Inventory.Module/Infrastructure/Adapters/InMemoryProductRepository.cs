using Inventory.Module.Domain.Entities;
using Inventory.Module.Domain.Ports;

namespace Inventory.Module.Infrastructure.Adapters;

public class InMemoryProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products.ToList());
    }

    public Task<Product> AddAsync(Product product)
    {
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index >= 0) _products[index] = product;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null) _products.Remove(product);
        return Task.CompletedTask;
    }
}
