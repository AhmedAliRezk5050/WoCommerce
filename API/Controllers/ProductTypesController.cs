using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductTypesController : ApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductTypesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductType>>> GetProductTypes()
    {
        var productTypes  = await _unitOfWork.ProductTypeRepository.GetAllAsync();
        return Ok(productTypes);
    } 
}