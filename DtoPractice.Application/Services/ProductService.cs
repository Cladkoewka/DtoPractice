using DtoPractice.Application.DTOs;
using DtoPractice.Application.Services.Mapping;
using DtoPractice.Infrastructure.Repositories;

namespace DtoPractice.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductMapper _productMapper;

    public ProductService(IProductRepository productRepository, IProductMapper productMapper)
    {
        _productRepository = productRepository;
        _productMapper = productMapper;
    }

    public async Task<ProductGetDTO?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        
        if (product == null)
            return null;

        return _productMapper.MapToGetDTO(product);
    }

    public async Task<List<ProductGetDTO>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(_productMapper.MapToGetDTO).ToList();
    }

    public async Task<ProductGetDTO> CreateProductAsync(ProductCreateDTO productCreateDTO)
    {
        var product = _productMapper.MapToEntity(productCreateDTO);
        await _productRepository.AddAsync(product);
        return _productMapper.MapToGetDTO(product);
    }

    public async Task<bool> UpdateProductAsync(int id, ProductUpdateDTO productUpdateDTO)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = productUpdateDTO.Name;
        existingProduct.Description = productUpdateDTO.Description;
        existingProduct.Price = productUpdateDTO.Price;
        
        await _productRepository.UpdateAsync(existingProduct);
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(existingProduct);
        return true;
    }
}