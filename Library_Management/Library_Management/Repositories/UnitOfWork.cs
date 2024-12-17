using Library_Management.Data;

namespace Library_Management.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
} 