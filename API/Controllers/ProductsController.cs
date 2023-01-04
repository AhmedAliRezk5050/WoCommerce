using API.DTOs;
using API.Errors;
using API.Utility;
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
    public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductsSpecParams specParams)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(new ProductsWithTypesAndBrandsSpecification(specParams));
        var totalItems = await _unitOfWork.ProductRepository.CountAsync(new ProductsCountSpecification(specParams));
        var data = _mapper.Map<List<ProductDto>>(products);
        return Ok(new Pagination<ProductDto>
        {
            Count = totalItems,
            Data = data,
            PageIndex = specParams.PageIndex,
            PageSize = specParams.PageSize
        });
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