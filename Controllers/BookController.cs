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
        List<Book> response = CsvService.ReadFromCsv().ToList();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int nextId = CsvService.NextId();

        var NewBook = new Book()
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
}
