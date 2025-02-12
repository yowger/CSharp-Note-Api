using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

// app.MapGet("/", () => "GET");

// app.MapPost("/", () => "POST");

// app.MapPut("/", () => "PUT");

// app.MapDelete("/", () => "DELETE");

app.Run();
