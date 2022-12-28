using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductTypesController : BaseController
{
    public ProductTypesController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IActionResult> GetProductTypes()
    {
        var productTypes  = await UnitOfWork.ProductTypeRepository.GetAllAsync();
        return Ok(productTypes);
    }
}