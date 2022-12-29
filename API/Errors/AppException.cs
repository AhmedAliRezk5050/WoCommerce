namespace API.Errors;

public class AppException : AppErrorResponse
{
    public string? Details { get; set; }
    
    public AppException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
    {
        Details = details;
    }
    
    
}