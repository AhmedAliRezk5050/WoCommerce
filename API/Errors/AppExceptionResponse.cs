namespace API.Errors;

public class AppExceptionResponse : AppErrorResponse
{
    public string? Details { get; set; }
    
    public AppExceptionResponse(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
    {
        Details = details;
    }
    
    
}