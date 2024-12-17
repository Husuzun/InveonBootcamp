using Library_Management.Models;
using System.Collections.Generic;
using System.Linq;
using Library_Management.Data;

namespace Library_Management.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> SearchBooks(string query)
        {
            return _context.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.ISBN.Contains(query))
                .ToList();
        }
    }
} 