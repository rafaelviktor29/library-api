using Microsoft.AspNetCore.Mvc;
using Library.Entities;
using Library.Services;
using Library.Communication.Requests;
using Library.Communication.Responses;

namespace Library.Controllers;

public class BookController : LibraryBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        List<Book> response = CsvService.ReadFromCsv();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestBookJson request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int nextId = CsvService.NextId();

        var NewBook = new Book
        {
            Id = nextId,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            QuantityInStock = request.QuantityInStock
        };

        CsvService.AddBookToCsv(NewBook);

        var response = new ResponseCreateBookJson
        {
            Id = nextId,
            Title = request.Title,
            Author = request.Author
        };

        return Created(string.Empty, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestBookJson request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        List<Book> books = CsvService.ReadFromCsv().ToList();
        var bookToUpdate = books.FirstOrDefault(b => b.Id == id);

        if (bookToUpdate == null)
        {
            return NotFound();
        }

        bookToUpdate.Title = request.Title;
        bookToUpdate.Author = request.Author;
        bookToUpdate.Genre = request.Genre;
        bookToUpdate.Price = request.Price;
        bookToUpdate.QuantityInStock = request.QuantityInStock;

        CsvService.OverwriteBooksToCSV(books);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        List<Book> books = CsvService.ReadFromCsv();
        var book = books.SingleOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        int bookIndex = books.IndexOf(book);
        books[bookIndex].QuantityInStock = 0;
        CsvService.OverwriteBooksToCSV(books);

        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        List<Book> books = CsvService.ReadFromCsv();
        var book = books.SingleOrDefault(b => b.Id == id);

        return book == null ? NotFound() : Ok(book);
    }
}
