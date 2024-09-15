using DtoPractice.Application.DTOs;
using DtoPractice.Domain.Entities;
using Mapster;

namespace DtoPractice.Application.Services.Mapping;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Product, ProductGetDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price);
        
        TypeAdapterConfig<ProductCreateDTO, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price);
        
        TypeAdapterConfig<ProductUpdateDTO, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price);
    }
}