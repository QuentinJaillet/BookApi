using BookApi.Application.Queries;
using BookApi.Infrastructure.Repositories.Interfaces;
using BookApi.Models;
using MediatR;

namespace BookApi.Application.Handlers;

public class GetBookByIsbnQueryHandler : IRequestHandler<GetBookByIsbnQuery, Book?>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIsbnQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository
            .GetByIsbnAsync(request.ISBN)
            .ConfigureAwait(false);
    }
}