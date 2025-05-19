using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace Blog.API.Middleware;

public class ApplicationExceptionHandler(ILogger<ApplicationExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "{Message}", exception.Message);

        switch (exception)
        {
            case ValidationException validationException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsJsonAsync(validationException.Errors, cancellationToken).ConfigureAwait(false);
                break;

            default:
                await httpContext.Response.WriteAsJsonAsync("Internal Server Error", cancellationToken).ConfigureAwait(false);
                break;
        }

        return true;
    }
}

