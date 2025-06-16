using BookApi.Models;

namespace BookApi.Infrastructure.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IReadOnlyList<Book>> GetAllAsync();
    Task<Book?> GetByIsbnAsync(string isbn);
    Task<Book> AddAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task DeleteAsync(string isbn);
}