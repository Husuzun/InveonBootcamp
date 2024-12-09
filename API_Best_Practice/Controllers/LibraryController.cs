using API_Best_Practice.Models;
using API_Best_Practice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace API_Best_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly RedisCacheService _cacheService;
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(BookService bookService, RedisCacheService cacheService, ILogger<LibraryController> logger)
        {
            _bookService = bookService;
            _cacheService = cacheService;
            _logger = logger;
        }

        // GET: api/library/books
        [HttpGet("books")]
        public async Task<IActionResult> GetBooks()
        {
            const string cacheKey = "books";
            var cachedBooks = await _cacheService.GetCacheValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedBooks))
            {
                _logger.LogInformation("Books retrieved from cache.");
                var booksFromCache = JsonSerializer.Deserialize<IEnumerable<Book>>(cachedBooks);
                return Ok(ServiceResult<IEnumerable<Book>>.Success(booksFromCache, 200));
            }

            _logger.LogInformation("Books retrieved from BookService.");
            var books = _bookService.GetAllBooks();
            var serializedBooks = JsonSerializer.Serialize(books);
            await _cacheService.SetCacheValueAsync(cacheKey, serializedBooks, TimeSpan.FromMinutes(5));

            return Ok(ServiceResult<IEnumerable<Book>>.Success(books, 200));
        }

        // GET: api/library/books/{id}
        [HttpGet("books/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Book not found", 404));
            }
            return Ok(ServiceResult<Book>.Success(book, 200));
        }

        // POST: api/library/books
        [HttpPost("books")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(ServiceResult<Book>.Fail("Invalid book data", 400));
            }

            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, ServiceResult<Book>.Success(book, 201));
        }

        // PUT: api/library/books/{id}
        [HttpPut("books/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(ServiceResult<Book>.Fail("Invalid book data", 400));
            }

            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Book not found", 404));
            }

            _bookService.UpdateBook(id, book);
            return NoContent();
        }

        // DELETE: api/library/books/{id}
        [HttpDelete("books/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Book not found", 404));
            }

            _bookService.DeleteBook(id);
            return NoContent();
        }

        // GET: api/library/books/paged?pageNumber=1&pageSize=10
        [HttpGet("books/paged")]
        public IActionResult GetBooksPaged(int pageNumber = 1, int pageSize = 10)
        {
            var books = _bookService.GetBooksPaged(pageNumber, pageSize);
            return Ok(ServiceResult<IEnumerable<Book>>.Success(books, 200));
        }
    }
} 