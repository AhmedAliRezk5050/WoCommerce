using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly IUnitOfWork UnitOfWork;
    
    protected BaseController(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}