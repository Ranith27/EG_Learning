using StudentManagement.Models;

namespace StudentManagement.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> PatchAsync(int id, StudentPatchDTO patch);
        Task<bool> DeleteStudentAsync(int id);
    }
}
