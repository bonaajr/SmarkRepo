using System.Net;
using testeSmark.WebApi.Interfaces.Middlewares;

namespace testeSmark.WebApi.Middlewares
{
    public class CustomExceptionHandlerMiddleware : ICustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao processar a solicitação: {ex}");

                var traceId = Guid.NewGuid().ToString();
                var statusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync($"{{ \"traceId\": \"{traceId}\", \"statusCode\": {statusCode} }}");
            }
        }
    }
}
