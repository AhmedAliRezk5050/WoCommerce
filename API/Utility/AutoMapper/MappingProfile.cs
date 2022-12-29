using API.DTOs;
using API.Utility.AutoMapper.Resolvers.Products;
using AutoMapper;
using Core.Entities;

namespace API.Utility.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.ProductBrand,
                opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(p => p.ProductType,
            opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(p => p.PictureUrl,
            opt => opt.MapFrom<PictureUrlResolver>());
    }
}