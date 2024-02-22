namespace testeSmark.WebApi.Interfaces.Middlewares
{
    public interface ICustomExceptionHandlerMiddleware
    {
        Task Invoke(HttpContext context);
    }
}
