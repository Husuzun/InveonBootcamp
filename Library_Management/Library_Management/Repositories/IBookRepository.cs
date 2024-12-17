using Library_Management.Models;
using System.Collections.Generic;

namespace Library_Management.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void Add(Book book);
        void Update(Book book);
        void Remove(Book book);
        IEnumerable<Book> SearchBooks(string query);
    }
} 