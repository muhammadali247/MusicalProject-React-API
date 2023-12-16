using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Exceptions;
using MusicApp.WebApi.Models;
using System.Net;
using System.Text.Json;

namespace MusicApp.WebApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        object problemDetails = null;

        switch (ex)
        {
            case NotFoundException notFoundEx:
                statusCode = HttpStatusCode.NotFound;
                problemDetails = new ProblemDetails
                {
                    Status = (int)statusCode,
                    Title = notFoundEx.Message,
                    Detail = notFoundEx.InnerException?.Message,
                    Type = nameof(NotFoundException)
                };
                break;

            case BadRequestException badRequestEx:
                statusCode = HttpStatusCode.BadRequest;
                problemDetails = new CustomValidationProblemDetails
                {
                    Status = (int)statusCode,
                    Title = badRequestEx.Message,
                    Detail = badRequestEx.InnerException?.Message,
                    Type = nameof(BadRequestException),
                    Errors = new Dictionary<string, string[]> { { "ValidationErrors", badRequestEx.Errors } }
                };
                break;

            case ValidationException validationEx:
                statusCode = HttpStatusCode.BadRequest;
                problemDetails = new CustomValidationProblemDetails
                {
                    Status = (int)statusCode,
                    Title = "Validation error",
                    Errors = validationEx.Errors,
                    Type = nameof(ValidationException)  
                };
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                problemDetails = new ProblemDetails
                {
                    Status = (int)statusCode,
                    Title = ex.Message,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.InnerException?.Message
                };
                break;
        }

          if (problemDetails != null)
            {
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }

    }

}