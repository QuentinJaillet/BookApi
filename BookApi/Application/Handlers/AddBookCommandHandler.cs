using BookApi.Application.Commands;
using BookApi.Models;
using MediatR;

namespace BookApi.Application.Handlers;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
{
    public Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            PublishedOn = request.PublishedOn,
            ISBN = request.ISBN,
            Categories = request.Categories,
            Pages = request.Pages,
            Publisher = request.Publisher,
            Language = request.Language,
            Description = request.Description,
            Price = request.Price
        };

        return Task.FromResult(book);
    }
}