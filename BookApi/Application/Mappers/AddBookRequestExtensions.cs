using BookApi.Application.Requests;

namespace BookApi.Application.Mappers;

public static class AddBookRequestExtensions
{
    public static BookApi.Application.Commands.AddBookCommand ToCommand(this AddBookRequest request)
    {
        return new BookApi.Application.Commands.AddBookCommand
        {
            Title = request.Title,
            PublishedOn = request.PublishedOn,
            ISBN = request.ISBN,
            Categories = request.Categories?.ToArray() ?? Array.Empty<string>(),
            Pages = request.Pages,
            Publisher = request.Publisher,
            Language = request.Language,
            Description = request.Description,
            Price = request.Price
        };
    }
}