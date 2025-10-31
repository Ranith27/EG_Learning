using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Course> Courses { get; }
        Task<int> SaveAsync();
    }
}
