namespace Library_Management.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        void Complete();
    }
} 