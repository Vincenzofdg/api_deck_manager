var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Api>("Backend");

builder.AddProject<Projects.Website>("Website");

builder.Build().Run();
