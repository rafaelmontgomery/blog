using System.Text.Json;
using Blog.API.Common;
using Blog.Application.Exceptions;
using FluentValidation;

namespace Blog.API.Middleware;

public class ValidationExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (BlogApplicationException ex)
        {
            await HandleBlogApplicationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleDefaultExceptionAsync(context, ex);
        }
    }

    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        return context.Response.WriteAsync(JsonSerializer.Serialize(exception.Errors));
    }

    private static Task HandleBlogApplicationExceptionAsync(HttpContext context, BlogApplicationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        var response = new ApiResponse() { Message = exception.Message };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleDefaultExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var response = new ApiResponse() { Message = exception.Message };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}