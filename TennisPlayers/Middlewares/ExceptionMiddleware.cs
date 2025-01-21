using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace TennisPlayers.Middlewares;

public sealed class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(new EventId(ex.HResult), ex, ex.Message);
            var problemDetails = ex switch
            {
                ValidationException ve => new ProblemDetails { Detail = string.Join(' ', ve.Errors.Select(x => x.ErrorMessage)), Status = StatusCodes.Status400BadRequest },
                _ => new ProblemDetails { Detail = "An error has occured", Status = StatusCodes.Status500InternalServerError }
            };
            context.Response.StatusCode = problemDetails.Status!.Value;
            await context.Response.WriteAsJsonAsync(problemDetails.Detail);
        }
    }
}