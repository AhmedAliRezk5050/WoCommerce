using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductBrandsController : ApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductBrandsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
    {
        var productBrands  = await _unitOfWork.ProductBrandRepository.GetAllAsync();
        return Ok(productBrands);
    }
}