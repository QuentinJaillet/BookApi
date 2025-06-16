using BookApi.Application.Commands;
using BookApi.Application.Queries;
using BookApi.Infrastructure.Data;
using BookApi.Infrastructure.Repositories;
using BookApi.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=books.db"));

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseHttpMetrics();
app.MapMetrics();
app.UseSwagger();

app.MapGet("/api/books", async (IMediator mediator) =>
{
    var books = await mediator.Send(new BooksQuery());
    return Results.Ok(books);
});

app.MapPost("/api/books", async (AddBookCommand command, IMediator mediator) =>
{
    var book = await mediator.Send(command);
    return Results.Created($"/api/books/{book.ISBN}", book);
});

app.MapDelete("/api/books/{isbn}", async (string isbn, IMediator mediator) =>
{
    await mediator.Send(new DeleteBookCommand { ISBN = isbn });
    return Results.NoContent();
});

// création d'une méthode HEAD

app.UseSwaggerUI();
app.Run();