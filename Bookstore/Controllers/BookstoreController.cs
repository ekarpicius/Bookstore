using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookstoreController : ControllerBase
    {
        private readonly IBookstoreService _bookstoreService;
        public BookstoreController(IBookstoreService bookstoreService)
        {
            _bookstoreService = bookstoreService;
        }

        [HttpGet("books/all")]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return _bookstoreService.GetAllBooks();
        }

        [HttpGet("authors/{id}/books")]
        public ActionResult<List<Book>> GetAllBooksByAuthor(int id)
        {
            var author = _bookstoreService.GetAuthor(id);
            if (author != null)
            {
                var books = _bookstoreService.GetAllBooksByAuthor(author);
                return books == null ? NotFound() : Ok(books);
            }

            return NotFound();
        }

        [HttpGet("authors/all")]
        public ActionResult<List<Author>> GetAllAuthors()
        {
            return _bookstoreService.GetAllAuthors();
        }

        [HttpGet("books/{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookstoreService.GetBook(id);

            return book == null ? NotFound() : Ok(book);
        }

        [HttpGet("authors/{id}")]
        public ActionResult<List<Author>> GetAuthor(int id)
        {
            var author = _bookstoreService.GetAuthor(id);

            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost("book")]
        public IActionResult AddBook(Book book)
        {
            _bookstoreService.AddBook(book);

            return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
        }

        [HttpPost("author")]
        public IActionResult AddAuthor(Author author)
        {
            _bookstoreService.AddAuthor(author);

            return CreatedAtAction(nameof(AddAuthor), new { id = author.Id }, author);
        }

        [HttpPut("books/{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existingBook = _bookstoreService.GetBook(id);
            if (existingBook is null) return NotFound();

            _bookstoreService.UpdateBook(book);

            return NoContent();
        }

        [HttpPut("authors/{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id) return BadRequest();

            var existingAuthor = _bookstoreService.GetAuthor(id);
            if (existingAuthor is null) return NotFound();

            _bookstoreService.UpdateAuthor(author);

            return NoContent();
        }

        [HttpDelete("books/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookstoreService.GetBook(id);
            if (book is null) return NotFound();

            _bookstoreService.DeleteBook(id);

            return NoContent();
        }

        [HttpDelete("authors/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _bookstoreService.GetAuthor(id);
            if (author is null) return NotFound();

            _bookstoreService.DeleteAuthor(id);

            return NoContent();
        }
    }
}