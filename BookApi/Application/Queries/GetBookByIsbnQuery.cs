using BookApi.Models;
using MediatR;

namespace BookApi.Application.Queries;

public sealed class GetBookByIsbnQuery : IRequest<Book?>
{
    public string ISBN { get; set; } = string.Empty;
}