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

    public async Task<IActionResult> GetProductTypes()
    {
        var productTypes  = await _unitOfWork.ProductTypeRepository.GetAllAsync();
        return Ok(productTypes);
    }
}