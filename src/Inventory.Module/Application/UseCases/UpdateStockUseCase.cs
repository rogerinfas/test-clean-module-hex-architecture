using Inventory.Module.Application.DTOs;
using Inventory.Module.Domain.Ports;

namespace Inventory.Module.Application.UseCases;

public class UpdateStockUseCase
{
    private readonly IProductRepository _productRepository;

    public UpdateStockUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> ExecuteAsync(UpdateStockDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.ProductId)
            ?? throw new InvalidOperationException("Product not found");

        product.UpdateStock(dto.Quantity);
        await _productRepository.UpdateAsync(product);

        return new ProductDto(product.Id, product.Name, product.Description, product.Price, product.StockQuantity);
    }
}
