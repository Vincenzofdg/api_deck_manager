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

// File + environment configuration
ConfigureConfiguration(builder);

// data base
ConfigureDatabase(builder);

// services and dependencies
ConfigureServices(builder);

// odata + controllers
ConfigureControllers(builder);

// swagger/openapi
ConfigureSwagger(builder);

// create the app
var app = builder.Build();

// middlewares + routes
ConfigureMiddleware(app);

// start
app.Run();


// helper methods
void ConfigureConfiguration(WebApplicationBuilder builder)
{
    builder.AddServiceDefaults();

    builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("Api/appsettings.json", optional: false, reloadOnChange: true);

    DotNetEnv.Env.Load();
}

void ConfigureDatabase(WebApplicationBuilder builder)
{
    string server = GetEnv("SERVER");
    string port = GetEnv("PORT");
    string database = GetEnv("DATABASE");
    string user = GetEnv("USER");
    string password = GetEnv("PASSWORD");

    string connectionString = $"server={server};port={port};database={database};user={user};password={password}";
    builder.Configuration["ConnectionStrings:DeckManagerConnection"] = connectionString;

    builder.Services.AddDbContext<ApiConfig>(options =>
    {
        options.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICollectionService, CollectionService>();
    builder.Services.AddScoped<ITypeSevice, TypeService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<ICardService, CardService>();
    
    
}

void ConfigureControllers(WebApplicationBuilder builder)
{
    // without odata
    //builder.Services.AddControllers();

    builder.Services.AddControllers()
        .AddOData(options =>
        {
            options.AddRouteComponents("odata", GetEdmModel());
            options
                .Select()
                .Filter()
                .Expand()
                .OrderBy()
                .Count()
                .SetMaxTop(100);
        });
}

void ConfigureSwagger(WebApplicationBuilder builder)
{
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
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "Deck Manager v1"
            );
        });
    }

    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

string GetEnv(string name) =>
    Environment.GetEnvironmentVariable(name) ?? throw new Exception($"Define '{name}' in .env file");

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CardEntity>("Cards");
    builder.EntitySet<CollectionEntity>("Collections");
    return builder.GetEdmModel();
}
