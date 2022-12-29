﻿using API.DTOs;
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
            opt => opt.MapFrom(src => src.ProductType.Name));
    }
}