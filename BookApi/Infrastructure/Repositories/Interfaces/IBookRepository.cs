using BookApi.Models;

namespace BookApi.Infrastructure.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IReadOnlyList<Book>> GetAllAsync();
    Task<Book> AddAsync(Book book);
}