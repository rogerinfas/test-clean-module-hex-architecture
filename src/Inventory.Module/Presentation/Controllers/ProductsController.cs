using Inventory.Module.Application.DTOs;
using Inventory.Module.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Module.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductUseCase _createProductUseCase;
    private readonly UpdateStockUseCase _updateStockUseCase;

    public ProductsController(CreateProductUseCase createProductUseCase, UpdateStockUseCase updateStockUseCase)
    {
        _createProductUseCase = createProductUseCase;
        _updateStockUseCase = updateStockUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
    {
        var result = await _createProductUseCase.ExecuteAsync(dto);
        return CreatedAtAction(nameof(Create), result);
    }

    [HttpPut("stock")]
    public async Task<ActionResult<ProductDto>> UpdateStock([FromBody] UpdateStockDto dto)
    {
        var result = await _updateStockUseCase.ExecuteAsync(dto);
        return Ok(result);
    }
}
