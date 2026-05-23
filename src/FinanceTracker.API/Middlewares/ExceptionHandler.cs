using FinanceTracker.Domain;
using System.Text.Json;

namespace FinanceTracker.API.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(DomainException ex)
            {
                await SendError(ex.Message, 400, context);
            }
            catch (NotFoundException ex)
            {
                await SendError(ex.Message, 404, context);
            }
            catch (Exception)
            {
                await SendError("An unexpected error occurred", 500, context);
            }
        }

        private async Task SendError(string message, int statusCode, HttpContext context)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var response = new { error = message, statusCode = statusCode };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
