var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Api>("API");

builder.Build().Run();
