using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task AddAsync(Student student); 
        void Update(Student student);
        void Delete(Student student);
        Task<bool> ExistsAsync(int id);
    }
}
