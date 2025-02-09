using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SocialMedia.Domain.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex) 
        {
            _logger.LogWarning($"[Business Exception] {ex.Message}");
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "[Unexpected Exception] An unexpected error occurred.");
            await HandleExceptionAsync(context, new Exception("An unexpected error occurred. Please try again later."), HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        var response = new { message = exception.Message, errors = new Dictionary<string, string[]>() };
        var payload = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(payload);
    }
}
