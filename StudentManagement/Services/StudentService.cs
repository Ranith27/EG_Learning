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
<<<<<<< HEAD
           var student = await _unitOfWork.Students.GetByIdAsync(id);
=======
           var student = await _unitOfWork.Students.GetStudentByIdAsync(id);
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
            if (student == null) return false;
                _unitOfWork.Students.Delete(student);
                await _unitOfWork.SaveAsync();
                return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
<<<<<<< HEAD
            try
            { 
                var students = await _unitOfWork.Students.GetAllAsync();

                if (students == null || !students.Any())
                {
                    return new List<Student>(); 
                }

                return students; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StudentService.GetAllStudentsAsync: {ex.Message}");
                throw; 
            }
=======
            return await _unitOfWork.Students.GetAllStudentsAsync();
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
<<<<<<< HEAD
            return await _unitOfWork.Students.GetByIdAsync(id);
=======
            return await _unitOfWork.Students.GetStudentByIdAsync(id);
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
        }

        public async Task<bool> PatchAsync(int id, StudentPatchDTO patch)
        {
<<<<<<< HEAD
            var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);
=======
            var existingStudent = await _unitOfWork.Students.GetStudentByIdAsync(id);
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
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
