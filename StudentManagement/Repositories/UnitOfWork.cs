using StudentManagement.Data;
<<<<<<< HEAD
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
=======

namespace StudentManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; }
        public UnitOfWork(ApplicationDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            Students = studentRepository;
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
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
