using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ApiController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new AppErrorResponse(code));
    }
} 