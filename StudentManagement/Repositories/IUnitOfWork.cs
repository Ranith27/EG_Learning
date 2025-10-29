namespace StudentManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        Task<int> SaveAsync();
    }
}
