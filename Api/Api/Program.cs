using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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

// var connectionString = builder.Configuration.GetConnectionString("DeckManagerConnection");
string connectionString = $"server={server};port={port};database={database};user={user};password={password}";
builder.Configuration["ConnectionStrings:DeckManagerConnection"] = connectionString;

builder.Services.AddDbContext<ApiConfig>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        { 
            Title = "Deck Manager API",
            Description = "Organize and build your Deck",
            Version = "v1" });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    ////if (File.Exists(xmlFile))
    ////{
    ////    c.IncludeXmlComments(xmlFile);
    ////}
    //c.IncludeXmlComments(xmlFile);

    var xmlPath = Path.Combine(AppContext.BaseDirectory, "api_deck_manager.xml");
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

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
