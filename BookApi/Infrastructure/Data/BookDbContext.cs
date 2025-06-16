using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infrastructure.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.ISBN);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ISBN).HasMaxLength(20);
            entity.Property(e => e.Publisher).HasMaxLength(100);
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Categories)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                );
        });

        base.OnModelCreating(modelBuilder);
    }
}