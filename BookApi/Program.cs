using BookApi.Application.Queries;
using MediatR;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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

// création d'une méthode HEAD

app.UseSwaggerUI();
app.Run();