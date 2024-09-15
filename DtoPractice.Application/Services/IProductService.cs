using DtoPractice.Application.DTOs;

namespace DtoPractice.Application.Services;

public interface IProductService
{
    Task<ProductGetDTO?> GetProductByIdAsync(int id);
    Task<List<ProductGetDTO>> GetAllProductsAsync();
    Task<ProductGetDTO> CreateProductAsync(ProductCreateDTO productCreateDTO);
    Task<bool> UpdateProductAsync(int id, ProductUpdateDTO productUpdateDTO);
    Task<bool> DeleteProductAsync(int id);
}