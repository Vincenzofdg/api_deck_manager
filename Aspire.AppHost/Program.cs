var builder = DistributedApplication.CreateBuilder(args);

//// MySQL Container
//var mysql = builder.AddMySql("mysql")
//    .WithEnvironment("MYSQL_ROOT_PASSWORD", "S3cur3P@ssword123!")
//    .WithEnvironment("MYSQL_DATABASE", "mysqldb")  // Nome do banco de dados
//    .WithLifetime(ContainerLifetime.Persistent);

//var mysqldb = mysql.AddDatabase("mysqldb");

// API Project
builder.AddProject<Projects.Api>("Backend");
    //.WithReference(mysqldb)
    //.WaitFor(mysqldb);

//// Adminer (interface web para MySQL)
//builder.AddContainer("adminer", "adminer")
//    .WithEnvironment("ADMINER_DEFAULT_SERVER", "mysql")
//    .WithEndpoint("adminer", e =>
//    {
//        e.Port = 8080; // Porta externa do container
//        e.TargetPort = 8080; // Porta dentro do container que o Adminer escuta
//    })
//    .WithReference(mysqldb)
//    .WaitFor(mysqldb);

builder.Build().Run();