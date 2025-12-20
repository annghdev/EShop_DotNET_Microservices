using BFF.Models;

namespace BFF.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async (HttpContext httpContext) =>
        {
            // Placeholder for fetching products logic
            var products = new[]
            {
                new { Id = Guid.NewGuid(), Name = "Product 1", Price = 19.99m },
                new { Id = Guid.NewGuid(), Name = "Product 2", Price = 29.99m }
            };
            await httpContext.Response.WriteAsJsonAsync(products);
        })
        .WithName("GetProducts")
        .WithTags("Products");

        app.MapGet("/api/products/{id:Guid}", async (HttpContext httpContext, Guid id) =>
        {
            // Placeholder for fetching a single product by ID logic
            var product = new { Id = id, Name = "Product " + id.ToString(), Price = 19.99m };
            await httpContext.Response.WriteAsJsonAsync(product);
        })
        .WithName("GetProductById")
        .WithTags("Products");

        app.MapPost("/api/products", async (Product product) =>
        {
            return Results.Created($"/api/products/{product.Id}", product.Id);
        });

        app.MapPut("/api/products/{id:Guid}", async (Guid id, Product product) =>
        {
            return Results.NoContent();
        });

        app.MapDelete("/api/products/{id:Guid}", async (Guid id) =>
        {
            return Results.NoContent();
        });
    }
}
