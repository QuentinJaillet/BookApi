using BookApi.Application.Commands;
using BookApi.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace BookApi.Application.Handlers;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.DeleteAsync(request.ISBN);
    }
}