using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repository;
using Infrastructure.Specifications.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseController
{
    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await UnitOfWork.ProductRepository.GetAllAsync(new ProductsWithTypesAndBrandsSpecification());
        return Ok(Mapper.Map<List<ProductDto>>(products));
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var spec = new ProductWithTypesAndBrandsSpecification(id);
        var product = await UnitOfWork.ProductRepository.GetFirstOrDefaultAsync(spec);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(Mapper.Map<ProductDto>(product));
    }

   
}