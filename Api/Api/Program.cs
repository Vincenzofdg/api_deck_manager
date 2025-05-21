using Api.Infrastructure;
using Api.Infrastructure.Entities;
using Api.Infrastructure.Services;
using Api.Shared.Interfaces.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração de arquivos e ambiente
builder.AddServiceDefaults();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Api/appsettings.json", optional: false, reloadOnChange: true);

// Carregar variáveis de ambiente do .env
DotNetEnv.Env.Load();

string server = Environment.GetEnvironmentVariable("SERVER") ?? throw new Exception("Define 'SERVER' in .env file");
string port = Environment.GetEnvironmentVariable("PORT") ?? throw new Exception("Define 'PORT' in .env file");
string database = Environment.GetEnvironmentVariable("DATABASE") ?? throw new Exception("Define 'DATABASE' in .env file");
string user = Environment.GetEnvironmentVariable("USER") ?? throw new Exception("Define 'USER' in .env file");
string password = Environment.GetEnvironmentVariable("PASSWORD") ?? throw new Exception("Define 'PASSWORD' in .env file");

string connectionString = $"server={server};port={port};database={database};user={user};password={password}";
builder.Configuration["ConnectionStrings:DeckManagerConnection"] = connectionString;

// Banco de dados
builder.Services.AddDbContext<ApiConfig>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Injeção de dependência
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ITypeSevice, TypeService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Deck Manager API",
        Description = "Organize and build your Deck",
        Version = "v1"
    });
});
builder.Services.AddOpenApi();

// OData + Controllers
builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select().Filter().Expand().OrderBy().Count().SetMaxTop(100);
        options.AddRouteComponents("odata", GetEdmModel());
    });

// Modelo OData
IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CardEntity>("Cards");
    builder.EntitySet<CollectionEntity>("Collections");
    return builder.GetEdmModel();
}

// Criar o app
var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deck Manager v1");
    });
}

// Middlewares essenciais
app.UseRouting();
app.UseAuthorization();

// Rotas
app.MapControllers();

// Redirecionar / para Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Start
app.Run();
