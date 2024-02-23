using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using testeSmark.WebApi.Extensions;
using testeSmark.WebApi.Middlewares.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();

// Adiciona referência de interface para classe
builder.Services.AddCustomServices();

// Adiociona versionamento para a api
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddMvc(options => options.EnableEndpointRouting = false).AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Saiba mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configura o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();

app.UseRouting(); // Adiciona o middleware de roteamento aqui

// Configure o Middleware de Exceções
app.UseCustomExceptionHandler();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();