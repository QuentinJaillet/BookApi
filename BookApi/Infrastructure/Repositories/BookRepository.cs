using BookApi.Infrastructure.Data;
using BookApi.Infrastructure.Repositories.Interfaces;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;

    public BookRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Book>> GetAllAsync()
    {
        return await _context.Books
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Book?> GetByIsbnAsync(string isbn)
    {
        return await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.ISBN == isbn)
            .ConfigureAwait(false);
    }

    public async Task<Book> AddAsync(Book book)
    {
        await _context.Books
            .AddAsync(book)
            .ConfigureAwait(false);

        await _context
            .SaveChangesAsync()
            .ConfigureAwait(false);

        return book;
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context
            .SaveChangesAsync()
            .ConfigureAwait(false);

        return book;
    }

    public async Task DeleteAsync(string isbn)
    {
        var book = await _context.Books.FindAsync(isbn);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}