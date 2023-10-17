using System.Net;
using System.Text.Json;

namespace CRUD_WebApi_Net6.Helpers;

public class MiddlewareErrorHandler
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _errorHandler;

    public MiddlewareErrorHandler(ILogger<MiddlewareErrorHandler> logger, RequestDelegate errorHandler)
    {
        _logger = logger;
        _errorHandler = errorHandler;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _errorHandler(context);
        }
        catch (Exception error)
        {
            var resp = context.Response;
            resp.ContentType = "application/json";

            switch (error)
            {
                case AppException e:
                    resp.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    resp.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    _logger.LogError(error, error.Message);
                    resp.StatusCode = (int)(HttpStatusCode.InternalServerError);
                    break;
            }

            var outResult = JsonSerializer.Serialize(new { Message = error?.Message });
            await resp.WriteAsync(outResult);
        }
    }
}