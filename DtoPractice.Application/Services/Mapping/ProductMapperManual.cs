using DtoPractice.Application.DTOs;
using DtoPractice.Domain.Entities;

namespace DtoPractice.Application.Services.Mapping;

public class ProductMapperManual : IProductMapper
{
    public ProductGetDTO MapToGetDTO(Product product)
    {
        return new ProductGetDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public Product MapToEntity(ProductCreateDTO dto)
    {
        return new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
        };
    }

    public Product MapToEntity(ProductUpdateDTO dto, int id)
    {
        return new Product
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
        };
    }
}