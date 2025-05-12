var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("Backend");

builder.AddProject<Projects.Website>("Website")
    .WithReference(api);

builder.Build().Run();
