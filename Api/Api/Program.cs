using Api.Infrastructure;
using Api.Infrastructure.Services;
using Api.Shared.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Api/appsettings.json", optional: false, reloadOnChange: true);

// https://learn.microsoft.com/pt-br/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
// Loads .env file
DotNetEnv.Env.Load();

string server = Environment.GetEnvironmentVariable("SERVER") ?? throw new Exception("Define 'SERVER' at .env file");
string port = Environment.GetEnvironmentVariable("PORT") ?? throw new Exception("Define 'PORT' at .env file");
string database = Environment.GetEnvironmentVariable("DATABASE") ?? throw new Exception("Define 'DATABASE' at .env file");
string user = Environment.GetEnvironmentVariable("USER") ?? throw new Exception("Define 'USER' at .env file");
string password = Environment.GetEnvironmentVariable("PASSWORD") ?? throw new Exception("Define 'PASSWORD' at .env file");

string connectionString = $"server={server};port={port};database={database};user={user};password={password}";
builder.Configuration["ConnectionStrings:DeckManagerConnection"] = connectionString;

builder.Services.AddDbContext<ApiConfig>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add services to Scope
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Deck Manager API",
            Description = "Organize and build your Deck",
            Version = "v1"
        });
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deck Manager v1");
    });
}

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
