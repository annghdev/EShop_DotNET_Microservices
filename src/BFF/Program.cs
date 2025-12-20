using BFF.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(o =>
{
    o.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader();
});

app.MapGet("/", () =>
{
    return Results.Ok("BFF is Running!");
});

app.MapProductEndpoints();

app.Run();