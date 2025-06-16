using BookApi.Models;
using MediatR;

namespace BookApi.Application.Queries;

public sealed class BooksQuery : IRequest<IReadOnlyList<Book>>;