using Inventory.Module.Application.DTOs;
using Inventory.Module.Domain.Entities;
using Inventory.Module.Domain.Ports;

namespace Inventory.Module.Application.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> ExecuteAsync(CreateProductDto dto)
    {
        var product = new Product(dto.Name, dto.Description, dto.Price, dto.StockQuantity);
        await _productRepository.AddAsync(product);
        return ToDto(product);
    }

    private static ProductDto ToDto(Product product) => new(
        product.Id,
        product.Name,
        product.Description,
        product.Price,
        product.StockQuantity
    );
}
