using API.DTOs;
using AutoMapper;
using Core.Interfaces.Repository;
using Infrastructure.Specifications.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : ApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(new ProductsWithTypesAndBrandsSpecification());
        return Ok(_mapper.Map<List<ProductDto>>(products));
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var spec = new ProductWithTypesAndBrandsSpecification(id);
        var product = await _unitOfWork.ProductRepository.GetFirstOrDefaultAsync(spec);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ProductDto>(product));
    }

   
}