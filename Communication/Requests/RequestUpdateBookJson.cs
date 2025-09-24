using Library.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.Communication.Requests;

public class RequestUpdateBookJson
{
    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Author { get; set; }

    public BookGenre Genre { get; set; }
}
