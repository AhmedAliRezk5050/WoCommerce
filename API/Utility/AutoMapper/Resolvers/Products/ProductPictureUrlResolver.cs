using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Utility.AutoMapper.Resolvers.Products;

public class PictureUrlResolver : IValueResolver<Product, ProductDto, string?>
{
    private readonly IConfiguration _config;

    public PictureUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string? Resolve(Product source, ProductDto destination, string? destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config[Constants.ApiUrl] + source.PictureUrl;
        } 

        return null;
    }
}