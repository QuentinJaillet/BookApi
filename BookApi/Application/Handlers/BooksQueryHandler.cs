using BookApi.Application.Queries;
using BookApi.Infrastructure.Repositories.Interfaces;
using BookApi.Models;
using MediatR;

namespace BookApi.Application.Handlers;

public class BooksQueryHandler : IRequestHandler<BooksQuery, IReadOnlyList<Book>>
{
    private readonly IBookRepository _bookRepository;

    public BooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IReadOnlyList<Book>> Handle(BooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository
            .GetAllAsync()
            .ConfigureAwait(false);
    }
}