using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductBrandsController : BaseController
{
    public ProductBrandsController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IActionResult> GetProductBrands()
    {
        var productBrands  = await UnitOfWork.ProductBrandRepository.GetAllAsync();
        return Ok(productBrands);
    }
}