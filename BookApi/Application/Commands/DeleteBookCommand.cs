using MediatR;

namespace BookApi.Application.Commands;

public sealed class DeleteBookCommand : IRequest
{
    public string ISBN { get; set; } = string.Empty;
}