using BookApi.Application.Queries;
using BookApi.Models;
using MediatR;

namespace BookApi.Application.Handlers;

public class BooksQueryHandler : IRequestHandler<BooksQuery, IReadOnlyList<Book>>
{
    public Task<IReadOnlyList<Book>> Handle(BooksQuery request, CancellationToken cancellationToken)
    {
        var books = new List<Book>();

        books.Add(new Book
        {
            Title = "Design Patterns",
            PublishedOn = new DateTime(1994, 10, 1), 
            ISBN = "978-0201633610",
            Categories = new string[] { "Software", "Development" }, Pages = 395, Publisher = "Addison-Wesley",
            Language = "English",
            Description =
                "Design Patterns: Elements of Reusable Object-Oriented Software is a software engineering book describing software design patterns. The book's authors are Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides with a foreword by Grady Booch. The book is divided into two parts, with the first two chapters exploring the capabilities and pitfalls of object-oriented programming, and the remaining chapters describing 23 classic software design patterns. The book includes examples in C++ and Smalltalk.",
            Price = 29.99m
        });

        books.Add(new Book
        {
            Title = "Clean Code",
            PublishedOn = new DateTime(2008, 8, 11), ISBN = "978-0132350884",
            Categories = new string[] { "Software", "Development" }, Pages = 464, Publisher = "Prentice Hall",
            Language = "English",
            Description =
                "Even bad code can function. But if code isn't clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn't have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship. Martin has teamed up with his colleagues from Object Mentor to distill their best agile practice of cleaning code 'on the fly' into a book that will instill within you the values of a software craftsman and make you a better programmer--but only if you work at it.",
            Price = 37.99m
        });
        
        return Task.FromResult<IReadOnlyList<Book>>(books);
    }
}