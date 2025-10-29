using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
           var student = await _unitOfWork.Students.GetStudentByIdAsync(id);
            if (student == null) return false;
                _unitOfWork.Students.Delete(student);
                await _unitOfWork.SaveAsync();
                return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _unitOfWork.Students.GetAllStudentsAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetStudentByIdAsync(id);
        }

        public async Task<bool> PatchAsync(int id, StudentPatchDTO patch)
        {
            var existingStudent = await _unitOfWork.Students.GetStudentByIdAsync(id);
            if (existingStudent == null) return false;

            if (!string.IsNullOrEmpty(patch.Name))
                existingStudent.Name = patch.Name;

            if (!string.IsNullOrEmpty(patch.Phonenumber))
                existingStudent.Phonenumber = patch.Phonenumber;

            if (patch.Age.HasValue)
                existingStudent.Age = (int)patch.Age;

            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateStudentAsync(int id, Student student)
        {
            if (id != student.Id) return false;

            if (!await _unitOfWork.Students.ExistsAsync(id))
                return false;

            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
