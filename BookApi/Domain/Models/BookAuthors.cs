namespace BookApi.Models;

public class BookAuthors
{
    public Book Book { get; set; }
    public List<Author> Authors { get; set; }
}