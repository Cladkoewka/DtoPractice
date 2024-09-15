using DtoPractice.Application.DTOs;
using DtoPractice.Domain.Entities;
using Mapster;

namespace DtoPractice.Application.Services.Mapping;

public class ProductMapperMapster : IProductMapper
{
    static ProductMapperMapster()
    {
        MappingConfig.RegisterMappings();
    }
    public ProductGetDTO MapToGetDTO(Product product)
    {
        return product.Adapt<ProductGetDTO>();
    }

    public Product MapToEntity(ProductCreateDTO dto)
    {
        return dto.Adapt<Product>();
    }

    public Product MapToEntity(ProductUpdateDTO dto, int id)
    {
        var product = dto.Adapt<Product>();
        product.Id = id;
        return product;
    }
}