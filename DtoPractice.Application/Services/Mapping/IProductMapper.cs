using DtoPractice.Application.DTOs;
using DtoPractice.Domain.Entities;

namespace DtoPractice.Application.Services.Mapping;

public interface IProductMapper
{
    ProductGetDTO MapToGetDTO(Product product);
    Product MapToEntity(ProductCreateDTO dto);
    Product MapToEntity(ProductUpdateDTO dto, int id);
}