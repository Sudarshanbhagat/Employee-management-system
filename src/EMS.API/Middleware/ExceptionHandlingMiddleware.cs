using System.Net;
using System.Text.Json;
using EMS.Common.Exceptions;

namespace EMS.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new { message = "", statusCode = 500 };

            switch (exception)
            {
                case UnauthorizedException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    response = new { message = exception.Message, statusCode = 401 };
                    break;
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response = new { message = exception.Message, statusCode = 404 };
                    break;
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    response = new { message = exception.Message, statusCode = 400 };
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response = new { message = "An internal server error occurred", statusCode = 500 };
                    break;
            }

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
