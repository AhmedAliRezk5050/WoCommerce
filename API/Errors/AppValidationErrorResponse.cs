namespace API.Errors;

public class AppValidationErrorResponse : AppErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = null!;
    
    public AppValidationErrorResponse() : base(400)
    {
    }
}