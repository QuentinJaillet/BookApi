namespace BookApi.Application.Mappers;

public static class BookResponseExtensions
{
    public static Responses.BookResponse ToResponse(this Models.Book book)
    {
        return new Responses.BookResponse
        {
            Title = book.Title,
            PublishedOn = book.PublishedOn,
            ISBN = book.ISBN,
            Categories = book.Categories?.ToList() ?? new List<string>(),
            Pages = book.Pages,
            Publisher = book.Publisher,
            Language = book.Language,
            Description = book.Description,
            Price = book.Price
        };
    }

    public static IEnumerable<Responses.BookResponse> ToResponse(this IEnumerable<Models.Book> books)
    {
        return books.Select(book => book.ToResponse()).ToList();
    }
}