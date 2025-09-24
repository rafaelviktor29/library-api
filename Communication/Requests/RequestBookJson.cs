using Library.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Communication.Requests;

public class RequestBookJson
{
    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Author { get; set; }

    public BookGenre Genre { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue)]
    public int QuantityInStock { get; set; } = 1;
}
