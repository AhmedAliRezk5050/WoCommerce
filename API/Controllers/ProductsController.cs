using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _unitOfWork.ProductRepository.GetFirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    } 
}