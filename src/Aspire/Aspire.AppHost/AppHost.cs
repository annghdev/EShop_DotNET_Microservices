var builder = DistributedApplication.CreateBuilder(args);
builder.AddDockerComposeEnvironment("compose");
//var cache = builder.AddRedis("cache");

//var authService = builder.AddProject<Projects.AuthService>("authservice")
//    .WithHttpHealthCheck("/health");

//var catalogService = builder.AddProject<Projects.CatalogService>("catalogservice")
//    .WithHttpHealthCheck("/health");

//var orderService = builder.AddProject<Projects.OrderService>("orderservice")
//    .WithHttpHealthCheck("/health");

//builder.AddProject<Projects.InventoryService>("inventoryservice");

var bff = builder.AddProject<Projects.BFF>("bff")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");
    //.WithReference(cache)
    //.WithReference(authService)
    //.WithReference(catalogService)
    //.WithReference(orderService)
    //.WaitFor(catalogService)
    //.WaitFor(authService);

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(bff)
    .WaitFor(bff);


builder.Build().Run();
