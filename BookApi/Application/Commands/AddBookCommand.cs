using BookApi.Models;
using MediatR;

namespace BookApi.Application.Commands;

public sealed class AddBookCommand : IRequest<Book>
{
    public string Title { get; set; } = string.Empty;
    public DateTime PublishedOn { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string[] Categories { get; set; } = Array.Empty<string>();
    public int Pages { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}