namespace Inventory.Module.Application.DTOs;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity
);

public record UpdateStockDto(
    Guid ProductId,
    int Quantity
);

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity
);
