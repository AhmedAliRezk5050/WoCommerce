namespace API.Errors;

public class AppErrorResponse
{
    public int StatusCode { get; }
    public string? Message { get; }

    public AppErrorResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultErrorMessage(StatusCode);
    }

    private static string? GetDefaultErrorMessage(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            404 => "Not Found",
            500 => "Internal server Error",
            _ => null
        };
    }
}