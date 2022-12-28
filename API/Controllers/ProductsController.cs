using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseController
{
    public ProductsController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await UnitOfWork.ProductRepository.GetAllAsync(includedProperties: new List<string>() {"ProductType", "ProductBrand"});
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await UnitOfWork.ProductRepository.GetFirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }

   
}