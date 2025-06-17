using System.ComponentModel.DataAnnotations;

namespace BookApi.Application.Requests;

public class AddBookRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime PublishedOn { get; set; }

    [Required]
    public string ISBN { get; set; }

    public List<string> Categories { get; set; }

    [Required]
    public int Pages { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public string Language { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}