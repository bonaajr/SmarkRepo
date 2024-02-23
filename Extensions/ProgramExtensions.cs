using testeSmark.WebApi.Interfaces.Applications;
using testeSmark.WebApi.Services.Applications;

namespace testeSmark.WebApi.Extensions
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IProtocoloApp, ProtocoloApp>();
            services.AddScoped<IValidacaoApp, ValidacaoApp>();

            return services;
        }
    }
}
