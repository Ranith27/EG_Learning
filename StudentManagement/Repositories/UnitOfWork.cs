using StudentManagement.Data;

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
