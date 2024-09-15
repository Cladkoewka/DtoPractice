using AutoMapper;
using DtoPractice.Application.DTOs;
using DtoPractice.Domain.Entities;

namespace DtoPractice.Application.Services.Mapping.AutoMapper;

public class ProductMapperAutoMapper : IProductMapper
{
    private readonly IMapper _mapper;

    public ProductMapperAutoMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
    public ProductGetDTO MapToGetDTO(Product product)
    {
        return _mapper.Map<ProductGetDTO>(product);
    }

    public Product MapToEntity(ProductCreateDTO dto)
    {
        return _mapper.Map<Product>(dto);
    }

    public Product MapToEntity(ProductUpdateDTO dto, int id)
    {
        var product = _mapper.Map<Product>(dto);
        product.Id = id;
        return product;
    }
}