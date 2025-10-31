using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _Dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _Dbset = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _Dbset.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _Dbset.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _Dbset.FindAsync(id);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await _Dbset.FindAsync(id);
            return entity != null;
        }
    }
}
