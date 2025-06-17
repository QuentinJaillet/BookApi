namespace BookApi.Application.Responses;

public class BookResponse
{
    public string Title { get; set; }
    public DateTime PublishedOn { get; set; }
    public string ISBN { get; set; }
    public List<string> Categories { get; set; }
    public int Pages { get; set; }
    public string Publisher { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}