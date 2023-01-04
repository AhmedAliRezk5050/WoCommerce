using API.DTOs;
using API.Errors;
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
    public async Task<ActionResult<List<ProductDto>>> GetProducts(string? sort, int? typeId, int? brandId)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(new ProductsWithTypesAndBrandsSpecification(sort, typeId, brandId));
        return Ok(_mapper.Map<List<ProductDto>>(products));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AppErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    { 
        var spec = new ProductWithTypesAndBrandsSpecification(id);
        var product = await _unitOfWork.ProductRepository.GetFirstOrDefaultAsync(spec);

        if (product is null)
        {
            return NotFound(new AppErrorResponse(404));
        }

        return Ok(_mapper.Map<ProductDto>(product));
    }
} 