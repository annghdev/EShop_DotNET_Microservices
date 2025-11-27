var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var authService = builder.AddProject<Projects.AuthService>("authservice")
    .WithHttpHealthCheck("/health");

var catalogService = builder.AddProject<Projects.CatalogService>("catalogservice")
    .WithHttpHealthCheck("/health");

var cartService = builder.AddProject<Projects.CartService>("cartservice")
    .WithHttpHealthCheck("/health");

var inventoryService = builder.AddProject<Projects.InventoryService>("inventoryservice")
    .WithHttpHealthCheck("/health");

var orderService = builder.AddProject<Projects.OrderService>("orderservice")
    .WithHttpHealthCheck("/health");

var paymentService = builder.AddProject<Projects.PaymentService>("paymentservice")
    .WithHttpHealthCheck("/health");

var shippingService = builder.AddProject<Projects.ShippingService>("shippingservice")
    .WithHttpHealthCheck("/health");

var pricingService = builder.AddProject<Projects.PricingService>("pricingservice")
    .WithHttpHealthCheck("/health");

var notificationService = builder.AddProject<Projects.NotificationService>("notificationservice")
    .WithHttpHealthCheck("/health");

var fileService = builder.AddProject<Projects.FileService>("fileservice")
    .WithHttpHealthCheck("/health");

var reportService = builder.AddProject<Projects.ReportService>("reportservice")
    .WithHttpHealthCheck("/health");

var apiGateway = builder.AddProject<Projects.ApiGateway>("apigateway")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiGateway)
    .WaitFor(apiGateway);


builder.Build().Run();
