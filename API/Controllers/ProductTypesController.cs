using AutoMapper;
using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductTypesController : BaseController
{
    public ProductTypesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IActionResult> GetProductTypes()
    {
        var productTypes  = await UnitOfWork.ProductTypeRepository.GetAllAsync();
        return Ok(productTypes);
    }
}