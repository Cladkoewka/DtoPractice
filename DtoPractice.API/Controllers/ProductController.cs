using DtoPractice.Application.DTOs;
using DtoPractice.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DtoPractice.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductGetDTO>> GetProduct(int id)
    {
        var productDTO = await _productService.GetProductByIdAsync(id);
        if (productDTO == null)
        {
            return NotFound();
        }

        return Ok(productDTO);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductGetDTO>>> GetProducts()
    {
        var productDTOs = await _productService.GetAllProductsAsync();
        return Ok(productDTOs);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
    {
        var createdProductDTO = await _productService.CreateProductAsync(productCreateDTO);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        return CreatedAtAction(nameof(GetProduct), new { id = createdProductDTO.Id }, createdProductDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDTO productUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _productService.UpdateProductAsync(id, productUpdateDTO);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
