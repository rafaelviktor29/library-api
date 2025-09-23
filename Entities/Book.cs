using System.ComponentModel.DataAnnotations;
using Library.Services;

namespace Library.Entities;

public enum BookGenre
{
    Fantasy = 1,
    ScienceFiction = 2,
    Mystery = 3,
    Romance = 4,
    Horror = 5
}

public class Book
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public BookGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int LoanedCopies { get; set; }

    public Book(int id, string title, string author, BookGenre genre, decimal price, int quantityInStock)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        QuantityInStock = quantityInStock;
        LoanedCopies = 0;
    }

    public Book()
    {
        LoanedCopies = 0;
    }

    public override string ToString()
    {
        return $"Id: {Id}\nTítulo: {Title}\nAutor: {Author}\nPreço: {Price:C}\nQtd Estoque: {QuantityInStock}\nEmprestados: {LoanedCopies}";
    }
}
