using NoteApi.Endpoints;
using NoteApi.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<INoteRepository, InMemNoteRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapNotesEndpoints();
app.MapHealthChecks("/health");

app.Run();
