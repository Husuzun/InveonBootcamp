using API_Best_Practice.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Best_Practice.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book) => _books.Add(book);

        public void UpdateBook(int id, Book updatedBook)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
            }
        }

        public void DeleteBook(int id) => _books.RemoveAll(b => b.Id == id);

        public IEnumerable<Book> GetBooksPaged(int pageNumber, int pageSize)
        {
            return _books
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
} 