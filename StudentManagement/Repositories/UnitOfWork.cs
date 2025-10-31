using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Student> Students { get; }
        public IGenericRepository<Course> Courses { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new GenericRepository<Student>(_context);
            Courses = new GenericRepository<Course>(_context);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
